using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;

namespace Equipment_Manager
{
    public partial class frmServerSet : Form
    {
        public frmServerSet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetAppConfigKey("con", "Data Source=" + this.textBox1.Text + "; User ID=" + this.textBox2.Text + "; Password=" + this.textBox3.Text + "; Initial Catalog=EqKeeper");
            SetAppConfigKey("restore", "Data Source=" + this.textBox1.Text + "; User ID=" + this.textBox2.Text + "; Password=" + this.textBox3.Text + "; Initial Catalog=master");
            SetAppConfigName("Equipment_Manager.Properties.Settings.Equipment_ManageConnectionString", "Data Source=" + this.textBox1.Text + "; User ID=" + this.textBox2.Text + "; Password=" + this.textBox3.Text + "; Initial Catalog=EqKeeper");
            Application.Restart();
            //this.Close();
        }
        private void SetAppConfigKey(string appKey, string appValue)
        {

            XmlDocument doc = new XmlDocument();

            doc.Load(Application.ExecutablePath + ".config");
            XmlNode node = doc.SelectSingleNode(@"//add[@key='" + appKey + "']"); // 定位到add节点       
            XmlElement element = (XmlElement)node;
            element.SetAttribute("value", appValue);

            // 赋值  
            doc.Save(Application.ExecutablePath + ".config");

        }
        private void SetAppConfigName(string appKey, string appValue)
        {

            XmlDocument doc = new XmlDocument();

            doc.Load(Application.ExecutablePath + ".config");
            XmlNode node = doc.SelectSingleNode(@"//add[@name='" + appKey + "']"); // 定位到add节点       
            XmlElement element = (XmlElement)node;
            element.SetAttribute("connectionString", appValue);

            // 赋值  
            doc.Save(Application.ExecutablePath + ".config");
        }
    }
}
