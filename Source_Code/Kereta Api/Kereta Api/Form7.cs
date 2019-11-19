using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kereta_Api
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "admin" && textBox2.Text == "12345")
            {
                MessageBox.Show("LOGIN SUKSES! Welcome! Admin_1");
                Form6 frm = new Form6();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("LOGIN GAGAL");
                this.Hide();
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
