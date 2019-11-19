using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kereta_Api
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private string nip;
        MySqlConnection koneksi = new MySqlConnection("server=localhost;database=db_kereta;uid=root;pwd=;");


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            this.Hide();
        }
        public void lihatData()
        {
            MySqlCommand cmd;
            cmd = koneksi.CreateCommand();
            cmd.CommandText = "SELECT * FROM tb_mydata WHERE NomorInduk = @nip";
            cmd.Parameters.AddWithValue("@nip", textBox2.Text);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Dengan Mengubah Pesanan Anda, Anda Akan Mengisi Ulang Formulir Pemesanan, Dan Mendapatkan Kode Pemesanan Baru, Apakah Anda Ingin Melanjutkan?", "ATTENTION!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                panel1.Visible = true;
                panel1.Enabled = true;
                button4.Visible = false;
                button4.Enabled = false;
                button5.Enabled = true;
                button5.Visible = true;
                panel1.BackColor = Color.DeepSkyBlue;
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("PENGUBAHAN pemesanan dibatalkan");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lihatData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Enabled = true;
            button5.Enabled = false;
            button5.Visible = false;
            button4.Visible = true;
            button4.Enabled = true;
            panel1.BackColor=Color.Khaki;


        }

        private void Form5_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel1.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            MySqlCommand cmd;
            cmd = koneksi.CreateCommand();
            cmd.CommandText = "DELETE FROM tb_mydata WHERE NoPemesanan= @nop";
            cmd.Parameters.AddWithValue("@nop", textBox1.Text);
            MessageBox.Show("Berhasil Membatalkan Pemesanan");
            cmd.ExecuteNonQuery();
            textBox1.Text = "";
            panel1.Visible = false;
            panel1.Enabled = false;
            lihatData();
            koneksi.Close();
        }

        private Point MouseDownLocation;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                panel1.Left = e.X + panel1.Left - MouseDownLocation.X;
                panel1.Top = e.Y + panel1.Top - MouseDownLocation.Y;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            MySqlCommand cmd;
            cmd = koneksi.CreateCommand();
            cmd.CommandText = "DELETE FROM tb_mydata WHERE NoPemesanan= @nop";
            cmd.Parameters.AddWithValue("@nop", textBox1.Text);
            MessageBox.Show("Anda Akan Dibawa Ke Formulir Pemesanan Lagi");
            cmd.ExecuteNonQuery();
            textBox1.Text = "";
            panel1.Visible = false;
            panel1.Enabled = false;
            lihatData();
            koneksi.Close();
            Form4 frm = new Form4();
            frm.Show();
            this.Hide();
        }
    }
    }

