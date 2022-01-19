using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10_final_exam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Q-1:
        /*
         Let the same thing written to the textBox1 object be written to the textBox2 object, and the reverse written to the textBox3 object. Let the number of characters be displayed on label1.
         */
        // A-1:
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ResetText();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
            string s = null;
            int n = textBox1.TextLength;
            label1.Text = n.ToString(); ;
            for (int i = 0; i < n; i++)
            {
                s += textBox1.Text[n - 1 - i];
                textBox3.Text = s;
            }
        }

        // Q-2:
        /*
         Let the value written to the textBox4 object be the duration of the timer. When the timer expires, it should always open the Form2 object.
         */
        // A-2:
        private void button1_Click(object sender, EventArgs e)
        {
            int time = Convert.ToInt32(textBox4.Text);
            timer1.Interval = time*1000;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }

        // Q-3:
        /*
         Prime numbers between numbers from textBox5 and textBox6 objects will be checked and the number of them will be displayed in the label5 object. In addition, the prime numbers found will be written to the lisBox object.
         */
        // A-3:
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            label5.ResetText();
            int num1 = Convert.ToInt32(textBox5.Text);
            if (num1 <= 1)
            {
                num1 = 2;
                textBox5.Text = num1.ToString();
            }

            int num2 = Convert.ToInt32(textBox6.Text);

            if(num2<=num1){
                MessageBox.Show("num2 has to be bigger than num1!", "WARNING");
            }
            else{
                for (int i = num1; i < num2; i++)
                {
                    int count = 0;
                    for (int j = 1; j <= i; j++)
                    {
                        if (i % j == 0)
                        {
                            count++;
                            if (count > 2)
                            {
                                break;
                            }
                        }
                    }
                    if (count <= 2)
                    {
                        listBox1.Items.Add(i.ToString());
                        label5.Text = listBox1.Items.Count.ToString();
                    }
                }
            }
            
        }

        

    }
}
