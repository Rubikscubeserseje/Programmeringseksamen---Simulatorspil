using System;
using System.IO;
using System.Numerics;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Programmeringseksamen___Simulatorspil
{


    public partial class SpilSide : Form
    {
        private BigInteger money = 0;
        private BigInteger incomePerTick = 1;

        private int speedLevel = 0;
        private int timerLevel = 0;



        private string SaveFilePath => Path.Combine(Application.StartupPath, "savegame.json");
        public class SaveData
        {
            public string Money { get; set; } = "0";
            public string IncomePerTick { get; set; } = "1";
            public int SpeedLevel { get; set; } = 0;
            public int TimerLevel { get; set; } = 0;
            public int TimerInterval { get; set; } = 1000;
        }
        public SpilSide()
        {
            InitializeComponent();
        }

        private void SpilSide_Load(object sender, EventArgs e)
        {
            LoadGame();
            UpdateUI();

        }

        private BigInteger GetSpeedUpgradeCost()
        {
            return 5 * BigInteger.Pow(2, speedLevel);
        }

        private BigInteger GetTimerUpgradeCost()
        {
            return 100 * BigInteger.Pow(3, timerLevel);
        }

        private void SaveGame()
        {
            SaveData data = new SaveData
            {
                Money = money.ToString(),
                IncomePerTick = incomePerTick.ToString(),
                SpeedLevel = speedLevel,
                TimerLevel = timerLevel,
                TimerInterval = timer1.Interval
            };

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(SaveFilePath, json);
        }

        private void LoadGame()
        {
            try
            {
                if (!File.Exists(SaveFilePath))
                    return;

                string json = File.ReadAllText(SaveFilePath);
                SaveData? data = JsonSerializer.Deserialize<SaveData>(json);

                if (data == null)
                    return;

                if (BigInteger.TryParse(data.Money, out BigInteger loadedMoney))
                    money = loadedMoney;

                if (BigInteger.TryParse(data.IncomePerTick, out BigInteger loadedIncome))
                    incomePerTick = loadedIncome;

                speedLevel = data.SpeedLevel;
                timerLevel = data.TimerLevel;
                timer1.Interval = data.TimerInterval;

                if (timer1.Interval <= 1)
                {
                    timer1.Interval = 1;
                    button2.Enabled = false;
                    button2.Text = "Max level";
                }
                else
                {
                    button2.Enabled = true;
                }
            }
            catch
            {
                money = 0;
                incomePerTick = 1;
                speedLevel = 0;
                timerLevel = 0;
                timer1.Interval = 1000;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            money += incomePerTick;

           

            UpdateUI();
            SaveGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BigInteger speedUpgradeCost = GetSpeedUpgradeCost();

            if (money < speedUpgradeCost)
                return;

            money -= speedUpgradeCost;
            speedLevel++;

            incomePerTick += 1 + speedLevel;

            UpdateUI();
            SaveGame();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BigInteger timerUpgradeCost = GetTimerUpgradeCost();

            if (money < timerUpgradeCost)
                return;

            money -= timerUpgradeCost;
            timerLevel++;

            if (timer1.Interval > 300)
                timer1.Interval -= 50;
            else if (timer1.Interval > 150)
                timer1.Interval -= 25;
            else if (timer1.Interval > 60)
                timer1.Interval -= 10;
            else if (timer1.Interval > 20)
                timer1.Interval -= 5;
            else if (timer1.Interval > 5)
                timer1.Interval -= 1;
            else
            {
                timer1.Interval = 1;
                button2.Enabled = false;
                button2.Text = "Max level";
            }

            UpdateUI();
            SaveGame();
        }

        private void UpdateUI()
        {
            BigInteger speedUpgradeCost = GetSpeedUpgradeCost();
            BigInteger timerUpgradeCost = GetTimerUpgradeCost();

            bool canBuyEmployees = money >= speedUpgradeCost;
            bool canBuyComputer = money >= timerUpgradeCost;

            UpdateBusinessImage();
            MoneyCounter.Text = FormatMoney(money);
            label1.Text = $"Computer speed: {timer1.Interval} ms | Employees income: {FormatMoney(incomePerTick)}";

            button1.Text = $"Employees Lv.{speedLevel} (Cost: {FormatMoney(speedUpgradeCost)})";
            button1.BackColor = canBuyEmployees ? Color.Green : Color.Red;
            button1.ForeColor = Color.White;

            if (button2.Enabled)
            {
                button2.Text = $"Computer Lv.{timerLevel} (Cost: {FormatMoney(timerUpgradeCost)})";
                button2.BackColor = canBuyComputer ? Color.Green : Color.Red;
                button2.ForeColor = Color.White;
            }
            else
            {
                button2.Text = "Computer Max";
                button2.BackColor = Color.Gray;
                button2.ForeColor = Color.White;
            }

            UpdateGoals();
        }

        private string FormatMoney(BigInteger value)
        {
            if (value >= 1_000_000_000_000_000_000)
                return $"{value / 1_000_000_000_000_000_000}Qi$";
            if (value >= 1_000_000_000_000_000)
                return $"{value / 1_000_000_000_000_000}Qa$";
            if (value >= 1_000_000_000_000)
                return $"{value / 1_000_000_000_000}T$";
            if (value >= 1_000_000_000)
                return $"{value / 1_000_000_000}B$";
            if (value >= 1_000_000)
                return $"{value / 1_000_000}M$";
            if (value >= 1_000)
                return $"{value / 1_000}K$";

            return value + "$";
        }

        private void UpdateGoals()
        {
            Goals.Items.Clear();

            // Money goals
            Goals.Items.Add(money >= 10 ? "✅ Tjen 10$" : "❌ Tjen 10$");
            Goals.Items.Add(money >= 50 ? "✅ Tjen 50$" : "❌ Tjen 50$");
            Goals.Items.Add(money >= 100 ? "✅ Tjen 100$" : "❌ Tjen 100$");
            Goals.Items.Add(money >= 500 ? "✅ Tjen 500$" : "❌ Tjen 500$");
            Goals.Items.Add(money >= 1000 ? "✅ Tjen 1K$" : "❌ Tjen 1K$");
            Goals.Items.Add(money >= 5000 ? "✅ Tjen 5K$" : "❌ Tjen 5K$");
            Goals.Items.Add(money >= 10000 ? "✅ Tjen 10K$" : "❌ Tjen 10K$");
            Goals.Items.Add(money >= 100000 ? "✅ Tjen 100K$" : "❌ Tjen 100K$");
            Goals.Items.Add(money >= 1000000 ? "✅ Tjen 1M$" : "❌ Tjen 1M$");
            Goals.Items.Add(money >= 1000000000 ? "✅ Tjen 1B$" : "❌ Tjen 1B$");

            // Income upgrade goals
            Goals.Items.Add(speedLevel >= 1 ? "✅ Køb 1 income upgrade" : "❌ Køb 1 income upgrade");
            Goals.Items.Add(speedLevel >= 3 ? "✅ Nå income level 3" : "❌ Nå income level 3");
            Goals.Items.Add(speedLevel >= 5 ? "✅ Nå income level 5" : "❌ Nå income level 5");
            Goals.Items.Add(speedLevel >= 10 ? "✅ Nå income level 10" : "❌ Nå income level 10");
            Goals.Items.Add(speedLevel >= 25 ? "✅ Nå income level 25" : "❌ Nå income level 25");

            // Speed upgrade goals
            Goals.Items.Add(timerLevel >= 1 ? "✅ Køb 1 speed upgrade" : "❌ Køb 1 speed upgrade");
            Goals.Items.Add(timerLevel >= 3 ? "✅ Nå speed level 3" : "❌ Nå speed level 3");
            Goals.Items.Add(timerLevel >= 5 ? "✅ Nå speed level 5" : "❌ Nå speed level 5");
            Goals.Items.Add(timerLevel >= 10 ? "✅ Nå speed level 10" : "❌ Nå speed level 10");
            Goals.Items.Add(timerLevel >= 25 ? "✅ Nå speed level 25" : "❌ Nå speed level 25");

            // Income per tick goals
            Goals.Items.Add(incomePerTick >= 5 ? "✅ Nå 5$ per tick" : "❌ Nå 5$ per tick");
            Goals.Items.Add(incomePerTick >= 10 ? "✅ Nå 10$ per tick" : "❌ Nå 10$ per tick");
            Goals.Items.Add(incomePerTick >= 50 ? "✅ Nå 50$ per tick" : "❌ Nå 50$ per tick");
            Goals.Items.Add(incomePerTick >= 100 ? "✅ Nå 100$ per tick" : "❌ Nå 100$ per tick");
            Goals.Items.Add(incomePerTick >= 1000 ? "✅ Nå 1K$ per tick" : "❌ Nå 1K$ per tick");
        }

        private void UpdateBusinessImage()
        {
            int totalLevel = speedLevel + timerLevel;
            string imagePath;

            if (totalLevel >= 18)
                imagePath = Path.Combine(Application.StartupPath, "Images", "MaxLevel.png");
            else if (totalLevel >= 10)
                imagePath = Path.Combine(Application.StartupPath, "Images", "MediumLevel.png");
            else
                imagePath = Path.Combine(Application.StartupPath, "Images", "LowLevel.png");

            if (File.Exists(imagePath))
            {
                BusinessImage.Image?.Dispose();
                BusinessImage.Image = Image.FromFile(imagePath);
            }
        }
        private void MoneyCounter_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BusinessImage_Click(object sender, EventArgs e)
        {

        }
    }
}