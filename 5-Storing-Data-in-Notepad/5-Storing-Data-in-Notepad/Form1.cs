using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5_Storing_Data_in_Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("phoneBook.txt"))
            {
                readData();
            }

            btnAdd.Enabled = false;
        }

        private void txtNameAndPhoneNum_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 1 && txtPhoneNum.Text.Length == 10)
            {
                btnAdd.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream("phoneBook.txt",FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(txtName.Text + "-" + txtPhoneNum.Text);
            streamWriter.Close();
            fileStream.Close();

            txtName.ResetText();
            txtPhoneNum.ResetText();
            readData();
        }

        void readData()
        {
            listBoxName.Items.Clear();
            listBoxPhoneNum.Items.Clear();

            string[] data = File.ReadAllLines("phoneBook.txt");

            for (int i = 0; i < data.Length; i++)
            {
               
                char[] ch = {'-'};
                string[] partOfData = data[i].Split(ch, StringSplitOptions.RemoveEmptyEntries);

                if (partOfData[0].Length>0 && partOfData[1].Length>0)
                {
                    listBoxName.Items.Add(partOfData[0].ToString());
                    listBoxPhoneNum.Items.Add(partOfData[1].ToString());
                }
                
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxPhoneNum.SelectedIndex = listBoxName.SelectedIndex;
        }

        private void listBoxPhoneNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxName.SelectedIndex = listBoxPhoneNum.SelectedIndex;
        }

    }
}
