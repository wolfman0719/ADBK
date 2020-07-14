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
        public Boolean newflag = true; //�V�K�ۑ��t���O

        public string Name;
        public string ZipCode;
        public string Street;
        public string City;
        public string HomePhone;
        public string WorkPhone;
        public long Age;
        public string dob;
        public string id;

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
            User.ADBK adbk;

            try
            {

                adbk = User.ADBK.OpenId(adbksrc.conn, id);

                if (adbk == null)
                {
                    MessageBox.Show("�C���X�^���X�I�[�v���G���[ id�����݂��܂���");
                    return;
                }

                updatedatamodel(adbk);
                adbk.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("�C���X�^���X�I�[�v���G���[ " + err.Message);
            }
        }

        public List<string> searchbyname(string name)
        {
            idlist.Clear();
            List<string> anamelist = new List<string>();
            CacheCommand cc = User.ADBK.ByName(adbksrc.conn);
            CacheParameter cp = new CacheParameter("Name", CacheDbType.NVarChar);
            cp.Value = name;
            cc.Parameters.Add(cp);

            CacheDataReader reader = cc.ExecuteReader();

            while (reader.Read())
            {
                string id = reader[reader.GetOrdinal("AID")].ToString();
                string aname = reader[reader.GetOrdinal("ANAME")].ToString();
                anamelist.Add(aname);
                idlist.Add(id);

            }
            return anamelist;
        }

        public void updatedatamodel(User.ADBK adbk)
        {

            Age = (long)adbk.AAGE.Value;
            City = adbk.ACITY;
            HomePhone = adbk.APHHOME;
            Name = adbk.ANAME;
            Street = adbk.ASTREET;
            WorkPhone = adbk.APHWORK;
            ZipCode = adbk.AZIP;
            dob = adbk.ABTHDAY.Value.ToShortDateString();
            id = adbk.Id();
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
            User.ADBK adbk;
            try
            {
                if (newflag == true)
                {
                    adbk = new User.ADBK(adbksrc.conn);
                }
                else
                {
                    adbk = User.ADBK.OpenId(adbksrc.conn, id);
                }

                adbk.ACITY = City;
                adbk.APHHOME = HomePhone;
                adbk.ANAME = Name;
                adbk.ASTREET = Street;
                adbk.APHWORK = WorkPhone;
                adbk.AZIP = ZipCode;
                adbk.ABTHDAY = CacheDate.Parse(dob.ToString());
                CacheStatus sts = adbk.Save();

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


            }
            catch (Exception err)
            {
                MessageBox.Show("�ۑ��G���[ " + err.Message);
            }

        }

        public Boolean delete(string id)
        {

            if (MessageBox.Show("�폜���܂���", "�폜", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    CacheStatus sts = User.ADBK.DeleteId(adbksrc.conn, id);
                    if (sts.IsOK)
                    {
                        return true;
                    }
                    else
                    {
                        Exception uerr = new Exception(sts.Message);
                        throw uerr;
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("�폜�G���[" + err.Message);
                    return false;
                }
            }
            return false;
        }

    }
}
