import { ChangeEvent, useState } from "react";
import axios from "axios";

import configinfo from '../serverconfig.json';

const serverAddress = configinfo.ServerAddress;
const serverPort = configinfo.ServerPort;
const username = configinfo.Username;
const password = configinfo.Password;
const ApplicationName = configinfo.ApplicationName;

export const Adbk = (props: any) => {

  const [inputtext, setInputText] = useState("");
  const [nameList, setNameList] = useState<any>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [isError, setIsError] = useState(false);
  const [errorText, setErrorText] = useState("");
  const [name, setName] = useState<any>("");
  const [aid, setAid] = useState<number>(0);
  const [zipcode, setZipcode] = useState<any>("");
  const [address, setAddress] = useState<any>("");
  const [telh, setTelh] = useState<any>("");
  const [telw, setTelw] = useState<any>("");
  const [age, setAge] = useState<any>("");
  const [dob, setDob] = useState<any>("");
  const [visible, setVisible] = useState<any>("none");
  let listLength = 0;
  let firstitemid: any = 0;

  const onChangeZipcode = (e: ChangeEvent<HTMLInputElement>) => setZipcode(e.target.value);  
  const onChangeAddress = (e: ChangeEvent<HTMLInputElement>) => setAddress(e.target.value);  
  const onChangeTelh = (e: ChangeEvent<HTMLInputElement>) => setTelh(e.target.value);  
  const onChangeTelw = (e: ChangeEvent<HTMLInputElement>) => setTelw(e.target.value);  
  const onChangeDob = (e: ChangeEvent<HTMLInputElement>) => setDob(e.target.value);  

  const onChangeText = (e: ChangeEvent<HTMLInputElement>) => setInputText(e.target.value);

  const queryByName = (e: any) => {
	setIsLoading(true);
    setIsError(false);
    
    const tname = inputtext;
    
    if (tname === null || tname === "")
    {
      clearADBK();
 	  setVisible("none");
    }
    else {
	  axios
	    .get<any>(`http://${serverAddress}:${serverPort}/${ApplicationName}/listbyname/${tname}?IRISUsername=${username}&IRISPassword=${password}`)
	    .then((result: any) => {
	  	  const names = result.data.map((idname: any) => ({
		  id: idname.split(" ")[0],
		  name: idname.split(" ")[1]
        }));
        setNameList(names);
        listLength = names.length;
        if (names.length > 0) {
      	  firstitemid = names[0].id;
        }
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
        .finally(() => {
      	  setIsLoading(false)
          if (listLength > 0) {    
        	
 	        getADBKById(firstitemid);
 	        setVisible("");
          }
         else {
           clearADBK();
 	       setVisible("none");
         }
        });
     } 
  }

   const onClickItem = (e: any) => {
	
	const id = e.target.value;
	
	getADBKById(id);

  };

   const getADBKById = (id: any) => {
	
    axios
	  .get<any>(`http://${serverAddress}:${serverPort}/${ApplicationName}/getdatabyid/${id}?IRISUsername=${username}&IRISPassword=${password}`)
	  .then((result: any) => {
        setName(result.data.Name);
        setInputText(result.data.Name);
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
    clearADBK(); 
    setInputText("");
  };
  
   const clearADBK = () => {
     setName("");
     setZipcode("");
     setAddress("");
     setTelh("");
     setTelw("");
     setAge("");
     setDob("");
     setAid(0);
     setNameList([]);
 	 setVisible("none");
  };
    
   const deleteAdbk = (e: any) => {

	setIsLoading(true);
	setIsError(false);
	
	let id = aid;

	axios
	  .delete<any>(`http://${serverAddress}:${serverPort}/${ApplicationName}/delete/${id}?IRISUsername=${username}&IRISPassword=${password}`)
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

    clearADBK(); 
    setInputText("");    
     
  };
    
   const saveAdbk = (e: any) => {

	setIsLoading(true);
	setIsError(false);
	
	if (aid === 0)  {
	  const senddata: any =  {};
	  senddata.Zip = zipcode;
	  senddata.Address = address;
	  senddata.Telh = telh;
	  senddata.Telw = telw;
	  senddata.Name = inputtext;
	  senddata.DOB = dob;

	  axios
	    .post<any>(`http://${serverAddress}:${serverPort}/${ApplicationName}/create?IRISUsername=${username}&IRISPassword=${password}`,senddata)
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
	  const senddata: any =  {};
	  senddata.Id = aid;
	  senddata.Zip = zipcode;
	  senddata.Address = address;
	  senddata.Telh = telh;
	  senddata.Telw = telw;
	  senddata.Name = name;
	  senddata.DOB = dob;
	  
	  axios
	    .put<any>(`http://${serverAddress}:${serverPort}/${ApplicationName}/modify?IRISUsername=${username}&IRISPassword=${password}`,senddata)
	   .then((result: any) => {
	   	  // console.log("result = " + JSON.stringify(result, null, 2));
		  if (result.data.Error === "ok") {
		  	setIsError(false);
		    setAid(result.data.Id);
		  }
		  else {
		  	setIsError(true);
		    setErrorText(result.data.Error);
		  }
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
      <table>
      <tbody>
      <tr><td /><td><label className="h3">住所録</label></td><td /></tr>
	  <tr>
	  <td><label className="p-2">名前: </label></td>
	  <td><input type="text" value = {inputtext} onChange={onChangeText} style = {{float: "left"}}></input><button type="button" value="new" onClick={queryByName}  style = {{float: "left"}} >検索</button></td><td><label>*(アスタリスク)入力で全件検索</label></td>
	  </tr>
	 <tr>
	  <td /><td><select size={3} name="namelist" value={aid} onClick={onClickItem} style = {{float: "left", width: "180px",display: visible}}>
	  {isLoading ? (<option value="loading" key="loading"></option>)
	  : (nameList.map((name: any) => (
        <option value={name.id} key={name.id}>{name.name} </option>
       )))
	  }
     </select></td><td /></tr>
     <tr>
	 <td><label className="p-2">郵便番号: </label></td>
	 <td><input type="text"  name="zipcode" value={zipcode}  onChange={onChangeZipcode} style = {{float: "left"}} /></td><td />
	  </tr>
	  <tr>
	  <td><label className="p-2">住所: </label></td>
	  <td><input type="text"  name="address" value={address} onChange={onChangeAddress}  style = {{float: "left", width: "250px"}} /></td><td />
	  </tr>
	 <tr>
	  <td><label className="p-2">自宅Tel: </label></td>
	  <td><input type="text"   name="telh" value={telh} onChange={onChangeTelh} style = {{float: "left"}} /></td><td />
	  </tr>
	  <tr>
	  <td><label className="p-2">会社Tel: </label></td>
	  <td><input type="text"   name="telw" value={telw} onChange={onChangeTelw} style = {{float: "left"}} /></td><td />
	  </tr>
	  <tr>
	  <td><label className="p-2">年齢: </label></td>
	  <td><input type="text"   name="age" value={age} style = {{float: "left"}} /></td><td />
	  </tr>
	  <tr>
	  <td><label className="p-2">生年月日: </label></td>
	  <td><input type="text"   name="dob" value={dob} onChange={onChangeDob} />
	  <label>YYYY-MM-DD</label></td><td />
	 <td> <input type="hidden" id="id" name="id" value={aid} /></td>
	  </tr>
	  <tr>
	  <td />
	  <td><button type="button" value="new" onClick={newAdbk}  style = {{float: "left"}} >新規</button>
	  <button type="button" value="delete" onClick={deleteAdbk}  style = {{float: "left"}} >削除</button>
	  <button type="button" value="save" onClick={saveAdbk}  style = {{float: "left"}} >登録／変更</button>
	  </td><td />
	  </tr>
	 </tbody></table>
      </form>
	  {isError && <p style={{ color: "red" }}>エラーが発生しました　{`${errorText}`}</p>}
    </>	
  );	
}
export default Adbk;
