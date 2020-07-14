using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using Newtonsoft.Json;



namespace ADBKP
{
    class ADBKDatasource
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Dob { get; set; }
        public int Age { get; set; }
        public string Telh { get; set; }
        public string Telw { get; set; }
        public string Error { get; set; }

    }

}
