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

namespace _1.Login_form_with_DataBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CO1SVRB;Initial Catalog=Mylogindatabase;Integrated Security=True") ;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String username, user_password;

            username = txt_username.Text;
            user_password = txt_password.Text;

            try { 
            
                String querry = "SELECT * FROM Login_new WHERE username = '" +txt_username.Text+"' AND password = '"+txt_password.Text+"'";
                    SqlDataAdapter sda = new SqlDataAdapter(querry, conn);
                
                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txt_username.Text;
                    user_password = txt_password.Text;

                    //page that needed to be load nxt
                    Menuform form1 = new Menuform();
                    form1 .Show();
                    this.Hide();
                }
                else {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK ,MessageBoxIcon.Error);
                txt_username.Clear();
                    txt_password.Clear();

                    //to focus username
                    txt_username.Focus();
                }


            } catch {
                MessageBox.Show("Error");
            }
            finally { 
                conn.Close(); 
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();

            txt_username.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
        if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }
    }
}
