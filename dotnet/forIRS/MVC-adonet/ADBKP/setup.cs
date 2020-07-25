using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ADBKP

{
    public class configconn
    {
        public connectioninfo co = new connectioninfo();

        public void LoadSetupFile(string jsonFilePath)
        {
            Encoding enc = Encoding.UTF8;
            string jsonStr;
            System.IO.StreamReader sr = new System.IO.StreamReader(jsonFilePath, enc);
            jsonStr = sr.ReadToEnd();

            co = JsonConvert.DeserializeObject<connectioninfo>(jsonStr);

        }
    }

    public class connectioninfo
    {
        public string hostname { get; set; }
        public int port { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string irisnamespace { get; set; }

    }
}
