using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_relation_between_forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Form2 form2;
        public static int count;
        public static string txt;

        private void Form1_Load(object sender, EventArgs e)
        {
            form2 = new Form2();
            label1.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            form2.ShowDialog();
            label1.Text = txt;
        }
    }
}
