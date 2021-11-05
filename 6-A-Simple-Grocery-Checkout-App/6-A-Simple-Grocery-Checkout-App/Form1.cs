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

namespace _6_A_Simple_Grocery_Checkout_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] priceOfProduct;
        int priceConverted;
        decimal total = 0;
       
        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = "";
            numericUpDown1.Minimum = 1;
            readData();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            decimal totalPrice = numericUpDown1.Value * priceOfProduct[comboBox1.SelectedIndex];

            listBox1.Items.Add(comboBox1.SelectedItem.ToString());
            listBox2.Items.Add(numericUpDown1.Value);
            listBox3.Items.Add(totalPrice + " TL");

            total += totalPrice;
            label4.Text = total.ToString() + " TL";
        }

        void readData()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            string[] data = File.ReadAllLines("productAndPrice.txt");

            priceOfProduct = new int[data.Length];

            for (int i = 0; i < data.Length; i++)
            {

                char[] ch = { ':' };
                string[] partOfData = data[i].Split(ch, StringSplitOptions.RemoveEmptyEntries);
                
                if (partOfData[0].Length > 0 && partOfData[1].Length > 0)
                {
                    comboBox1.Items.Add(partOfData[0].ToString());
                    int.TryParse(partOfData[1], out priceConverted);
                    priceOfProduct[i] = priceConverted;
                }

            }
        }

    }
}
