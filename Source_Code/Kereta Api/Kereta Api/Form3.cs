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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            frm.Show();
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form8 frm = new Form8();
            frm.Show();
        }
    }
}
