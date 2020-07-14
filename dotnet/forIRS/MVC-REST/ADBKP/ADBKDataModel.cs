using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

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
        public string Age;

        public string dob = "";
        public string id = "";

        public void init()
        {
        }

        public void close()
        {
        }

        public void searchbyid(string aid)
        {

            try
            {

                string url = string.Format("http://localhost:52773/ADBK/getdatabyid/{0}", aid);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET";
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                Stream s = res.GetResponseStream();
                StreamReader sr = new StreamReader(s);
                string content = sr.ReadToEnd();
                adbksrc = JsonConvert.DeserializeObject<ADBKDatasource>(content);

                if (adbksrc.Error != "ok")
                    {
                        MessageBox.Show(adbksrc.Error);
                        return;
                }

                updatedatamodel(adbksrc);

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

            string url = string.Format("http://localhost:52773/ADBK/listbyname/{0}", name);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            Stream s = res.GetResponseStream();
            StreamReader sr = new StreamReader(s);
            string content = sr.ReadToEnd();
            string[] Namelist = JsonConvert.DeserializeObject<string[]>(content);

            for (int i=1; i<Namelist.Count(); i++)
            {
                id = Namelist[i].Split(' ')[0].ToString();

                if (id == "no") break;
                string aname = Namelist[i].Split(' ')[1].ToString();
                anamelist.Add(aname);
                idlist.Add(id);

            }
            return anamelist;
        }
      

        public void updatedatamodel(ADBKDatasource adbk)
        {
            Name = adbk.Name;

            Street = adbk.Address;

            City = adbk.City;

            ZipCode = adbk.Zip;

            dob = adbk.Dob;

            HomePhone = adbk.Telh;

            WorkPhone = adbk.Telw;


            Age = adbk.Age.ToString();

            id = adbk.Id.ToString();
            newflag = false;
      
        }

        public void initializemodel()
        {
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

        public void save(int id)
        {
           
            ADBKDatasource adbk = new ADBKDatasource();
            string newid = "";
            HttpWebRequest req;
            try
            {
                adbk.Name = Name;
                adbk.Id = id;
                adbk.Address = Street;
                adbk.City = City;
                adbk.Zip = ZipCode;
                adbk.Dob = dob;
                adbk.Telh = HomePhone;
                adbk.Telw = WorkPhone;

                string postData = JsonConvert.SerializeObject(adbk);

                if (newflag == true) {

                     req = (HttpWebRequest)WebRequest.Create("http://localhost:52773/ADBK/create");
                     req.Method = "POST";
                }
                else
                {
                    req = (HttpWebRequest)WebRequest.Create("http://localhost:52773/ADBK/modify");
                    req.Method = "PUT";
                }

                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                req.ContentType = "application/json";
                req.ContentLength = byteArray.Length;
                Stream dataStream = req.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                Stream s = res.GetResponseStream();
                StreamReader sr = new StreamReader(s);
                string content = sr.ReadToEnd();
                adbksrc = JsonConvert.DeserializeObject<ADBKDatasource>(content);

                if (adbksrc.Error != "ok")
                {
                    MessageBox.Show("更新エラー " + adbksrc.Error);
                    return;
                }

                if (newflag == true)
                {
                    newid = adbksrc.Id.ToString();
                    searchbyid(newid);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("保存エラー " + err.Message);
            }
            
        }

    
    public Boolean delete(string id)
    {
            string url = string.Format("http://localhost:52773/ADBK/delete/{0}", id);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "DELETE";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            Stream s = res.GetResponseStream();
            StreamReader sr = new StreamReader(s);
            string content = sr.ReadToEnd();
            adbksrc = JsonConvert.DeserializeObject<ADBKDatasource>(content);

            if (adbksrc.Error != "ok")
            {
                MessageBox.Show(adbksrc.Error);
                return false;
            }

            return true;
        
    }
    

}
}
