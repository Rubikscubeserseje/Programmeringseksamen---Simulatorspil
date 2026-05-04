using Microsoft.Win32;
using System.Diagnostics.CodeAnalysis;

namespace Programmeringseksamen___Simulatorspil
{
    public partial class Form1 : Form

    {

        public Form1()
        {
            InitializeComponent();
            label1.Text = timer1.Interval.ToString();
            button1.Hide();



        }
        ulong i = 0;
        int level = 0;

        private void MoneyCounter_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoneyCounter.Text = i.ToString() + "$";
            if (i >= 1000)
            {
                MoneyCounter.Text = (i / 1000).ToString() + "K$";
            }
            i = (ulong)((i + 1) * speed);
            if (i >= 5) button1.Show();

        }

        private static double speed = 1;
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            for (int j = 1; j < 100; j++)
                speed = speed * 1.1;
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            level++;
            button2.Text = "Level " + level.ToString() + "100$";

            if (timer1.Interval > 100)
            {
                timer1.Interval = timer1.Interval - 10;
            }

            else if (timer1.Interval <= 100 && timer1.Interval > 10)
            {
                timer1.Interval = timer1.Interval - 5;
            }

            else if (timer1.Interval <= 10 && timer1.Interval > 1)
            {
                timer1.Interval = timer1.Interval - 1;
            }
            else if (timer1.Interval <= 1)
            {
                button2.Text = "Max level";
                button2.Enabled = false;
            }


            label1.Text = timer1.Interval.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = timer1.Interval.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
