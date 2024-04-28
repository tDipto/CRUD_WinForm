using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Password=admin2020;Username=postgres;Database=CRUD_NET");


        private void Form1_Load(object sender, EventArgs e)
        {
            bind_data();
        }

        private void bind_data()
        {

            NpgsqlCommand cmd = new NpgsqlCommand("select * from student", con);

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("insert into student values(@id,@name,@age)", con);

            cmd.Parameters.AddWithValue("@id",int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", int.Parse(textBox3.Text));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bind_data();

            MessageBox.Show("Succesfull");
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("select * from student where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));

            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            npgsqlDataAdapter.Fill(dt);

            dataGridView1.DataSource = dt;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("update student set name=@name,age=@age where id=@id", con);

            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", int.Parse(textBox3.Text));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bind_data();

            MessageBox.Show("Updated");
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("delete from student where id=@id", con);

            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bind_data();

            MessageBox.Show("Succesfull Deleted");
            textBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bind_data();
        }
    }
}
