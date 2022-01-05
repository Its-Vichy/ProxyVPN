using System.Collections.Generic;
using System.Windows.Forms;
using RapeCordd.Module;
using System;
using System.IO;

namespace RapeCordd
{
    public partial class Form1 : Form
    {
        public bool active;
        public static List<string> proxy_list;

        public Form1()
        {
            InitializeComponent();
            Proxy.setProxy("", false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a proxy !");
                return;
            }

            string proxy = guna2ComboBox1.SelectedItem.ToString();

            if (!active)
            {
                active = true;
                Proxy.setProxy(proxy, active);
                guna2Button3.Text = "Disconnect";
            }
            else
            {
                active = false;
                Proxy.setProxy("", active);
                guna2Button3.Text = "Connect";
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text = "";
            var fileContent = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
        
            foreach(string proxy in fileContent.Split('\n'))
            {
                guna2TextBox1.AppendText(proxy);
                guna2ComboBox1.Items.Add(proxy);
            }

            MessageBox.Show($"Load {guna2ComboBox1.Items.Count} proxies !");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Soon :)\nhttps://github.com/its-vichy");
        }
    }
}