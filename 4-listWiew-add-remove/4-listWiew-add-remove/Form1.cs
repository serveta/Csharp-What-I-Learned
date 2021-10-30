using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_listWiew_add_remove
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int row = listView1.Items.Count;
            listView1.Items.Add(txtId.Text);

            listView1.Items[row].SubItems.Add(txtName.Text);
            listView1.Items[row].SubItems.Add(txtSurname.Text);
            listView1.Items[row].SubItems.Add(txtDepartment.Text);

            comboBox1.Items.Add(listView1.Items.Count.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            listView1.Items.RemoveAt(index);

            comboBox1.Items.Clear();
            for (int i = 1; i <= listView1.Items.Count; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }
                
        }
    }
}
