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
    public partial class Form4 : Form
    {
        public Form4()
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
        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Mohon Isi Identitas Anda Dengan lengkap");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Darimana Asal Anda?");
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Kemana Tujuan Anda?");
            }
            else if (comboBox3.Text == "")
            {
                MessageBox.Show("Silahkan Pilih Kelas Kereta");
            }
            else
            {
                koneksi.Open();
                MySqlCommand cmd;
                cmd = koneksi.CreateCommand();
                cmd.CommandText = "insert into tb_mydata values(@nip,@num,@nama,@asal,@tujuan,@tanggal,@kelas,@kereta,@total)";
                cmd.Parameters.AddWithValue("@nip", textBox2.Text);
                cmd.Parameters.AddWithValue("@nama", textBox1.Text);
                cmd.Parameters.AddWithValue("@asal", comboBox1.Text);
                cmd.Parameters.AddWithValue("@tujuan", comboBox2.Text);
                cmd.Parameters.AddWithValue("@tanggal", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@kelas", comboBox3.Text);
                cmd.Parameters.AddWithValue("@kereta", label10.Text);
                cmd.Parameters.AddWithValue("@total", textBox3.Text);
                cmd.Parameters.AddWithValue("@num", GenerateRandomNo());
                MessageBox.Show("BERHASIL MEMESAN! "+" "+"Nomor pemesanan Anda = "+GenerateRandomNo()+"  "+"Silahkan Gunakan Nomor Tersebut Untuk Membatalkan/Mengubah Pesanan Anda");
                cmd.ExecuteNonQuery();
                koneksi.Close();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                label10.Text = "Kereta";
                comboBox1.Items.Remove("JAKARTA");
                comboBox1.Items.Remove("BOGOR");
                comboBox1.Items.Remove("DEPOK");
                comboBox1.Items.Remove("TANGGERANG");
                comboBox1.Items.Remove("BEKASI");
                comboBox1.Items.Remove("WIKRAMA");
                comboBox2.Items.Remove("JAKARTA");
                comboBox2.Items.Remove("BOGOR");
                comboBox2.Items.Remove("DEPOK");
                comboBox2.Items.Remove("TANGGERANG");
                comboBox2.Items.Remove("BEKASI");
                comboBox2.Items.Remove("WIKRAMA");
                comboBox3.Items.Remove("EXECUTIVE");
                comboBox3.Items.Remove("REGULAR");
                comboBox3.Items.Remove("ECONOMIC");
            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {
           




        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        
           

           
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "JAKARTA" || comboBox1.Text == "BOGOR" || comboBox1.Text == "DEPOK" || comboBox1.Text == "TANGGERANG" || comboBox1.Text == "BEKASI")
            {
                comboBox2.Items.Remove("JAKARTA");
                comboBox2.Items.Remove("BOGOR");
                comboBox2.Items.Remove("DEPOK");
                comboBox2.Items.Remove("TANGGERANG");
                comboBox2.Items.Remove("BEKASI");
                comboBox2.Items.Remove("WIKRAMA");
                comboBox2.Items.Add("WIKRAMA");
            }
            else if (comboBox1.Text == "WIKRAMA")
            {
                comboBox2.Text = "";
                comboBox2.Items.Remove("WIKRAMA");
                comboBox2.Items.Remove("JAKARTA");
                comboBox2.Items.Remove("BOGOR");
                comboBox2.Items.Remove("DEPOK");
                comboBox2.Items.Remove("TANGGERANG");
                comboBox2.Items.Remove("BEKASI");
                comboBox2.Items.Add("JAKARTA");
                comboBox2.Items.Add("BOGOR");
                comboBox2.Items.Add("DEPOK");
                comboBox2.Items.Add("TANGGERANG");
                comboBox2.Items.Add("BEKASI");
            }



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBox1.Text == "JAKARTA" || comboBox1.Text == "BOGOR" || comboBox1.Text == "DEPOK" && comboBox2.Text == "WIKRAMA") || (comboBox1.Text == "WIKRAMA" && comboBox2.Text == "BOGOR" || comboBox2.Text == "DEPOK" || comboBox2.Text == "JAKARTA"))
            {
                if (comboBox3.Text == "EXECUTIVE" )
                {
                    textBox3.Text = "30.000,00";
                    label10.Text = "JBD-W1";

                    checkBox2.Checked = false;
                    checkBox6.Checked = false;
                    checkBox1.Checked = true;
                    checkBox3.Checked = true;
                    checkBox4.Checked = true;
                    checkBox7.Checked = true;
                    checkBox8.Checked = true;
                    checkBox9.Checked = true;
                    checkBox10.Checked = true;
                    checkBox11.Checked = true;
                    checkBox12.Checked = true;
                }
                else if (comboBox3.Text == "REGULAR")
                {
                    textBox3.Text = "20.000,00";
                    label10.Text = "JBD-W2";

                    checkBox2.Checked = true;
                    checkBox6.Checked = true;
                    checkBox1.Checked = true;
                    checkBox3.Checked = true;
                    checkBox4.Checked = true;
                    checkBox7.Checked = false;
                    checkBox8.Checked = true;
                    checkBox9.Checked = false;
                    checkBox10.Checked = false;
                    checkBox11.Checked = true;
                    checkBox12.Checked = false;
                }
                else if (comboBox3.Text == "ECONOMIC")
                {
                    textBox3.Text = "10.000,00";
                    label10.Text = "JBD-W3";

                    checkBox2.Checked = false;
                    checkBox6.Checked = true;
                    checkBox1.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox7.Checked = false;
                    checkBox8.Checked = true;
                    checkBox9.Checked = false;
                    checkBox10.Checked = false;
                    checkBox11.Checked = false;
                    checkBox12.Checked = false;
                }

            }

            else if ((comboBox1.Text == "TANGGERANG" || comboBox1.Text == "BEKASI" && comboBox2.Text == "WIKRAMA") || (comboBox1.Text == "WIKRAMA" && comboBox2.Text == "TANGGERANG" || comboBox2.Text == "BEKASI"))
            {
                if (comboBox3.Text == "EXECUTIVE")
                {
                    textBox3.Text = "35.000,00";
                    label10.Text = "TB-W1";
                }
                else if (comboBox3.Text == "REGULAR")
                {
                    textBox3.Text = "25.000,00";
                    label10.Text = "TB-W2";
                }
                else if (comboBox3.Text == "ECONOMIC")
                {
                    textBox3.Text = "15.000,00";
                    label10.Text = "TB-W3";
                }

            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Remove("WIKRAMA");
            comboBox1.Items.Remove("JAKARTA");
            comboBox1.Items.Remove("BOGOR");
            comboBox1.Items.Remove("DEPOK");
            comboBox1.Items.Remove("TANGGERANG");
            comboBox1.Items.Remove("BEKASI");

            comboBox1.Items.Add("WIKRAMA");
            comboBox1.Items.Add("JAKARTA");
            comboBox1.Items.Add("BOGOR");
            comboBox1.Items.Add("DEPOK");
            comboBox1.Items.Add("TANGGERANG");
            comboBox1.Items.Add("BEKASI");
            textBox3.Text = "";
            label10.Text = "Kereta";
            comboBox3.Items.Remove("EXECUTIVE");
            comboBox3.Items.Remove("REGULAR");
            comboBox3.Items.Remove("ECONOMIC");
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            comboBox3.Items.Remove("EXECUTIVE");
            comboBox3.Items.Remove("REGULAR");
            comboBox3.Items.Remove("ECONOMIC");
            comboBox3.Items.Add("EXECUTIVE");
            comboBox3.Items.Add("REGULAR");
            comboBox3.Items.Add("ECONOMIC");
        }
    }
}
