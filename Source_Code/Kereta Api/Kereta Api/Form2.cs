using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kereta_Api
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            Thread t = new Thread(new ThreadStart(startform));
            t.Start();
            Thread.Sleep(4000);
            InitializeComponent();
            t.Abort();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public void startform()
        {
            Application.Run(new Form1());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            this.Hide();
        }
    }
}
