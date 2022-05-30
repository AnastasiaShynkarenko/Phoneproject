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


namespace Phoneproject
{
    public partial class Phone : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-QCP1NQK;Initial Catalog=Phone;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private string query;

        public Phone()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Phone_Load(object sender, EventArgs e)
        {
            Display();

        }

        private void newbutton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Text = "";
            textBox4.Clear();

            comboBox1.SelectedIndex = -1;
            textBox1.Focus();
        }

        private void insertbutton_Click(object sender, EventArgs e) //вставка
        {

            //**SqlCommand cmd = new SqlCommand(@"INSERT INTO dbo.Mobiles
            //(First, Last, Mobile, Email, Group)
            //VALUES (' " + textBox1.Text + " ', ' " + textBox2.Text + " ', ' " + textBox3.Text + " ', ' " + textBox4.Text + " ', ' " + comboBox1.Text + " ')", con);

            SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Mobiles(First, Last, Mobile, Email, Group) " +
                $"VALUES({textBox1.Text}, {textBox2.Text}, {textBox3.Text}, {textBox4.Text}, {comboBox1.Text})", con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();



            MessageBox.Show("Saved!");
            Display();
        }
        void Display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Mobiles", con);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["First"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["1"].ToString(); 
                dataGridView1.Rows[n].Cells[2].Value = item["2"].ToString(); 
                dataGridView1.Rows[n].Cells[3].Value = item["3"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["4"].ToString();


            }

        }

        private void deletebutton_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
