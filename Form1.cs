namespace Programmeringseksamen___Simulatorspil
{
    public partial class Form1 : Form

    {

        public Form1()
        {
            InitializeComponent();
            label1.Text = timer1.Interval.ToString();


        }
        int i = 0;
        private void MoneyCounter_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoneyCounter.Text = i.ToString();
            i = (int)((i + 1) * speed);
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
            speed = speed * 1.1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(timer1.Interval > 100)
            {
                timer1.Interval = timer1.Interval - 10;
            }

            else if(timer1.Interval <= 100 && timer1.Interval > 10)
            {
                timer1.Interval = timer1.Interval - 5;
            }

            else if(timer1.Interval <= 10 && timer1.Interval > 1)
            {
                timer1.Interval = timer1.Interval - 1;
            }
            else if(timer1.Interval <= 1)
            {
                return;
            }
            label1.Text = timer1.Interval.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = timer1.Interval.ToString();
        }
    }
}
