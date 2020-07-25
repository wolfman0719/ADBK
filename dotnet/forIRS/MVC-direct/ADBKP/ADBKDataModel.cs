using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using InterSystems.Data.IRISClient;
using InterSystems.Data.IRISClient.ADO;
using System.Diagnostics.SymbolStore;
//using InterSystems.Data.CacheClient;
//using InterSystems.Data.CacheClient.ObjBind;
//using InterSystems.Data.CacheTypes;

namespace ADBKP
{
    class ADBKDataModel
    {
        public ADBKDatasource adbksrc;
        public List<string> idlist = new List<string>();
        public bool newflag = true; //新規保存フラグ

        public string Name = "";
        public string ZipCode = "";
        public string Street = "";
        public string City = "";
        public string HomePhone = "";
        public string WorkPhone = "";
        // public long Age;
        public string Age;

        public string dob = "";
        public string id = "";
        IRIS iris;

        public void init()
        {
            adbksrc = new ADBKDatasource();
            configconn consetup = new configconn();
            //adbksrc.connect("localhost", "1972", "_system", "SYS", "user");
            consetup.LoadSetupFile("..\\connectioninfo.json");
            adbksrc.connect(consetup.co.hostname, consetup.co.port.ToString(), consetup.co.username, consetup.co.password, consetup.co.irisnamespace);

            iris = IRIS.CreateIRIS(adbksrc.conn);
        }

        public void close()
        {
            adbksrc.conn.Close();
        }

        public void searchbyid(string aid)
        {

            try
            {

                //CacheSysList adbk = User.ADBK.GetInstanceById(adbksrc.conn,id);
                IRISList adbk = (IRISList)iris.ClassMethodIRISList("User.ADBK", "GetInstanceById",aid);

                //CacheSysList adbk = User.ADBK.GetInstanceById(adbksrc.conn,id);

                //if (adbk.Count == 1)
                if (adbk.Count() == 1)
                    {
                        MessageBox.Show("インスタンスオープンエラー idが存在しません");
                    return;
                }

                updatedatamodel(adbk);

            }
            catch (Exception err)
            {
                MessageBox.Show("インスタンスオープンエラー " + err.Message);
            }
        }

        public List<string> searchbyname(string name)
        {
            idlist.Clear();
            List<string> anamelist = new List<string>();
            //CacheSysList list = User.ADBK.ListByName(adbksrc.conn,name);
            IRISList list = (IRISList)iris.ClassMethodIRISList("User.ADBK", "ListByName", name);

            //for (int i = 0; i < list.Count; i++)
            for (int i=1; i<list.Count(); i++)
            {
                //reader.MoveNext();
                //string id = reader.Current.ToString().Split(' ')[0].ToString();
                if (list.Get(i).GetType() == typeof(string)) {

                    id = list.Get(i).ToString().Split(' ')[0].ToString();
                }
                else
                {
                    id = System.Text.Encoding.ASCII.GetString((byte[])list.Get(i)).Split(' ')[0].ToString();

                }

                if (id == "no") break;
                //string aname = reader.Current.ToString().Split(' ')[1].ToString();
                string aname = list.Get(i).ToString().Split(' ')[1].ToString();
                anamelist.Add(aname);
                idlist.Add(id);

            }
            return anamelist;
        }

