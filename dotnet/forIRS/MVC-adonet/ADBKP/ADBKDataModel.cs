using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using InterSystems.Data.IRISClient;
//using InterSystems.Data.CacheClient;
//using InterSystems.Data.CacheClient.ObjBind;
//using InterSystems.Data.CacheTypes;

namespace ADBKP
{
    class ADBKDataModel
    {
        public ADBKDatasource adbksrc;
        public List<string> idlist = new List<string>();
        public Boolean newflag = true; //新規保存フラグ

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
            //adbksrc.connect("localhost", "1972", "_system", "SYS", "user");
            adbksrc.connect("localhost", "51773", "_system", "SYS", "user");
        }

        public void close()
        {
            adbksrc.conn.Close();
        }


        public void searchbyid(string id)
        {
            //CacheCommand cc;
            //CacheDataReader cr;
            IRISCommand ic;
            IRISDataReader ir;

            try
            {
                //cc = new CacheCommand("Select AID, ACITY, ANAME, ABTHDAY, ASTREET , APHHOME , APHWORK, AAGE, AZIP from ADBK WHERE AID = ?", adbksrc.conn);
                ic = new IRISCommand("Select AID, ACITY, ANAME, ABTHDAY, ASTREET , APHHOME , APHWORK, AAGE, AZIP from ADBK WHERE AID = ?", adbksrc.conn);

                //CacheParameter cp = new CacheParameter("id", CacheDbType.NVarChar);
                IRISParameter ip = new IRISParameter("id", IRISDbType.NVarChar);
                //cp.Value = id;
                //cc.Parameters.Add(cp);
                //cr = cc.ExecuteReader();
                //updatedatamodel(cr);

                ip.Value = id;
                ic.Parameters.Add(ip);
                ir = ic.ExecuteReader();
                updatedatamodel(ir);
            }
            catch (Exception err)
            {
                MessageBox.Show("seachbyid エラー " + err.Message);
            }
        }

