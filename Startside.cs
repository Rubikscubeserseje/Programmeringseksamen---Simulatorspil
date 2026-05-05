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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SpilSide.Show();


        }
    }
}
