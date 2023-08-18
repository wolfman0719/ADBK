import {FormEventHandler }  from 'react';
import { ChangeEvent, useState } from "react";
import axios from "axios";

import configinfo from '../serverconfig.json';

const ServerAddress = configinfo.ServerAddress;
const ServerPort = configinfo.ServerPort;
const Username = configinfo.Username;
const Password = configinfo.Password;

export const Adbk = (props: any) => {

  const [inputtext, setInputText] = useState<any>("");
  const [nameList, setNameList] = useState<any>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [isError, setIsError] = useState(false);
  const [errorText, setErrorText] = useState("");
  const [name, setName] = useState<any>("");
  const [aid, setAid] = useState<any>("");
  const [zipcode, setZipcode] = useState<any>("");
  const [address, setAddress] = useState<any>("");
  const [telh, setTelh] = useState<any>("");
  const [telw, setTelw] = useState<any>("");
  const [age, setAge] = useState<any>("");
  const [dob, setDob] = useState<any>("");

  const onChangeZipcode = (e: ChangeEvent<HTMLInputElement>) => setZipcode(e.target.value);  
  const onChangeAddress = (e: ChangeEvent<HTMLInputElement>) => setAddress(e.target.value);  
  const onChangeTelh = (e: ChangeEvent<HTMLInputElement>) => setTelh(e.target.value);  
  const onChangeTelw = (e: ChangeEvent<HTMLInputElement>) => setTelw(e.target.value);  
  const onChangeDob = (e: ChangeEvent<HTMLInputElement>) => setDob(e.target.value);  

  const onChangeText = (e: ChangeEvent<HTMLInputElement>) => {
  	setInputText(e.target.value);
	setIsLoading(true);
    setIsError(false);
    
    let name = e.target.value;
    
	axios
	  .get<any>(`http://${ServerAddress}:${ServerPort}/api/adbk/listbyname/${name}?IRISUsername=${Username}&IRISPassword=${Password}`)
	  .then((result: any) => {
	  	console.log('result = ' + result.data.length);
	  	const names = result.data.map((idname: any) => ({
		id: idname.split(" ")[0],
		name: idname.split(" ")[1]
      }));
      setNameList(names);
	  })
      .catch((error: any) => {
        setIsError(true)
		 if (error.response) {			
		   setErrorText(error.response.data.summary);
		 }
		 else if (error.request) {
		   setErrorText(error.request);
		 } 
		 else {
		   setErrorText(error.message);
		 }
	  })
      .finally(() => setIsLoading(false));

     setName("");
     setZipcode("");
     setAddress("");
     setTelh("");
     setTelw("");
     setAge("");
     setDob("");
     setAid(1000);
  }

   const onClickItem = (e: any) => {
	setIsLoading(true);
	setIsError(false);
	
	let id = e.target.value;

	axios
	  .get<any>(`http://${ServerAddress}:${ServerPort}/api/adbk/getdatabyid/${id}?IRISUsername=${Username}&IRISPassword=${Password}`)
	  .then((result: any) => {
		setName(result.data.Name);
		setZipcode(result.data.Zip);
		setAddress(result.data.Address);
		setTelh(result.data.Telh);
		setTelw(result.data.Telw);
		setAge(result.data.Age);
		setDob(result.data.Dob);
		setAid(result.data.Id);
	  })
      .catch((error: any) => {
	     setIsError(true)
		 if (error.response) {			
		   setErrorText(error.response.data.summary);
		 }
		 else if (error.request) {
		   setErrorText(error.request);
		 } 
		 else {
		   setErrorText(error.message);
		 }
	  })
      .finally(() => setIsLoading(false))
  };

   const newAdbk = (e: any) => {

     setName("");
     setZipcode("");
     setAddress("");
     setTelh("");
     setTelw("");
     setAge("");
     setDob("");
     setAid("");
     
  };
    
   const deleteAdbk = (e: any) => {

	setIsLoading(true);
	setIsError(false);
	
	let id = aid;

	axios
	  .delete<any>(`http://${ServerAddress}:${ServerPort}/api/adbk/delete/${id}?IRISUsername=${Username}&IRISPassword=${Password}`)
      .catch((error: any) => {
	     setIsError(true)
		 if (error.response) {			
		   setErrorText(error.response.data.summary);
		 }
		 else if (error.request) {
		   setErrorText(error.request);
		 } 
		 else {
		   setErrorText(error.message);
		 }
	  })
      .finally(() => setIsLoading(false))
     
  };
    
   const saveAdbk = (e: any) => {

	setIsLoading(true);
	setIsError(false);
	
	if (aid === "")  {
	  const senddata: any =  "";
	  senddata.zip = zipcode;
	  senddata.address = address;
	  senddata.telh = telh;
	  senddata.telw = telw;
	  senddata.name = name;
	  
	  axios
	    .post<any>(`http://${ServerAddress}:${ServerPort}/api/adbk/create/?IRISUsername=${Username}&IRISPassword=${Password}`,senddata)
	   .then((result: any) => {
		  if (result.data.Error === "ok") {
		  	setIsError(false);
		  }
		  else {
		  	setIsError(true);
		    setErrorText(result.data.Error);
		  }
		  setAid(result.data.id);
	    })
        .catch((error: any) => {
	       setIsError(true)
		 if (error.response) {			
		   setErrorText(error.response.data.summary);
		 }
		 else if (error.request) {
		   setErrorText(error.request);
		 } 
		 else {
		   setErrorText(error.message);
		 }
	    })
        .finally(() => setIsLoading(false))
	}
	else {
	  const senddata: any =  "";
	  senddata.id = aid;
	  senddata.zip = zipcode;
	  senddata.address = address;
	  senddata.telh = telh;
	  senddata.telw = telw;
	  senddata.name = name;
	  
	  axios
	    .put<any>(`http://${ServerAddress}:${ServerPort}/api/adbk/modify?IRISUsername=${Username}&IRISPassword=${Password}`,senddata)
	   .then((result: any) => {
		  if (result.data.Error === "ok") {
		  	setIsError(false);
		  }
		  else {
		  	setIsError(true);
		    setErrorText(result.data.Error);
		  }
		  setAid(result.data.id);
	    })
        .catch((error: any) => {
	       setIsError(true)
		 if (error.response) {			
		   setErrorText(error.response.data.summary);
		 }
		 else if (error.request) {
		   setErrorText(error.request);
		 } 
		 else {
		   setErrorText(error.message);
		 }
	    })
        .finally(() => setIsLoading(false))
	}

     
  };

  return (
    <>
      <form>
      <div className="container">
      <div className="row">
      <div className="col-2" />
      <div className="col-1 align-items-start"><label className="h3">住所録</label></div>
      </div>
      <div className="row">
	  <div className="col-2  align-items-start"><label className="p-2">名前検索キーワード: </label></div>
	  <div className="col-1  align-items-start"><input type="text" value = {inputtext} onChange={onChangeText} /></div>
	  </div>
	  	  {isLoading ? (<div className="row"></div>)
		 : (
         <div className="row">
	     <div className="col-2 align-items-start"><label className="p-2">名前候補: </label></div>
		 <div className="col-1 align-items-start"><select size={5} name="namelist" id="namelist" onChange={onClickItem} style = {{float: "left",width: "150px"}} value={aid}>
		 {nameList.map((name: any) => (
        <option value={name.id}>{name.name} </option>
		 ))}</select></div></div>)
	  }
     <div className="row">
	  <div className="col-2 align-items-start"><label className="p-2">名前:  {name}</label></div>
	 </div>
     <div className="row">
	  <div className="col-2 align-items-start"><label className="p-2">郵便番号: </label></div>
	  <div className="col-1 align-items-start"><input type="text"  name="zipcode" value={zipcode}  onChange={onChangeZipcode}  style = {{float: "left"}} /></div>
	  </div>
	  <div className="row">
	  <div className="col-2 align-items-start"><label className="p-2">住所: </label></div>
	  <div className="col-1 align-items-start"><input type="text"  name="address" value={address} onChange={onChangeAddress}  style = {{float: "left", width: "300px"}} /></div>
	  </div>
	 <div className="row">
	  <div className="col-2 align-items-start"><label className="p-2">自宅Tel: </label></div>
	  <div className="col-1 align-items-start"><input type="text"   name="telh" value={telh} onChange={onChangeTelh} style = {{float: "left"}} /></div>
	  </div>
	  <div className="row">
	  <div className="col-2 align-items-start"><label className="p-2">会社Tel: </label></div>
	  <div className="col-1 align-items-start"><input type="text"   name="telw" value={telw} onChange={onChangeTelw} style = {{float: "left"}} /></div>
	  </div>
	  <div className="row">
	  <div className="col-2 align-items-start"><label className="p-2">年齢: </label></div>
	  <div className="col-1 align-items-start"><input type="text"   name="age" value={age} style = {{float: "left"}} /></div>
	  </div>
	  <div className="row">
	  <div className="col-2 align-items-start"><label className="p-2">生年月日: </label></div>
	  <div className="col-2 align-items-start"><input type="text"   name="dob" value={dob} onChange={onChangeDob}  /></div>
	  <div className="col-2 align-items-start"><label>YYYY-MM-DD</label></div>
	  </div>
	  <input type="hidden" id="id" name="id" value={aid} />
	  <div className="row">
	  <div className="col-2" />
	  <div className="col-2 align-items-start"><button type="submit" value="new" onClick={newAdbk}>新規</button>
	  <button type="submit" value="delete" onClick={deleteAdbk}>削除</button>
	  <button type="submit" value="save" onClick={saveAdbk}>登録／変更</button>
	  </div>
	  </div>
	  </div>
      </form>
    </>	
  );	
}
export default Adbk;
