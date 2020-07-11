Class ADBK.JSON Extends %Base
{

ClassMethod ListByName(name As %String) As %Status [ SqlProc ]
{
	if $data(%request) {
        set %response.ContentType="application/json"
	    set %response.CharSet = "utf-8"
	 }

	set status = $$$OK
	try {
	set namearray = []
	if $ascii(name)=0 set name = ""
	set node = name
	//検索開始文字列の調整　検索文字の最後の文字を1つ前の文字コードに変更
	if node'="" set node=$order(^ADBK("XNAME2",node),-1)
	set count = 0
	for {
		set node = $order(^ADBK("XNAME2",node))
		if node = "" quit
		if node '[ name quit
		set id = $order(^ADBK("XNAME2",node,""))
		set count = count + 1
		do namearray.%Push(id_" "_node)
	}
	
	write namearray.%ToJSON()
	}
	catch e {
		set status = e.AsStatus()
	}
	quit status
}

ClassMethod GetData(Name As %String) As %Status
{
 set status = $$$OK
 try {
      if $data(%request) {
        set %response.ContentType="application/json"
	    set %response.CharSet = "utf-8"
	  }

      set personobject = {}
      If Name="" set personobject.Error="名前が選択されていません" write personobject.%ToJSON() Quit
      Set FName=$Piece(Name," ",1)
      Set LName=$Piece(Name," ",2)
      Set Node="" Set Node=$Order(^ADBK("XNAME",FName,LName,Node))
      If Node="" Set personobject.Error="No Data"  write personobject.%ToJSON() Quit
      Set Data=^ADBK("DATA",Node,"DEMO")
      Set Phone=^ADBK("DATA",Node,"PHONE")
      Set personobject.Id = Node
      Set personobject.Name=$Piece(Data,";",1)
      Set personobject.Address=$Piece(Data,";",2)
      Set personobject.Zip=$Piece(Data,";",5)
      Set personobject.Age=($h-$Piece(Data,";",6))\365.25
      Set personobject.Dob=$ZDATE($Piece(Data,";",6),3)
      Set personobject.Telh=$Piece(Phone,";",1)
      Set personobject.Telw=$Piece(Phone,";",2)
      Set personobject.Error = "ok"
      write personobject.%ToJSON()
 }
 catch e {
	 set status = e.AsStatus()
 }

 Quit status
}

ClassMethod Delete(Id As %Integer)
{
 Lock +^ADBK("DATA",Id)
 Set Name=$Piece(^ADBK("DATA",Id,"DEMO"),";",1)
 Kill ^ADBK("DATA",Id)
 Kill ^ADBK("XNAME",$Piece(Name,"　",1),$Piece(Name,"　",2),Id)
 Kill ^ADBK("XNAME2",Name,Id)
 Lock -^ADBK("DATA",Id)
 Quit $$$OK
}

ClassMethod Create()
{
 set status = $$$OK
	
 try {
		
   if $data(%request) {
     set len = 1000
     set json = %request.Content.Read(.len,.status)
   }
   
   set record = {}.%FromJSON(json)	  
   Set Error= {}
   Set Id=$increment(^ADBK("COUNT"))
   Set Name=record.Name
   Set Address=record.Address
   Set Zip=record.Zip
   If Zip'="",Zip'?3n1"-"4n Set Error.Message="郵便番号は, 999-9999の形式で入力" write Error.%ToJSON() Quit
   Set Age=record.Age
   If Age'="" Set Error.Message="登録時には、年齢の入力は、不要" write Error.%ToJSON() Quit
   Set DOB=record.DOB
   If DOB'="",DOB'?4n1"-"2n1"-"2n Set Error.Message="誕生日は、YYYY-MM-DDの形式" write Error.%ToJSON() Quit
   If DOB'="" Set DOB=$ZDATEH(DOB,3)
   Set Age=($h-DOB)\365.25
   Set Telh=record.Telh
   Set Telw=record.Telw
   If Telw'="",Telw'?.n1"-".n1"-".n Set Error.Message="電話番号は、999-9999-9999の形式で入力" write Error.%ToJSON() Quit
   If Telh'="",Telh'?.n1"-".n1"-".n Set Error.Message="電話番号は、999-9999-9999の形式で入力"  write Error.%ToJSON() Quit
   Set LName=$Piece(Name,"　",1)
   Set FName=$Piece(Name,"　",2)
   If FName="" Set Error.Message="名前は、全角スペースで区切って下さい。" write Error.%ToJSON() Quit
   Lock +^ADBK("DATA",Id)
   Set ^ADBK("DATA",Id,"DEMO")=Name_";"_Address_";;;"_Zip_";"_DOB
   Set ^ADBK("DATA",Id,"PHONE")=Telh_";"_Telw_";"
   Set ^ADBK("XNAME",LName,FName,Id)=""
   Set ^ADBK("XNAME2",Name,Id)=""
   Lock -^ADBK("DATA",Id)  	
  }
  catch e {
		
    set status = e.AsStatus()
  }

 Quit status
}

ClassMethod Update()
{
 set status = $$$OK
	
 try {
		
   if $data(%request) {
     set len = 1000
     set json = %request.Content.Read(.len,.status)
   }
   
   set record = {}.%FromJSON(json)
   set Id = record.Id	  
   Set Error= {}
   Set Name=record.Name
   Set Address=record.Address
   Set Zip=record.Zip
   If Zip'="",Zip'?3n1"-"4n Set Error.Message="郵便番号は, 999-9999の形式で入力" write Error.%ToJSON() Quit
   Set DOB=record.DOB
   If DOB'="",DOB'?4n1"-"2n1"-"2n Set Error.Message="誕生日は、YYYY-MM-DDの形式"  write Error.%ToJSON() Quit
   If DOB'="" Set DOB=$ZDATEH(DOB,3)
   Set Telh=record.Telh
   Set Telw=record.Telw
   If Telw'="",Telw'?.n1"-".n1"-".n Set Error.Message="電話番号は、999-9999-9999の形式で入力" write Error.%ToJSON() Quit
   If Telh'="",Telh'?.n1"-".n1"-".n Set Error.Message="電話番号は、999-9999-9999の形式で入力" write Error.%ToJSON() Quit
   Set LName=$Piece(Name,"　",1)
   Set FName=$Piece(Name,"　",2)
   If FName="" Set Error.Message="名前は、全角スペースで区切って下さい。" write Error.%ToJSON() Quit
   Lock +^ADBK("DATA",Id)
   Set ^ADBK("DATA",Id,"DEMO")=Name_";"_Address_";;;"_Zip_";"_DOB
   Set ^ADBK("DATA",Id,"PHONE")=Telh_";"_Telw_";"
   Set ^ADBK("XNAME",LName,FName,Id)=""
   Set ^ADBK("XNAME2",Name,Id)=""
   Lock -^ADBK("DATA",Id)  	
  }
  catch e {
		
    set status = e.AsStatus()
  }

 Quit status
}

}
