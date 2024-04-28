using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml.Linq;
using System.IO;

namespace Database_Practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }        // Getting the Connection string
        public static string getConnStr()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRootDirectory = Directory.GetParent(Directory.GetParent(currentDirectory).Parent.FullName).FullName;
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={projectRootDirectory}\Database1.mdf;Integrated Security=True";
            return connectionString;
        }
        // Creating the Connection string object
        SqlConnection conn = new SqlConnection(getConnStr());

        private void btnEnter_Click(object sender, EventArgs e)
        {
            // Declaring variables to store data
            string id = txtId.Text;

            // Creating the Sql Query
            string query = $"SELECT * FROM goods WHERE Id='{id}';";

            // Creating Sql Command
            SqlCommand cmd = new SqlCommand(query, conn);

            // Executing the Sql cammand
            try
            {
                conn.Open();
                SqlDataReader data = cmd.ExecuteReader();

                if (data.HasRows)
                {
                    data.Read();
                    txtName.Text = data["Item"].ToString();
                    txtQty.Text = data["Qty"].ToString();
                    txtPrice.Text = data["Price"].ToString();
                }
                conn.Close();

                MessageBox.Show("SQL Command Excution Successful", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Declaring variables to store data
            string id = txtId.Text;
            string name = txtName.Text;
            string qty = txtQty.Text;
            string price = txtPrice.Text;

            // Creating the Sql Query
            string query = $"INSERT INTO goods VALUES ('{id}','{name}','{qty}','{price}');";

            // Creating Sql Command
            SqlCommand cmd = new SqlCommand(query, conn);

            // Executing the Sql cammand
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("SQL Command Excution Successful", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Declaring variables to store data
            string id = txtId.Text;
            string name = txtName.Text;
            string qty = txtQty.Text;
            string price = txtPrice.Text;

            // Creating the Sql Query
            string query = $"UPDATE goods SET Item='{name}',Qty='{qty}',Price='{price}' WHERE Id='{id}';";

            // Creating Sql Command
            SqlCommand cmd = new SqlCommand(query, conn);

            // Executing the Sql cammand
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("SQL Command Excution Successful", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Declaring variables to store data
            string id = txtId.Text;

            // Creating the Sql Query
            string query = $"DELETE FROM goods WHERE Id='{id}'";

            // Creating Sql Command
            SqlCommand cmd = new SqlCommand(query, conn);

            // Executing the Sql cammand
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("SQL Command Excution Successful", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
