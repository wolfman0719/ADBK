import {React, FormEventHandler }  from 'react';
import { ChangeEvent, useState } from "react";

const handleSubmit: FormEventHandler<HTMLFormElement> = (event) => {
  event.preventDefault();

  const submitButton = e.nativeEvent.submitter?.name
  if (submitButton === "new") {
    location.href = "foo"
    return
  }
  if (submitButton === "delete") {
    location.href = "bar"
    return 
  }
  if (submitButton === "save") {
    location.href = "bar"
    return 
  }
  const { value: firstName } = (event.target as any).firstName;
  const { value: lastName } = (event.target as any).lastName;
  alert(`FirstName: ${firstName}\nLastName: ${lastName}`);
};

export const Adbk = (props: any) => {

  const {onClickFetchTopicList, onClickItem} = props;
  const [inputtext, setInputText] = useState<any>("");
  const [inputtext2, setInputText2] = useState<any>("");
    
  const onChangeText = (e: ChangeEvent<HTMLInputElement>) => setInputText(e.target.value);
  const onChangeText2 = (e: ChangeEvent<HTMLInputElement>) => setInputText2(e.target.value);
    
  return (
    <>
      <form onSubmit={handleSubmit}>
	  <label>住所録: </label>
      <table>
      <tr>
	  <td><label className="p-2">名前: </label></td>
	  <td><input type="text" value = {inputtext} onChange={onChangeText} /></td>
	  </tr>
	  <tr>
	  <td><label className="p-2">郵便番号: </label></td>
	  <td><input type="text"  name="zipcode" defaultValue=""  /></td>
	  </tr>
	  <tr>
	  <td><label className="p-2">住所: </label></td>
	  <td><input type="text"  name="address" defaultValue=""  /></td>
	  <tr>
	  <td><label className="p-2">自宅Tel: </label></td>
	  <td><input type="text"   name="ptel" defaultValue="" /></td>
	  </tr>
	  <tr>
	  <td><label className="p-2">会社Tel: </label></td>
	  <td><input type="text"   name="ctel" defaultValue="" /></td>
	  </tr>
	  <tr>
	  <td><label className="p-2">年齢: </label></td>
	  <td><input type="text"   name="age" defaultValue="" /></td>
	  </tr>
	  <tr>
	  <td><label className="p-2">生年月日: </label></td>
	  <td><input type="text"   name="dob" defaultValue="" /></td>
	  <td><label>YYYY -MM-DD</label></td>
	  </tr>
	  <tr>
	  <td><input type="submit" value="new">新規</button></td>
	  <td><input type="submit" value="delete">削除</button></td>
	  <td><input type="submit" value="save">登録／変更</button></td>
	  </tr>
      </form>
    </>	
  );	
}
export default Adbk;
