using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace WindowsFormsAppSecA
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string str = ConfigurationManager.ConnectionStrings["dataString"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM userlogin", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=HP-1500\\SQLEXPRESS;Initial Catalog=GLA_MCA;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("insert into userlogin values(@userid,@password,@username)", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@userid", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@password", textBox2.Text);
            sqlCommand.Parameters.AddWithValue("@username", textBox3.Text);
            sqlCommand.ExecuteNonQuery();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=HP-1500\\SQLEXPRESS;Initial Catalog=GLA_MCA;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("delete from userlogin where userid=@userid", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@userid", textBox1.Text);

            sqlCommand.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=HP-1500\\SQLEXPRESS;Initial Catalog=GLA_MCA;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("UPDATE userLogin set uname  = @username where userId = @userId", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@userid", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@username", textBox3.Text);
            sqlCommand.ExecuteNonQuery();

        }
    }
}
