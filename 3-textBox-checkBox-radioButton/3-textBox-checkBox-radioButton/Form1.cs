using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_textBox_checkBox_radioButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
                label2.Text = radioButton1.Text;
            if(radioButton2.Checked)
                label2.Text = radioButton2.Text;
            if(radioButton3.Checked)
                label2.Text = radioButton3.Text;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "";
            if (checkBox1.Checked)
                label3.Text += "\n" + checkBox1.Text + "\n";
            if (checkBox2.Checked)
                label3.Text += "\n" + checkBox2.Text + "\n";
            if (checkBox3.Checked)
                label3.Text += "\n" + checkBox3.Text;
        }
    }
}
