using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
//using InterSystems.Data.CacheClient;
//using InterSystems.Data.CacheClient.ObjBind;
//using InterSystems.Data.CacheTypes;
using InterSystems.Data.IRISClient;
using InterSystems.Data.IRISClient.ADO;

namespace ADBKP
{
    class ADBKDataModel
    {
        public ADBKDatasource adbksrc;
        public List<string> idlist = new List<string>();
        public Boolean newflag = true; //新規保存フラグ

        public string Name;
        public string ZipCode;
        public string Street;
        public string City;
        public string HomePhone;
        public string WorkPhone;
        public long Age;
        public string dob;
        public string id;
        public IRIS iris;

        public void init()
        {
            adbksrc = new ADBKDatasource();
            //adbksrc.connect("localhost", "1972", "_system", "SYS", "user");
            configconn consetup = new configconn();
            consetup.LoadSetupFile("..\\connectioninfo.json");
            adbksrc.connect(consetup.co.hostname, consetup.co.port.ToString(), consetup.co.username, consetup.co.password, consetup.co.irisnamespace);
            iris = IRIS.CreateIRIS(adbksrc.conn);

        }

        public void close()
        {
            adbksrc.conn.Close();
        }

        public void searchbyid(string id)
        {
            //User.ADBK adbk;
            IRISObject adbk;

            try
            {

                //adbk = User.ADBK.OpenId(adbksrc.conn, id);
                adbk = (IRISObject)iris.ClassMethodObject("User.ADBK", "%OpenId",id);


                if (adbk == null)
                {
                    MessageBox.Show("インスタンスオープンエラー idが存在しません");
                    return;
                }

                newflag = false;
                updatedatamodel(adbk);
                //adbk.Close();
                adbk.Dispose();
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
            //CacheCommand cc = User.ADBK.ByName(adbksrc.conn);
            //CacheParameter cp = new CacheParameter("Name", CacheDbType.NVarChar);
            //cp.Value = name;
            //cc.Parameters.Add(cp);

            string SQLtext = "call sqluser.ADBK_byname(?)";
            IRISCommand ic = new IRISCommand(SQLtext, adbksrc.conn);
            IRISParameter ip = new IRISParameter("Name", IRISDbType.NVarChar);
            ip.Value = name;
            ic.Parameters.Add(ip);

            //CacheDataReader reader = cc.ExecuteReader();
            IRISDataReader reader = ic.ExecuteReader();

            while (reader.Read())
            {
                string id = reader[reader.GetOrdinal("AID")].ToString();
                string aname = reader[reader.GetOrdinal("ANAME")].ToString();
                anamelist.Add(aname);
                idlist.Add(id);

            }
            return anamelist;
        }

        //public void updatedatamodel(User.ADBK adbk)
        public void updatedatamodel(IRISObject adbk)
        {

            //Age = (long)adbk.AAGE.Value;
            //City = adbk.ACITY;
            //HomePhone = adbk.APHHOME;
            //Name = adbk.ANAME;
            //Street = adbk.ASTREET;
            //WorkPhone = adbk.APHWORK;
            //ZipCode = adbk.AZIP;
            //dob = adbk.ABTHDAY.Value.ToShortDateString();
            //id = adbk.Id();

            Age = (long)adbk.Get("AAGE");
            City = (string)adbk.Get("ACITY");
            HomePhone = (string)adbk.Get("APHHOME");
            Name = (string)adbk.Get("ANAME");
            Street = (string)adbk.Get("ASTREET");
            WorkPhone = (string)adbk.Get("APHWORK");
            ZipCode = (string)adbk.Get("AZIP");
            if (newflag == true) {
                long dobi;
                dobi = (long)adbk.Get("ABTHDAY");
                dob = adbk.InvokeString("ABTHDAYLogicalToOdbc", dobi.ToString());
            }
            else {
                dob = (string)adbk.Get("ABTHDAY");
                dob = adbk.InvokeString("ABTHDAYLogicalToOdbc", dob.ToString());
            }
            id = adbk.InvokeString("%Id");

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
            //User.ADBK adbk;
            IRISObject adbk;
            try
            {
                if (newflag == true)
                {
                    //adbk = new User.ADBK(adbksrc.conn);
                    adbk = (IRISObject)iris.ClassMethodObject("User.ADBK", "%New");
                }
                else
                {
                    //adbk = User.ADBK.OpenId(adbksrc.conn, id);
                    adbk = (IRISObject)iris.ClassMethodObject("User.ADBK", "%OpenId", id);
                }

                //adbk.ACITY = City;
                //adbk.APHHOME = HomePhone;
                //adbk.ANAME = Name;
                //adbk.ASTREET = Street;
                //adbk.APHWORK = WorkPhone;
                //adbk.AZIP = ZipCode;
                //adbk.ABTHDAY = CacheDate.Parse(dob.ToString());
                //CacheStatus sts = adbk.Save();

                adbk.Set("ACITY",City);
                adbk.Set("APHHOME",HomePhone);
                adbk.Set("ANAME",Name);
                adbk.Set("ASTREET",Street);
                adbk.Set("APHWORK",WorkPhone);
                adbk.Set("AZIP",ZipCode);
                dob = adbk.InvokeString("ABTHDAYOdbcToLogical", dob);
                adbk.Set("ABTHDAY",dob.ToString());
                adbk.InvokeIRISStatusCode("%Save");

                if (newflag == true)
                {
                    updatedatamodel(adbk);
                }

                /*
                if (sts.IsOK)
                {
                    if (newflag == true)
                    {
                        updatedatamodel(adbk);
                    }
                }
                else
                {
                    Exception uerr = new Exception(sts.Message);
                    throw uerr;
                }
                */


            }
            catch (Exception err)
            {
                MessageBox.Show("保存エラー " + err.Message);
            }

        }

        public Boolean delete(string id)
        {

            if (MessageBox.Show("削除しますか", "削除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    //CacheStatus sts = User.ADBK.DeleteId(adbksrc.conn, id);
                    iris.ClassMethodStatusCode("User.ADBK","%DeleteId", id);

                    /*
                    if (sts.IsOK)
                    {
                        return true;
                    }
                    else
                    {
                        Exception uerr = new Exception(sts.Message);
                        throw uerr;
                    }
                    */

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
