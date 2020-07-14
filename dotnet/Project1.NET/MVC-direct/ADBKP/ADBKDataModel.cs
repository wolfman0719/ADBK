using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using InterSystems.Data.CacheClient;
using InterSystems.Data.CacheClient.ObjBind;
using InterSystems.Data.CacheTypes;

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
        public long Age;
        public string dob = "";
        public string id = "";

        public void init()
        {
            adbksrc = new ADBKDatasource();
            adbksrc.connect("localhost", "1972", "_system", "SYS", "user");
        }

        public void close()
        {
            adbksrc.conn.Close();
        }

        public void searchbyid(string id)
        {

            try
            {

                CacheSysList adbk = User.ADBK.GetInstanceById(adbksrc.conn,id);

                if (adbk.Count == 1)
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
            CacheSysList list = User.ADBK.ListByName(adbksrc.conn,name);

            CacheSysListReader reader = (CacheSysListReader)list.GetEnumerator();

            for (int i=0; i<list.Count; i++)
            {
                reader.MoveNext();
                string id = reader.Current.ToString().Split(' ')[0].ToString();
                if (id == "no") break;
                string aname = reader.Current.ToString().Split(' ')[1].ToString();
                anamelist.Add(aname);
                idlist.Add(id);

            }
            return anamelist;
        }

        public void updatedatamodel(CacheSysList adbk)
        {
            int rs;
            CacheSysListReader reader = (CacheSysListReader) adbk.GetEnumerator();

            reader.MoveNext();
            reader.MoveNext();
            Name = reader.Current.ToString();

            reader.MoveNext();
            if (reader.Current != null) Street = reader.Current.ToString();
            else Street = "";

            reader.MoveNext();
            if (reader.Current != null) City = reader.Current.ToString();
            else City = "";

            reader.MoveNext();

            if (reader.Current != null) ZipCode = reader.Current.ToString();
            else ZipCode = "";

            reader.MoveNext();
            if (reader.Current != null) dob = reader.Current.ToString();
            else dob = "";

            reader.MoveNext();
            if (reader.Current != null) HomePhone = reader.Current.ToString();
            else HomePhone = "";
            reader.MoveNext();
            if (reader.Current != null) WorkPhone = reader.Current.ToString();
            else WorkPhone = "";
            reader.MoveNext();
            reader.MoveNext();
            bool sts = int.TryParse(reader.Current.ToString(), out rs);
            Age = rs;

            reader.MoveNext();
            id = reader.Current.ToString();
            newflag = false;


        }

        public void initializemodel()
        {
            Age = 0;
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
            CacheSysList adbk;
            string newid = "";
            string errormessage = "";
            try
            {
                adbk = new CacheSysList(Encoding.Unicode,true);
                adbk.Add(id.ToString());
                adbk.Add(Name.ToString());
                adbk.Add(Street.ToString());
                adbk.Add(City.ToString());
                adbk.Add(ZipCode.ToString());
                adbk.Add(dob.ToString());
                adbk.Add(HomePhone.ToString());
                adbk.Add(WorkPhone.ToString());


                bool? status = User.ADBK.File(adbksrc.conn,adbk,newflag,ref errormessage,ref newid);

                if (status == false)
                {
                    MessageBox.Show("更新エラー " + errormessage);
                    return;
                }

                if (newflag == true)
                {
                    adbk = User.ADBK.GetInstanceById(adbksrc.conn, newid);

                    if (adbk.Count == 1)
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
                    bool? status = User.ADBK.DeleteById(adbksrc.conn,id,ref errormessage);
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
