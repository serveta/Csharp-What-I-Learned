﻿using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Form1 form1;

        private void Form2_Load(object sender, EventArgs e)
        {
            form1 = new Form1();
            label1.Text = Form1.count.ToString();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.txt = textBox1.Text;
            e.Cancel = true;
            Hide();
        }
    }
}
