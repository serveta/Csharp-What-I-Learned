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

namespace _9_midterm_exam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Q-1: What kind of output is produced when these codes run?
            int[] list1 = new int[5];
            int[] list2 = new int[5];

            for (int i = 0; i < 5; i++)
            {
                list1[i] = Convert.ToInt32(listBox1.Items[i].ToString());
                list2[i] = Convert.ToInt32(listBox2.Items[i].ToString());
                if (list1[i] > list2[i])
                {
                    list1[i] += list2[i];
                }
                else
                {
                    list2[i] += list1[i];
                }
            }
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            for (int i = 0; i < 5; i++)
            {
                listBox1.Items.Add(list1[i].ToString());
                listBox2.Items.Add(list2[i].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Q-2: When the button2 is clicked, what is written in the text boxes is transferred to the data.txt file.
            FileStream fileStream = new FileStream("data.txt", FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(textBox1.Text + "-" + textBox2.Text + "-" + textBox3.Text);
            streamWriter.Close();
            fileStream.Close();

            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Convert to minimum banknotes based on the amount of money entered in the text box.
            // Turkish Lira (TL) has 200, 100, 50, 20, 10, 5 banknotes and 1 coin.

            label8.ResetText();

            int k = 0;
            int b = 0;

            int a = Convert.ToInt32(textBox4.Text);

            b = a / 200;
            k = a % 200;
            if (b>0)
            {
                label8.Text += b + " => 200 TL \n";
            }
            
            b = k / 100;
            k = k % 100;
            if (b > 0)
            {
                label8.Text += b + " => 100 TL \n";
            }

            b = k / 50;
            k = k % 50;
            if (b > 0)
            {
                label8.Text += b + " => 50 TL \n";
            }

            b = k / 20;
            k = k % 20;
            if (b > 0)
            {
                label8.Text += b + " => 20 TL \n";
            }

            b = k / 10;
            k = k % 10;
            if (b > 0)
            {
                label8.Text += b + " => 10 TL \n";
            }

            b = k / 5;
            k = k % 5;
            if (b > 0)
            {
                label8.Text += b + " => 5 TL \n";
            }

            b = k / 1;
            k = k % 1;
            if (b > 0)
            {
                label8.Text += b + " => 1 TL";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label8.Text = "";
        }
    }
}
