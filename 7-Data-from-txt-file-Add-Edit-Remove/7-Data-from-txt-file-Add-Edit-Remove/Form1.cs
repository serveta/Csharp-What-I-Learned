using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7_Data_from_txt_file_Add_Edit_Remove
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
            fileReader();
        }

        private void fileReader()
        {
            try
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                string[] data = File.ReadAllLines("car.txt");

                char[] ch = { ';' };

                for (int i = 0; i < data.Length; i++)
                {
                    string[] pieceOfdata = data[i].Split(ch, StringSplitOptions.RemoveEmptyEntries);
                    if (pieceOfdata.Length == 2)
                    {
                        listBox1.Items.Add(pieceOfdata[0]);
                        listBox2.Items.Add(pieceOfdata[1]);
                    }
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("ListBoxes are empty because the \"car.txt\" has not been created yet.","It's not important but you have to know it!");
            }
        }

        private void fileWriter()
        {
            try
            {
                FileStream fileStream = new FileStream("car.txt", FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fileStream);

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    streamWriter.WriteLine(listBox1.Items[i] + ";" + listBox2.Items[i]);
                }

                streamWriter.Close();
                fileStream.Close();
            }
            catch (Exception)
            {
               MessageBox.Show("Something goes wrong!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                int choice = listBox1.SelectedIndex;
                if (choice>-1)
                {
                    textBox1.Text = listBox1.Items[choice].ToString();
                    textBox2.Text = listBox2.Items[choice].ToString();
                }
            }
            else
            {
                int choice = listBox1.SelectedIndex;
                if (choice > -1)
                {
                    listBox1.Items.RemoveAt(choice);
                    listBox2.Items.RemoveAt(choice);
                    fileWriter();
                }
            }
        }

        private void textBox1And2_TextChanged(object sender, EventArgs e)
        {
            if (!radioButton3.Checked && textBox1.Text.Length>2 && textBox2.Text.Length>2)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                listBox1.Items.Add(textBox1.Text);
                listBox2.Items.Add(textBox2.Text);
            }
            else
            {
                int choice = listBox1.SelectedIndex;
                if (choice > -1)
                {
                    listBox1.Items[choice] = textBox1.Text;
                    listBox2.Items[choice] = textBox2.Text;
                }
            }
            textBox1.ResetText();
            textBox2.ResetText();
            fileWriter();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }

    }
}
