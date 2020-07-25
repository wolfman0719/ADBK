Class ADBK.Broker Extends %CSP.REST
{

Parameter CONVERTINPUTSTREAM = 1;

XData UrlMap
{
<Routes>
  <Route Url="/getdatabyid/:id" Method="GET" Call="ADBK.JSON:GetDataById"/>
  <Route Url="/getdata/:name" Method="GET" Call="ADBK.JSON:GetData"/>
  <Route Url="/listbyname/:name" Method="GET" Call="ADBK.JSON:ListByName"/>
  <Route Url="/delete/:id" Method="DELETE" Call="ADBK.JSON:Delete"/>
  <Route Url="/create" Method="POST" Call="ADBK.JSON:Create"/>
  <Route Url="/modify" Method="PUT" Call="ADBK.JSON:Update"/>
</Routes>
}

}
