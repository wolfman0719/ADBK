using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using InterSystems.Data.IRISClient;

//using InterSystems.Data.CacheClient;
//using InterSystems.Data.CacheClient.ObjBind;
//using InterSystems.Data.CacheTypes;


namespace ADBKP
{
    class ADBKDatasource
    {
        //public CacheConnection conn;
        public IRISConnection conn;

        public void connect(String server, String port, String userid, String password, String nspace) {

            try
            {
                // Create a connection to Cache
                //conn = new CacheConnection();
                conn = new IRISConnection();

                //string cacheConnectString = "Server = " + server + "; Log File=cprovider.log;Port=" + port + "; Namespace=" + nspace + "; Password = " + password + ";User ID = " + userid + ";";
                string IRISConnectString = "Server = " + server + "; Log File=cprovider.log;Port=" + port + "; Namespace=" + nspace + "; Password = " + password + ";User ID = " + userid + ";";
                // Cache server Connection Information
                //conn.ConnectionString = cacheConnectString;
                conn.ConnectionString = IRISConnectString;
                //Open a Connection to Cache
                //Open a Connection to IRIS
                conn.Open();
            }

            catch (Exception err)
            {
                 MessageBox.Show("ERROR: " + err.Message);
            }
        }
        public void close()
        {
            conn.Close();
        }
  }
}