        public List<string> searchbyname(string name)
        {
            //CacheCommand cc;
            IRISCommand ic;

            idlist.Clear();
            List<string> anamelist = new List<string>();
            try
            {
                //cc = new CacheCommand("Select AID, ANAME from ADBK WHERE ANAME %startswith ?", adbksrc.conn);
                //CacheParameter cp = new CacheParameter("Name", CacheDbType.NVarChar);
                //cp.Value = name;
                //cc.Parameters.Add(cp);
                //CacheDataReader reader = cc.ExecuteReader();
                ic = new IRISCommand("Select AID, ANAME from ADBK WHERE ANAME %startswith ?", adbksrc.conn);
                IRISParameter ip = new IRISParameter("Name", IRISDbType.NVarChar);
                ip.Value = name;
                ic.Parameters.Add(ip);
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
            catch (Exception err)
            {
                MessageBox.Show("searchbynameエラー " + err.Message);
                return anamelist;
            }
            //return anamelist;
        }

        //public void updatedatamodel(CacheDataReader reader) {
        public void updatedatamodel(IRISDataReader reader) {

            try
            {
                while (reader.Read())
                {
                    Age = (long) reader.GetInt32(reader.GetOrdinal("AAGE"));
                    City = reader[reader.GetOrdinal("ACITY")].ToString();
                    HomePhone = reader[reader.GetOrdinal("APHHOME")].ToString();
                    Name = reader[reader.GetOrdinal("ANAME")].ToString();
                    Street = reader[reader.GetOrdinal("ASTREET")].ToString();
                    WorkPhone = reader[reader.GetOrdinal("APHWORK")].ToString();
                    ZipCode = reader[reader.GetOrdinal("AZIP")].ToString();
                    dob = reader.GetDate(reader.GetOrdinal("ABTHDAY")).ToShortDateString();
                    id = reader[reader.GetOrdinal("AID")].ToString();
                    newflag = false;
                }
            }
            catch (Exception err)
            {
                //MessageBox.Show("CacheDataReaderエラー " + err.Message);
                MessageBox.Show("IRISDataReaderエラー " + err.Message);
            }

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
        }

        public void save(string id)
        {
            //CacheCommand cc;
            //CacheParameter cp;
            //CacheTransaction ctx;

            IRISCommand ic;
            IRISParameter ip;
            IRISTransaction itx;

            try
            {
                //ctx = adbksrc.conn.BeginTransaction(IsolationLevel.ReadCommitted);
                itx = adbksrc.conn.BeginTransaction(IsolationLevel.ReadCommitted);

                if (newflag == true)
                {
                    //cc = new CacheCommand("INSERT INTO ADBK (ANAME,ASTREET,APHHOME,APHWORK,AZIP,ABTHDAY) VALUES(?,?,?,?,?,?)", adbksrc.conn,ctx);

                    //cp = new CacheParameter("Name", CacheDbType.NVarChar);
                    //cp.Value = Name;
                    //cc.Parameters.Add(cp);
                    //cp = new CacheParameter("Street", CacheDbType.NVarChar);
                    //cp.Value = Street;
                    //cc.Parameters.Add(cp);
                    //cp = new CacheParameter("HomePhone", CacheDbType.NVarChar);
                    //cp.Value = HomePhone;
                    //cc.Parameters.Add(cp);
                    //cp = new CacheParameter("WorkPhone", CacheDbType.NVarChar);
                    //cp.Value = WorkPhone;
                    //cc.Parameters.Add(cp);
                    //cp = new CacheParameter("ZipCode", CacheDbType.NVarChar);
                    //cp.Value = ZipCode;
                    //cc.Parameters.Add(cp);
                    //cp = new CacheParameter("Dob", CacheDbType.Date);
                    //cp.Value = dob.ToString().Split(' ')[0].ToString();
                    //cc.Parameters.Add(cp);

                    ic = new IRISCommand("INSERT INTO ADBK (ANAME,ASTREET,APHHOME,APHWORK,AZIP,ABTHDAY) VALUES(?,?,?,?,?,?)", adbksrc.conn, itx);

                    ip = new IRISParameter("Name", IRISDbType.NVarChar);
                    ip.Value = Name;
                    ic.Parameters.Add(ip);
                    ip = new IRISParameter("Street", IRISDbType.NVarChar);
                    ip.Value = Street;
                    ic.Parameters.Add(ip);
                    ip = new IRISParameter("HomePhone", IRISDbType.NVarChar);
                    ip.Value = HomePhone;
                    ic.Parameters.Add(ip);
                    ip = new IRISParameter("WorkPhone", IRISDbType.NVarChar);
                    ip.Value = WorkPhone;
                    ic.Parameters.Add(ip);
                    ip = new IRISParameter("ZipCode", IRISDbType.NVarChar);
                    ip.Value = ZipCode;
                    ic.Parameters.Add(ip);
                    ip = new IRISParameter("Dob", IRISDbType.Date);
                    ip.Value = dob.ToString().Split(' ')[0].ToString();
                    ic.Parameters.Add(ip);

                }
                else {
                    /*
                    cc = new CacheCommand("UPDATE ADBK SET ANAME = ?,ASTREET = ?,APHHOME = ?,APHWORK = ?,AZIP = ?,ABTHDAY = ? WHERE AID = ?", adbksrc.conn,ctx);

                    cp = new CacheParameter("Name", CacheDbType.NVarChar);
                    cp.Value = Name;
                    cc.Parameters.Add(cp);
                    cp = new CacheParameter("Street", CacheDbType.NVarChar);
                    cp.Value = Street;
                    cc.Parameters.Add(cp);
                    cp = new CacheParameter("HomePhone", CacheDbType.NVarChar);
                    cp.Value = HomePhone;
                    cc.Parameters.Add(cp);
                    cp = new CacheParameter("WorkPhone", CacheDbType.NVarChar);
                    cp.Value = WorkPhone;
                    cc.Parameters.Add(cp);
                    cp = new CacheParameter("ZipCode", CacheDbType.NVarChar);
                    cp.Value = ZipCode;
                    cc.Parameters.Add(cp);
                    cp = new CacheParameter("Dob", CacheDbType.Date);
                    cp.Value = dob.ToString().Split(' ')[0].ToString();
                    cc.Parameters.Add(cp);
                    cp = new CacheParameter("id", CacheDbType.NVarChar);
                    cp.Value = id;
                    cc.Parameters.Add(cp);
                    */

                    ic = new IRISCommand("UPDATE ADBK SET ANAME = ?,ASTREET = ?,APHHOME = ?,APHWORK = ?,AZIP = ?,ABTHDAY = ? WHERE AID = ?", adbksrc.conn, itx);

                    ip = new IRISParameter("Name", IRISDbType.NVarChar);
                    ip.Value = Name;
                    ic.Parameters.Add(ip);
                    ip = new IRISParameter("Street", IRISDbType.NVarChar);
                    ip.Value = Street;
                    ic.Parameters.Add(ip);
                    ip = new IRISParameter("HomePhone", IRISDbType.NVarChar);
                    ip.Value = HomePhone;
                    ic.Parameters.Add(ip);
                    ip = new IRISParameter("WorkPhone", IRISDbType.NVarChar);
                    ip.Value = WorkPhone;
                    ic.Parameters.Add(ip);
                    ip = new IRISParameter("ZipCode", IRISDbType.NVarChar);
                    ip.Value = ZipCode;
                    ic.Parameters.Add(ip);
                    ip = new IRISParameter("Dob", IRISDbType.Date);
                    ip.Value = dob.ToString().Split(' ')[0].ToString();
                    ic.Parameters.Add(ip);
                    ip = new IRISParameter("id", IRISDbType.NVarChar);
                    ip.Value = id;
                    ic.Parameters.Add(ip);
                }

                //cc.ExecuteNonQuery();
                ic.ExecuteNonQuery();

                if (newflag == true)
                {
                    //cc = new CacheCommand("SELECT MAX(AID) FROM ADBK", adbksrc.conn,ctx);
                    //cc = new CacheCommand("SELECT LAST_IDENTITY() FROM ADBK", adbksrc.conn, ctx);
                    //CacheDataReader reader = cc.ExecuteReader();

                    ic = new IRISCommand("SELECT LAST_IDENTITY() FROM ADBK", adbksrc.conn, itx);
                    IRISDataReader reader = ic.ExecuteReader();

                    while (reader.Read())
                    {
                        string aid = reader[0].ToString();
                        id = aid;

                        //cc = new CacheCommand("Select AID, ACITY, ANAME, ABTHDAY, ASTREET , APHHOME , APHWORK, AAGE, AZIP from ADBK WHERE AID = ?", adbksrc.conn,ctx);

                        //CacheParameter cp2 = new CacheParameter("id", CacheDbType.NVarChar);
                        //cp2.Value = aid;
                        //cc.Parameters.Add(cp2);
                        //CacheDataReader cr = cc.ExecuteReader();
                        //updatedatamodel(cr);

                        ic = new IRISCommand("Select AID, ACITY, ANAME, ABTHDAY, ASTREET , APHHOME , APHWORK, AAGE, AZIP from ADBK WHERE AID = ?", adbksrc.conn, itx);

                        IRISParameter ip2 = new IRISParameter("id", IRISDbType.NVarChar);
                        ip2.Value = aid;
                        ic.Parameters.Add(ip2);
                        IRISDataReader ir = ic.ExecuteReader();
                        updatedatamodel(ir);
                    }
                }

                //ctx.Commit();
                itx.Commit();

            }
            catch (Exception err)
            {
                MessageBox.Show("保存エラー " + err.Message);
            }

        }

        public Boolean delete(string id)
        {
            //CacheCommand cc;
            IRISCommand ic;

            if (MessageBox.Show("削除しますか", "削除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    //cc = new CacheCommand("DELETE FROM ADBK WHERE AID = ?", adbksrc.conn);
                    //CacheParameter cp = new CacheParameter("id", CacheDbType.NVarChar);
                    //cp.Value = id;
                    //cc.Parameters.Add(cp);
                    //cc.ExecuteNonQuery();

                    ic = new IRISCommand("DELETE FROM ADBK WHERE AID = ?", adbksrc.conn);
                    IRISParameter ip = new IRISParameter("id", IRISDbType.NVarChar);
                    ip.Value = id;
                    ic.Parameters.Add(ip);
                    ic.ExecuteNonQuery();
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