        //public void updatedatamodel(CacheSysList adbk)
        public void updatedatamodel(IRISList adbk)
        {
            //int rs;
            //CacheSysListReader reader = (CacheSysListReader) adbk.GetEnumerator();

            //reader.MoveNext();
            //reader.MoveNext();
            //Name = reader.Current.ToString();
            Name = adbk.Get(2).ToString();

            //reader.MoveNext();
            //if (reader.Current != null) Street = reader.Current.ToString();
            //else Street = "";
            Street = adbk.Get(3).ToString();

            //reader.MoveNext();
            //if (reader.Current != null) City = reader.Current.ToString();
            //else City = "";
            City =System.Text.Encoding.ASCII.GetString((byte[])adbk.Get(4));

            //reader.MoveNext();

            //if (reader.Current != null) ZipCode = reader.Current.ToString();
            //else ZipCode = "";
            ZipCode = System.Text.Encoding.ASCII.GetString((byte[])adbk.Get(5));

            //reader.MoveNext();
            //if (reader.Current != null) dob = reader.Current.ToString();
            //else dob = "";
            dob = System.Text.Encoding.ASCII.GetString((byte[])adbk.Get(6));

            //reader.MoveNext();
            //if (reader.Current != null) HomePhone = reader.Current.ToString();
            //else HomePhone = "";
            HomePhone = System.Text.Encoding.ASCII.GetString((byte[])adbk.Get(7));

            //reader.MoveNext();
            //if (reader.Current != null) WorkPhone = reader.Current.ToString();
            //else WorkPhone = "";
            WorkPhone = System.Text.Encoding.ASCII.GetString((byte[])adbk.Get(8));


            //reader.MoveNext();
            //reader.MoveNext();
            //bool sts = int.TryParse(reader.Current.ToString(), out rs);
            Age = adbk.Get(10).ToString();

            //reader.MoveNext();
            //id = reader.Current.ToString();
            id = System.Text.Encoding.ASCII.GetString((byte[])adbk.Get(11));
            newflag = false;

            
        }

        public void initializemodel()
        {
            //Age = 0;
            Age = "";
            City = "";
            HomePhone = "";
            Name = "";
            Street = "";
            WorkPhone = "";
            ZipCode = "";
            dob = "";
            id = "";
            newflag = true;
        }

        public void save(string id)
        {
            //CacheSysList adbk;
            IRISList adbk;
            string newid = "";
            string errormessage = "";
            string aparams;
            try
            {
                //adbk = new CacheSysList(Encoding.Unicode,true);
                adbk = new IRISList();
                //adbk.Add(id.ToString());
                //adbk.Add(Name.ToString());
                //adbk.Add(Street.ToString());
                //adbk.Add(City.ToString());
                //adbk.Add(ZipCode.ToString());
                //adbk.Add(dob.ToString());
                //adbk.Add(HomePhone.ToString());
                //adbk.Add(WorkPhone.ToString());

                aparams = id.ToString() + (char)(1) + Name.ToString() + (char)1 + Street.ToString();
                aparams = aparams + (char)1 + City.ToString() + (char)1 + ZipCode.ToString();
                aparams = aparams + (char)1 + dob.ToString() + (char)1 + HomePhone.ToString();
                aparams = aparams + (char)1 + WorkPhone.ToString()+ (char)1 + newflag.ToString();
                //bool? status = User.ADBK.File(adbksrc.conn,adbk,newflag,ref errormessage,ref newid);
                IRISList result = (IRISList)iris.ClassMethodIRISList("User.ADBK", "FileWapper",aparams);
                errormessage = result.Get(1).ToString();
                newid = result.Get(2).ToString();
                //if (status == false)
                //if (errormessage != "ok")
                if (errormessage != "成功")
                {
                        MessageBox.Show("更新エラー " + errormessage);
                    return;
                }

                if (newflag == true)
                {
                    //adbk = User.ADBK.GetInstanceById(adbksrc.conn, newid);
                    adbk = (IRISList)iris.ClassMethodIRISList("User.ADBK", "GetInstanceById", newid);


                    //if (adbk.Count == 1)
                    if (adbk.Count() == 1)
                    {
                        MessageBox.Show("インスタンスオープンエラー idが存在しません");
                        return;
                    }

                    updatedatamodel(adbk);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("保存エラー " + err.Message);
            }

        }

        public Boolean delete(string id)
        {
            string errormessage = "";

            if (MessageBox.Show("削除しますか", "削除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    //bool? status = User.ADBK.DeleteById(adbksrc.conn,id,ref errormessage);
                    IRISList result = (IRISList)iris.ClassMethodIRISList("User.ADBK", "DeleteById", id);
                    int statusvalue = (int)result.Get(1);
                    Boolean status = Convert.ToBoolean(statusvalue);
                    errormessage = result.Get(2).ToString();
                    if (status == false)
                    {
                        MessageBox.Show("削除エラー " + errormessage);
                        return false;
                    }
                    return true;
                }
                catch (Exception err)
                {
                    MessageBox.Show("削除エラー" + err.Message);
                    return false;
                }
            }
            return false;
        }

    }
}
