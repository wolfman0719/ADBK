using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using InterSystems.Data.CacheTypes;


namespace ADBKP
{
    public partial class ADBKForm : Form
    {
        private ADBKDataModel adbkdm;

        public ADBKForm()
        {
            InitializeComponent();
        }

        private void ADBKForm_Load(object sender, EventArgs e)
        {
            adbkdm = new ADBKDataModel();
            adbkdm.init();

        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            adbkdm.close();
            Close();
        }

        private void AIDFindbutton_Click(object sender, EventArgs e)
        {
            adbkdm.searchbyid(AIDtextBox.Text);
            formupdate();
        }

        private void formupdate()
        {
            AIDtextBox.Text = adbkdm.id;
            ANAMEcomboBox.Text = adbkdm.Name;
            APHHOMETextBox.Text = adbkdm.HomePhone;
            AHWORKtextBox.Text = adbkdm.WorkPhone;
            AZIPtextBox.Text = adbkdm.ZipCode;
            ABTHDAYtextBox.Text = adbkdm.dob;
            AAGEtextBox.Text = adbkdm.Age.ToString();
            ASTREETtextBox.Text = adbkdm.Street;
        }

        private void datamodelupdatebyform()
        {
            adbkdm.Name = ANAMEcomboBox.Text;
            adbkdm.HomePhone = APHHOMETextBox.Text;
            adbkdm.WorkPhone = AHWORKtextBox.Text;
            adbkdm.ZipCode = AZIPtextBox.Text;
            adbkdm.dob = ABTHDAYtextBox.Text;
            adbkdm.Street = ASTREETtextBox.Text;
            if (adbkdm.City == null) adbkdm.City = "";
        }

        private void ANAMEFindbutton_Click(object sender, EventArgs e)
        {
            List<string> namelist;

            string name = ANAMEcomboBox.Text;
            ANAMEcomboBox.Text = "";
            ANAMEcomboBox.Items.Clear();
            namelist = adbkdm.searchbyname(name);
            if (namelist.Count > 0) {
                ANAMEcomboBox.Text = namelist[0].ToString();
            }

            foreach (string aname in namelist) {
                ANAMEcomboBox.Items.Add(aname);
            }
        }

        private void Clearbutton_Click(object sender, EventArgs e)
        {
            adbkdm.initializemodel();
            ANAMEcomboBox.Items.Clear();
            formupdate();
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {

            string id = adbkdm.id;

            datamodelupdatebyform();
            //êVãKìoò^ÇÃèÍçáÇ…ÇÕÅAidÇÕnull
            adbkdm.save(id);
            formupdate();
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {

            string id = adbkdm.id;

            if (adbkdm.delete(id) == true)
            {
                adbkdm.initializemodel();
                formupdate();
            }

        }

        private void ANAMEcomboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int sid = ANAMEcomboBox.SelectedIndex;

            adbkdm.searchbyid(adbkdm.idlist[sid]);
            formupdate();

        }
    }
}