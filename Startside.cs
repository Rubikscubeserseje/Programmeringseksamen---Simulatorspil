using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programmeringseksamen___Simulatorspil
{
    public partial class Startside : Form
    {
        static SpilSide SpilSide = new SpilSide();
        public Startside()
        {
            InitializeComponent();
        }

        private void Startside_Load(object sender, EventArgs e)
        {
            string strconn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bruger\Downloads\Ny mappe\Database1.mdf"";Integrated Security=True";

            // LocalDB requires SQLExpress:
            // string strconn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\JTM2842\source\repos\ConsoleApp16\ConsoleApp16\App_Data\Database1.mdf';Integrated Security=True";

            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SpilSide.Show();


        }

        private void Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void PW_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            Username.Text = Program.navn;
        }
    }
}
