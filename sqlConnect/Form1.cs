using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sqlConnect
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti =new SqlConnection ("Server=MUSTAFAHASAN\\MUSTAFA;Database=TableDb;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "SELECT * FROM Student WHERE Name=@name and Password=@number AND TelNumber=@phone";
            SqlCommand komut = new SqlCommand(sorgu,baglanti);
            komut.Parameters.AddWithValue("@name", textBox3.Text);
            komut.Parameters.AddWithValue("@number", textBox2.Text);
            komut.Parameters.AddWithValue("@phone", textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("HOŞGELDİNİZ");
                Form2 form2 = new Form2();
                form2.Show();
            }
            else
            {
                MessageBox.Show("HATALI GİRİŞ");

            }
            baglanti.Close();





        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "INSERT INTO Student (Name,Password,TelNumber) VALUES (@name,@parola,@phone)";
            SqlCommand komut1 = new SqlCommand(sorgu, baglanti);
            komut1.Parameters.AddWithValue("@name", textBox4.Text);
            komut1.Parameters.AddWithValue("@parola", textBox5.Text);
            komut1.Parameters.AddWithValue("@phone", textBox6.Text);
            komut1.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarılı");
            baglanti.Close();

        }
    }
}
