using MySql.Data.MySqlClient;
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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        private string nip;
        MySqlConnection koneksi = new MySqlConnection("server=localhost;database=db_kereta;uid=root;pwd=;");


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            this.Hide();
        }
        public void lihatData()
        {
            MySqlCommand cmd;
            cmd = koneksi.CreateCommand();
            cmd.CommandText = "SELECT * FROM tb_mydata";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;

        }

        
        public void penghasilan()
        {
            MySqlCommand cmd;
            cmd = koneksi.CreateCommand();
            cmd.CommandText = "SELECT TotalBayar, Nama, Kereta FROM tb_mydata;";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0].DefaultView;

        }
        public void tpenghasilan()
        {
            MySqlCommand cmd;
            cmd = koneksi.CreateCommand();
            cmd.CommandText = "select sum(TotalBayar)from tb_mydata;";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0].DefaultView;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            lihatData();
            dataGridView2.Visible = false;
            dataGridView2.Enabled = false;
            label2.Visible = false;
            groupBox3.Visible = false;
            groupBox3.Enabled = false;
            dataGridView2.Visible = false;
            dataGridView2.Enabled = false;
            dataGridView3.Visible = false;
            dataGridView3.Enabled = false;
            dataGridView1.Visible = true;
            dataGridView1.Enabled = true;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            label2.Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.Enabled = true;
            dataGridView3.Visible = false;
            dataGridView3.Enabled = false;
            groupBox3.Enabled = false;
            groupBox3.Visible = false;
            dataGridView3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            penghasilan();
            tpenghasilan();
            dataGridView2.Visible = true;
            dataGridView2.Enabled = true;
            dataGridView3.Visible = true;
            dataGridView3.Enabled = true;
            dataGridView1.Visible = false;
            dataGridView1.Enabled = false;
            label2.Visible = true;
            groupBox3.Visible = false;
            groupBox3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mode Train Control Sedang Dalam Masa Pengembangan, Untuk Sementara Fungsi Ini Tidak Dapat Berjalan");
            groupBox3.Enabled = true;
            groupBox3.Visible = true;
        }
    }
}
