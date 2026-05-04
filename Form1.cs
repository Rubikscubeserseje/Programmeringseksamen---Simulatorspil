using System.Numerics;

namespace Programmeringseksamen___Simulatorspil
{
    public partial class Form1 : Form
    {
        private BigInteger money = 0;
        private ulong incomePerTick = 1;

        private int speedLevel = 0;
        private int timerLevel = 0;

        private ulong speedUpgradeCost = 5;
        private ulong timerUpgradeCost = 100;

        public Form1()
        {
            InitializeComponent();
            UpdateUI();
            button1.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ulong.MaxValue - money < incomePerTick)
            {
                money = ulong.MaxValue;
                timer1.Stop();
            }
            else
            {
                money += incomePerTick;
            }

            if (money >= 5)
                button1.Show();

            UpdateUI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (money < speedUpgradeCost)
                return;

            money -= speedUpgradeCost;
            speedLevel++;

            if (incomePerTick <= ulong.MaxValue / 2)
                incomePerTick *= 2;
            else
                incomePerTick = ulong.MaxValue;

            speedUpgradeCost *= 2;

            UpdateUI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (money < timerUpgradeCost)
                return;

            money -= timerUpgradeCost;
            timerLevel++;

            if (timer1.Interval > 100)
                timer1.Interval -= 10;
            else if (timer1.Interval > 10)
                timer1.Interval -= 5;
            else if (timer1.Interval > 1)
                timer1.Interval -= 1;
            else
            {
                timer1.Interval = 50;
                button2.Enabled = false;
                button2.Text = "Max level";
            } 

            timerUpgradeCost += 100;
            UpdateUI();
        }

        private void UpdateUI()
        {
            MoneyCounter.Text = FormatMoney(money);
            label1.Text = $"Interval: {timer1.Interval} ms";

            button1.Text = $"Upgrade income (Cost: {FormatMoney(speedUpgradeCost)})";
            if (button2.Enabled)
                button2.Text = $"Timer level {timerLevel} (Cost: {FormatMoney(timerUpgradeCost)})";
        }

        private string FormatMoney(BigInteger value)
        {
            if (value >= 1_000_000_000)
                return $"{value / 1_000_000_000}B$";
            if (value >= 1_000_000)
                return $"{value / 1_000_000}M$";
            if (value >= 1_000)
                return $"{value / 1_000}K$";

            return value + "$";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}