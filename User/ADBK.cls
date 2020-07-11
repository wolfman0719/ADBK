/// ADBK from DASL definition
Class User.ADBK Extends (%Persistent, %XML.Adaptor) [ Not Abstract, ClassType = persistent, Not Final, Not Hidden, Inheritance = right, Not NoContext, StorageStrategy = SQLStorage, System = 0 ]
{

Query ByName(Name As %String) As %SQLQuery(CONTAINID = 1) [ SqlProc ]
{
SELECT %ID,ANAME FROM ADBK
 WHERE (ANAME %STARTSWITH :Name)
 ORDER BY %ID
}

Parameter KEYS = "AID";

Property AAGE As %Integer [ Calculated, ReadOnly, SqlComputeCode = {set {AAGE}=$H-{ABTHDAY}\365.25  
}, SqlComputed ];

/// Birthday
Property ABTHDAY As %Date;

/// City Name
Property ACITY As %String(TRUNCATE = 1);

/// ANAME
Property ANAME As %String(PATTERN = ".ZFWCHARZ1""　"".ZFWCHARZ", TRUNCATE = 1);

/// Phone No. Home
Property APHHOME As %String(PATTERN = ".N1""-"".N1""-"".N", TRUNCATE = 1);

/// Phone No. Other
Property APHOTH1 As %String(PATTERN = ".N1""-"".N1""-"".N", TRUNCATE = 1);

/// Phone No. Working
Property APHWORK As %String(PATTERN = ".N1""-"".N1""-"".N", TRUNCATE = 1);

/// State 
Property ASTATE As %String(TRUNCATE = 1);

/// Street Name
Property ASTREET As %String(TRUNCATE = 1);

/// Zip Code
Property AZIP As %String(PATTERN = "3N1""-""4N", TRUNCATE = 1);

/// XNAMEインデックス  
///   DASL用に定義されていたインデックス
///   この構造（$pieceで加工）をCache SQLはインデックスとして採用してくれないので%starswith句に
///   名前で条件を使用したクエリ等では、全件走査する。
///   この問題解決のためXNAME2インデックスを作成した。
ClassMethod GetInstanceById(id As %String) As %List [ SqlProc ]
{
	set record1 = $get(^ADBK("DATA",id,"DEMO"))
	set record2 = $get(^ADBK("DATA",id,"PHONE"))
	if record1 = "" quit $listbuild(0)
	set name = $piece(record1,";",1)
	set street = $piece(record1,";",2)
	set city = $translate($piece(record1,";",4),$char(0),"")
	set zip = $piece(record1,";",5)
	set dob = $piece(record1,";",6)
	set dobc = $translate($zdate($piece(record1,";",6),3),"-","/")
	set homephone = $piece(record2,";",1)
	set workphone = $piece(record2,";",2)
	set otherphone = $translate($piece(record2,";",3),$char(0),"")
	set age = +$h - dob\365.25
	quit $listbuild(1,name,street,city,zip,dobc,homephone,workphone,otherphone,age,id)
}

ClassMethod ListByName(name As %String) As %List [ SqlProc ]
{
	if $ascii(name)=0 set name = ""
	set node = name
	//検索開始文字列の調整　検索文字の最後の文字を1つ前の文字コードに変更
	;if node'="" set node=$extract(node,1,$length(node)-1)_$char($ascii($extract(node,$length(node)))-1)
	if node'="" set node=$order(^ADBK("XNAME2",node),-1)
	set count = 0
	for {
		set node = $order(^ADBK("XNAME2",node))
		if node = "" quit
		if node '[ name quit
		set id = $order(^ADBK("XNAME2",node,""))
		set count = count + 1
		set $list(namelist,count) = id_" "_node
	}
	
	if $data(namelist) {
	   quit namelist
	}
	quit $listbuild("no listです")
}

ClassMethod File(record As %List, newflag As %Boolean, ByRef errormessage As %String, ByRef id As %String) As %Boolean [ SqlProc ]
{
	try {
	   tstart

	   set name = $list(record,2)
	   set street = $list(record,3)
	   set city = $list(record,4)
	   set zip = $list(record,5)
	   
	   // dobの変換にエラーがあれば、<ILLEGAL VALUE>でcatchされるはず
	   set dob = $zdateh($translate($list(record,6),"/","-"),8)
	   set homephone = $list(record,7)
	   set workphone = $list(record,8)
	   
	   if name'?.ZFWCHARZ1"　".ZFWCHARZ { 
		   set errorh = ##class(ADBK.Exception).%New()
		   set errorh.Name = "氏名形式エラー"
		   Throw errorh
	   }
	   
	   if (zip'="")&&(zip'?3N1"-"4N) {
		   set errorh = ##class(ADBK.Exception).%New()
		   set errorh.Name = "郵便番号形式エラー"
		   Throw errorh
	   }
	   
	   if (homephone'="")&&(homephone'?.N1"-".N1"-".N) {
		   set errorh = ##class(ADBK.Exception).%New()
		   set errorh.Name = "電話番号形式エラー"
		   Throw errorh
	   }
       
	   if (workphone'="")&&(workphone'?.N1"-".N1"-".N) {
		   set errorh = ##class(ADBK.Exception).%New()
		   set errorh.Name = "電話番号形式エラー"
		   Throw errorh
	   }
	   
	   //if newflag = 1 {
	   if newflag = "True" {
		   //新規作成　新規の場合、$incrementでユニーク性が保証されているので、関連グローバルをlockする必要なし
		   set id = $increment(^ADBK("COUNT"))
		   set last = $piece(name,"　",1)
		   set first = $piece(name,"　",2)
		   set ^ADBK("XNAME2",name,id) = ""
		   set ^ADBK("XNAME",last,first,id) = ""
		   set ^ADBK("XZIP",zip,id) = ""
	       set ^ADBK("DATA",id,"DEMO") = name_";"_street_";;;"_zip_";"_dob
	       set ^ADBK("DATA",id,"PHONE") = homephone_";"_workphone_";"
	       set status = 1
	   }
	   else {
		   //既存レコード更新
		   set id = $list(record,1)		
	       set oldrecord1 = $get(^ADBK("DATA",id,"DEMO"))
	       set oldname = $piece(oldrecord1,";",1)
	       set oldzip = $piece(oldrecord1,";",5)

	       lock +^ADBK("DATA",id)
	
	       if oldname '= name {
		      set oldlast = $piece(oldname,"　",1)
		      set oldfirst = $piece(oldname,"　",2)
		      set last = $piece(name,"　",1)
		      set first = $piece(name,"　",2)
		      lock +^ADBK("XNAME2",oldname,id)		   
		      lock +^ADBK("XNAME2",name,id)
		      lock +^ADBK("XNAME",oldlast,oldfirst,id)
		      lock +^ADBK("XNAME",last,first,id)
		
		      kill ^ADBK("XNAME2",oldname,id)
		      kill ^ADBK("XNAME",oldlast,oldfirst,id)
		      set ^ADBK("XNAME2",name,id) = ""
		      set ^ADBK("XNAME",last,first,id) = ""
		
		      lock -^ADBK("XNAME2",oldname,id)
		      lock -ADBK("XNAME2",name,id)
		      lock -^ADBK("XNAME",oldlast,oldfirst,id)
		      lock -^ADBK("XNAME",last,first,id)
	      }
	
	      if oldzip '= zip {
		      lock +ADBK("XZIP",oldzip,id)
		      lock +ADBK("XZIP",zip,id)
		
		      kill ^ADBK("XZIP",oldzip,id)
		      set ^ADBK("XZIP",zip,id) = ""
		      lock -ADBK("XZIP",oldzip,id)
		      lock -ADBK("XZIP",zip,id)
	      }
	
	      set ^ADBK("DATA",id,"DEMO") = name_";"_street_";;;"_zip_";"_dob
	      set ^ADBK("DATA",id,"PHONE") = homephone_";"_workphone_";"
	
	      lock -^ADBK("DATA",id) 
		
	      set status = 1
	   }
	   
	   tcommit
	
	}
	catch error {
		
	    set errormessage = error.Name
	    if errormessage [ "<ILLEGAL VALUE>" set errormessage = "誕生日の日付指定に誤りがあります。YYYY/MM/DD"
	    if errormessage [ "<SUBSCRIPT>" set errormessage = "インデックス形式エラー"
		
	    trollback
	    set status = 0
	}
	
	quit status
}

ClassMethod FileWapper(record) As %List [ SqlProc ]
{
	set chr1 = $char(1)
	set id = $piece(record,chr1,1)
	set name = $piece(record,chr1,2)
	set street = $piece(record,chr1,3)
	set city = $piece(record,chr1,4)
	set zipcode = $piece(record,chr1,5)
	set dob = $piece(record,chr1,6)
	set homephone = $piece(record,chr1,7)	
	set workphone = $piece(record,chr1,8)
	set newflag = $piece(record,chr1,9)

    set record = $listbuild(id,name,street,city,zipcode,dob,homephone,workphone)	
	set status = ..File(record,newflag,.errormessage,.id)
	if status = 1 {
	   quit $listbuild("成功",id)
	}
	else {
	   quit $listbuild(errormessage,id)
	}
}

ClassMethod DeleteById(id As %String) As %List [ SqlProc ]
{
	try {
		tstart
		
		lock +^ADBK("DATA",id)
		
		//データが存在しない場合には、エラーがcatchされるはず
		set record = ^ADBK("DATA",id,"DEMO")
		set name = $piece(record,";",1)
		set last = $piece(name,"　",1)
		set first = $piece(name,"　",2)
		set zip = $piece(record,";",5)
		lock +^ADBK("XNAME2",name,id)
		lock +^ADBK("XZIP",zip,id)
		lock +^ADBK("XNAME",last,first,id)
		
		kill ^ADBK("XNAME2",name,id)
		kill ^ADBK("XNAME",last,first,id)
		kill ^ADBK("XZIP",zip,id)
		kill ^ADBK("DATA",id)
		
		lock -^ADBK("XNAME2",name,id)
		lock -^ADBK("XZIP",zip,id)
		lock -^ADBK("XNAME",last,first,id)

		lock -^ADBK("DATA",id)
		
		tcommit
		set status = 1
	}
	catch error {
		set errormessage = "削除エラー "_error.Name
		trollback
		set status = 0
	}
	quit $listbuild(status,$get(errormessage))
}

/*
ClassMethod DeleteById(id As %String, ByRef errormessage As %String) As %Boolean [ SqlProc ]
{
	try {
		tstart
		
		lock +^ADBK("DATA",id)
		
		//データが存在しない場合には、エラーがcatchされるはず
		set record = ^ADBK("DATA",id,"DEMO")
		set name = $piece(record,";",1)
		set last = $piece(name,"　",1)
		set first = $piece(name,"　",2)
		set zip = $piece(record,";",5)
		lock +^ADBK("XNAME2",name,id)
		lock +^ADBK("XZIP",zip,id)
		lock +^ADBK("XNAME",last,first,id)
		
		kill ^ADBK("XNAME2",name,id)
		kill ^ADBK("XNAME",last,first,id)
		kill ^ADBK("XZIP",zip,id)
		kill ^ADBK("DATA",id)
		
		lock -^ADBK("XNAME2",name,id)
		lock -^ADBK("XZIP",zip,id)
		lock -^ADBK("XNAME",last,first,id)

		lock -^ADBK("DATA",id)
		
		tcommit
		set status = 1
	}
	catch error {
		set errormessage = "削除エラー "_error.Name
		trollback
		set status = 0
	}
	quit status
}
*/
Storage SQLStorage
{
<ExtentSize>100000</ExtentSize>
<Property name="AAGE"/>
<Property name="ABTHDAY"/>
<Property name="ACITY"/>
<Property name="ANAME"/>
<Property name="APHHOME"/>
<Property name="APHOTH1"/>
<Property name="APHWORK"/>
<Property name="ASTATE"/>
<Property name="ASTREET"/>
<Property name="AZIP"/>
<SqlIdExpression>$$next("^ADBK(""COUNT"")")</SqlIdExpression>
<SQLMap name="ANAME2IndexMap">
<Global>^ADBK</Global>
<RowIdSpec name="1">
<Expression>{L3}</Expression>
<Field>AID</Field>
</RowIdSpec>
<Structure>delimited</Structure>
<Subscript name="1">
<AccessType>sub</AccessType>
<Expression>"XNAME2"</Expression>
</Subscript>
<Subscript name="2">
<AccessType>sub</AccessType>
<Expression>{ANAME}</Expression>
</Subscript>
<Subscript name="3">
<AccessType>sub</AccessType>
<Expression>{AID}</Expression>
</Subscript>
<Type>index</Type>
</SQLMap>
<SQLMap name="ANAMEIndexMap">
<Global>^ADBK</Global>
<RowIdSpec name="1">
<Expression>{L4}</Expression>
<Field>AID</Field>
</RowIdSpec>
<Structure>delimited</Structure>
<Subscript name="1">
<AccessType>sub</AccessType>
<Expression>"XNAME"</Expression>
</Subscript>
<Subscript name="2">
<AccessType>sub</AccessType>
<Expression>$P({ANAME},"　",1)</Expression>
</Subscript>
<Subscript name="3">
<AccessType>sub</AccessType>
<Expression>$P({ANAME},"　",2)</Expression>
</Subscript>
<Subscript name="4">
<AccessType>sub</AccessType>
<Expression>{AID}</Expression>
</Subscript>
<Type>index</Type>
</SQLMap>
<SQLMap name="AZIPIndexMap">
<Global>^ADBK</Global>
<RowIdSpec name="1">
<Expression>{L3}</Expression>
<Field>AID</Field>
</RowIdSpec>
<Structure>delimited</Structure>
<Subscript name="1">
<AccessType>sub</AccessType>
<Expression>"XZIP"</Expression>
</Subscript>
<Subscript name="2">
<AccessType>sub</AccessType>
<Expression>{AZIP}</Expression>
</Subscript>
<Subscript name="3">
<AccessType>sub</AccessType>
<Expression>{AID}</Expression>
</Subscript>
<Type>index</Type>
</SQLMap>
<SQLMap name="MasterMap">
<Data name="ABTHDAY">
<Delimiter>";"</Delimiter>
<Node>"DEMO"</Node>
<Piece>6</Piece>
</Data>
<Data name="ACITY">
<Delimiter>";"</Delimiter>
<Node>"DEMO"</Node>
<Piece>4</Piece>
</Data>
<Data name="ANAME">
<Delimiter>";"</Delimiter>
<Node>"DEMO"</Node>
<Piece>1</Piece>
</Data>
<Data name="APHHOME">
<Delimiter>";"</Delimiter>
<Node>"PHONE"</Node>
<Piece>1</Piece>
</Data>
<Data name="APHOTH1">
<Delimiter>";"</Delimiter>
<Node>"PHONE"</Node>
<Piece>3</Piece>
</Data>
<Data name="APHWORK">
<Delimiter>";"</Delimiter>
<Node>"PHONE"</Node>
<Piece>2</Piece>
</Data>
<Data name="ASTATE">
<Delimiter>";"</Delimiter>
<Node>"DEMO"</Node>
<Piece>3</Piece>
</Data>
<Data name="ASTREET">
<Delimiter>";"</Delimiter>
<Node>"DEMO"</Node>
<Piece>2</Piece>
</Data>
<Data name="AZIP">
<Delimiter>";"</Delimiter>
<Node>"DEMO"</Node>
<Piece>5</Piece>
</Data>
<Global>^ADBK</Global>
<RowIdSpec name="1">
<Expression>{L2}</Expression>
<Field>AID</Field>
</RowIdSpec>
<Structure>delimited</Structure>
<Subscript name="1">
<AccessType>sub</AccessType>
<Expression>"DATA"</Expression>
</Subscript>
<Subscript name="2">
<AccessType>sub</AccessType>
<Expression>{AID}</Expression>
</Subscript>
<Type>data</Type>
</SQLMap>
<SqlRowIdName>AID</SqlRowIdName>
<SqlTableNumber>1</SqlTableNumber>
<StreamLocation>^User.ADBKS</StreamLocation>
<Type>%Storage.SQL</Type>
}

}
