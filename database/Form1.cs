using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string nic = txtNic.Text.ToString();
            string name = txtName.Text.ToString();
            string email = txtEmail.Text.ToString();
            string contact = txtContact.Text.ToString();

            MySqlDataReader rd;

            MySqlConnection conn;
            string connetionString = null;
            connetionString = "server=localhost;database=csharpp;uid=root;pwd=;";
            conn = new MySqlConnection(connetionString);
            String query;
            query = "insert into csharpp.personaldetails(nic,name,email,contact)VALUES('" + nic + "','" + name + "','" + email + "','" + contact + "')";

            MySqlCommand command = new MySqlCommand(query, conn);

            try
            {
                
                if (txtNic.Text == "" || txtName.Text == "" || txtEmail.Text == "" || txtContact.Text == "")
                {
                    MessageBox.Show("Plase enter Username and Password");
                }
                else 
                {


                    conn.Open();
                    rd = command.ExecuteReader();
                    MessageBox.Show("data saved");
                    conn.Close();
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(" Can't Add because:- " + ex.Message);
            }
            finally
            {
                conn.Close();
                txtNic.Text = txtName.Text = txtEmail.Text = txtContact.Text = "";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MySqlDataReader rd;
            String query;
            MySqlConnection conn;
            string connetionString = null;
            connetionString = "server=localhost;database=csharpp;uid=root;pwd=;";
            conn = new MySqlConnection(connetionString);

            query = "select * from personaldetails where nic = '" + this.txtNic.Text + "'";
            
            conn.Open();
            MySqlCommand command = new MySqlCommand(query, conn);
            rd = command.ExecuteReader();
            try
            {
                

                 if (rd.Read())
                 {
                     txtNic.Text = (rd["nic"].ToString());
                     txtName.Text = (rd["name"].ToString());
                     txtEmail.Text = (rd["email"].ToString());
                     txtContact.Text = (rd["contact"].ToString());           
                 }
                 rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MySqlDataReader rd;

            MySqlConnection conn;
            string connetionString = null;
            connetionString = "server=localhost;database=csharpp;uid=root;pwd=;";
            conn = new MySqlConnection(connetionString);
            conn.Open();

            try
            {

                string nic = txtNic.Text.ToString();
                string name = txtName.Text.ToString();
                string email = txtEmail.Text.ToString();
                string contact = txtContact.Text.ToString();


                string updatequery = "UPDATE personaldetails SET nic='" + nic + "',name='" + name + "',email='" + email + "',contact='" + contact + "' WHERE nic='" + this.txtNic.Text + "'";
                MySqlCommand updatecmd = new MySqlCommand(updatequery, conn);
                updatecmd.ExecuteNonQuery();
                MessageBox.Show("Done , Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MySqlDataReader rd;

            MySqlConnection conn;
            string connetionString = null;
            connetionString = "server=localhost;database=csharpp;uid=root;pwd=;";
            conn = new MySqlConnection(connetionString);
            conn.Open();
            try
            {
                MySqlCommand deletecmd = new MySqlCommand("delete from personaldetails WHERE nic='" + txtNic.Text + "'", conn);
                deletecmd.ExecuteNonQuery();
                MessageBox.Show("Deleted!");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource = localhost;port = 3306; Initial Catalog = 'csharpp'; username = root; password=");
            MySqlCommand command;
            MySqlDataAdapter adapter;
            DataTable table;
            string query = "select* from personaldetails where nic = '" + this.txtNic.Text + "'";
            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
