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
    public partial class Form2 : Form
    {
        SqlConnection connect = new SqlConnection("Server=MUSTAFAHASAN\\MUSTAFA;Database=Books1;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void Get()
        {
            connect.Open();
            string sorgu = "SELECT * FROM book_table";
            SqlCommand komut = new SqlCommand(sorgu, connect);
            SqlDataReader reader = komut.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
            connect.Close();




        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Get();
            this.Hide();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            connect.Open();
            string sorgu = "DELETE FROM book_table WHERE ıd=@mıd ";
            SqlCommand komut = new SqlCommand(sorgu, connect);
            komut.Parameters.AddWithValue("@mıd", Convert.ToInt32(textBox1.Text));  
            komut.ExecuteNonQuery();
            connect.Close();
            Get();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            connect.Open();
            string sorgu = "INSERT INTO book_table (KitapAdi,YazarAdi) VALUES (@kname,@yazar)";
            SqlCommand komut = new SqlCommand(sorgu, connect);
            komut.Parameters.AddWithValue("@kname", textBox2.Text);
            komut.Parameters.AddWithValue("@yazar", textBox3.Text);
            komut.ExecuteNonQuery();
            connect.Close();
            Get();

        }
    }
}
