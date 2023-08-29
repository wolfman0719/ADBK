ARG IMAGE=containers.intersystems.com/intersystems/iris-community-arm64:2022.1.0.209.0
ARG IMAGE=containers.intersystems.com/intersystems/iris-community-arm64:2023.1.0.235.1
ARG IMAGE=containers.intersystems.com/intersystems/iris-community:2022.1.0.209.0
ARG IMAGE=containers.intersystems.com/intersystems/iris-community:2023.1.0.235.1
FROM $IMAGE

ARG COMMIT_ID="adbkdemo"

USER root   
        
ENV ISC_TEMP_DIR=/intersystems/iris/adbk

USER ${ISC_PACKAGE_MGRUSER}

COPY src/ $ISC_TEMP_DIR/

COPY iris.script /tmp/iris.script

USER root

RUN chown ${ISC_PACKAGE_MGRUSER}:${ISC_PACKAGE_IRISGROUP} /intersystems/iris/adbk

USER ${ISC_PACKAGE_MGRUSER}

RUN iris start IRIS \
	&& iris session IRIS < /tmp/iris.script \
    && iris stop IRIS quietly 
    
ARG COMMIT_ID="adbkdemo"

USER irisowner

ENV ISC_TEMP_DIR=/intersystems/iris/adbk
COPY adbk/* $ISC_TEMP_DIR/

RUN  iris start $ISC_PACKAGE_INSTANCENAME \ 
&& printf 'Do ##class(Config.NLS.Locales).Install("jpuw") \
 set sec = ##class("Security.Applications").%%New() \
 set sec.Name = "/api/adbk" \
 set sec.NameSpace = "USER" \
 set sec.DispatchClass ="ADBK.Broker" \
 set sec.AutheEnabled = 32 \
 set status = sec.%%Save() \
 set user = ##class(Security.Users).%%OpenId("_system") \
 set user.PasswordExternal = "demosystem" \
 set status = user.%%Save() \
 h\n' | iris session $ISC_PACKAGE_INSTANCENAME -U %SYS \ 
&& printf 'Do $system.OBJ.LoadDir("'$ISC_TEMP_DIR'/adbk/","ck",,1) \
 h\n' | iris session $ISC_PACKAGE_INSTANCENAME -U USER \
 && iris stop $ISC_PACKAGE_INSTANCENAME quietly

RUN rm -f $ISC_PACKAGE_INSTALLDIR/mgr/journal.log \
 && rm -f $ISC_PACKAGE_INSTALLDIR/mgr/IRIS.WIJ \
 && rm -f $ISC_PACKAGE_INSTALLDIR/mgr/iris.ids \
 && rm -f $ISC_PACKAGE_INSTALLDIR/mgr/alerts.log \
 && rm -f $ISC_PACKAGE_INSTALLDIR/mgr/journal/* \
 && rm -f $ISC_PACKAGE_INSTALLDIR/mgr/messages.log

RUN echo $COMMIT_ID > $HOME/commit.txt
