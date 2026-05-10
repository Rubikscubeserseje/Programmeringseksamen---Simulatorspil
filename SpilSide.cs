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
        private bool[] goalCompleted = new bool[21];

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
            public bool[] GoalCompleted { get; set; } = new bool[21];
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
                GoalCompleted = goalCompleted,
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

                if (data.TimerInterval < 1)
                    timer1.Interval = 1;
                else
                    timer1.Interval = data.TimerInterval;

                if (data.GoalCompleted != null && data.GoalCompleted.Length == 25)
                    goalCompleted = data.GoalCompleted;
                else
                    goalCompleted = new bool[25];

                if (timer1.Interval <= 1)
                {
                    timer1.Interval = 1;
                    button2.Enabled = false;
                    button2.Text = "Computer Max";
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
                goalCompleted = new bool[25];
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
            int i = 0;

            goalCompleted[i] |= money >= 10;
            i++;
            goalCompleted[i] |= money >= 50;
            i++;
            goalCompleted[i] |= money >= 100;
            i++;
            goalCompleted[i] |= money >= 500;
            i++;
            goalCompleted[i] |= money >= 1000;
            i++;
            goalCompleted[i] |= money >= 5000;
            i++;
            goalCompleted[i] |= money >= 10000;
            i++;
            goalCompleted[i] |= money >= 100000;
            i++;
            goalCompleted[i] |= money >= 1000000;
            i++;
            goalCompleted[i] |= money >= 1000000000;
            i++;

            goalCompleted[i] |= speedLevel >= 1;
            i++;
            goalCompleted[i] |= speedLevel >= 3;
            i++;
            goalCompleted[i] |= speedLevel >= 5;
            i++;
            goalCompleted[i] |= speedLevel >= 10;
            i++;
            goalCompleted[i] |= speedLevel >= 25;
            i++;

            goalCompleted[i] |= timerLevel >= 1;
            i++;
            goalCompleted[i] |= timerLevel >= 3;
            i++;
            goalCompleted[i] |= timerLevel >= 5;
            i++;
            goalCompleted[i] |= timerLevel >= 10;
            i++;
            goalCompleted[i] |= timerLevel >= 25;
            i++;

            goalCompleted[i] |= incomePerTick >= 5;

            Goals.Items.Clear();

            Goals.Items.Add(goalCompleted[0] ? "✅ Tjen 10$" : "❌ Tjen 10$");
            Goals.Items.Add(goalCompleted[1] ? "✅ Tjen 50$" : "❌ Tjen 50$");
            Goals.Items.Add(goalCompleted[2] ? "✅ Tjen 100$" : "❌ Tjen 100$");
            Goals.Items.Add(goalCompleted[3] ? "✅ Tjen 500$" : "❌ Tjen 500$");
            Goals.Items.Add(goalCompleted[4] ? "✅ Tjen 1K$" : "❌ Tjen 1K$");
            Goals.Items.Add(goalCompleted[5] ? "✅ Tjen 5K$" : "❌ Tjen 5K$");
            Goals.Items.Add(goalCompleted[6] ? "✅ Tjen 10K$" : "❌ Tjen 10K$");
            Goals.Items.Add(goalCompleted[7] ? "✅ Tjen 100K$" : "❌ Tjen 100K$");
            Goals.Items.Add(goalCompleted[8] ? "✅ Tjen 1M$" : "❌ Tjen 1M$");
            Goals.Items.Add(goalCompleted[9] ? "✅ Tjen 1B$" : "❌ Tjen 1B$");

            Goals.Items.Add(goalCompleted[10] ? "✅ Køb 1 employee" : "❌ Køb 1 employee");
            Goals.Items.Add(goalCompleted[11] ? "✅ Nå employee level 3" : "❌ Nå employee level 3");
            Goals.Items.Add(goalCompleted[12] ? "✅ Nå employee level 5" : "❌ Nå employee level 5");
            Goals.Items.Add(goalCompleted[13] ? "✅ Nå employee level 10" : "❌ Nå employee level 10");
            Goals.Items.Add(goalCompleted[14] ? "✅ Nå employee level 25" : "❌ Nå employee level 25");

            Goals.Items.Add(goalCompleted[15] ? "✅ Køb 1 computer" : "❌ Køb 1 computer");
            Goals.Items.Add(goalCompleted[16] ? "✅ Nå computer level 3" : "❌ Nå computer level 3");
            Goals.Items.Add(goalCompleted[17] ? "✅ Nå computer level 5" : "❌ Nå computer level 5");
            Goals.Items.Add(goalCompleted[18] ? "✅ Nå computer level 10" : "❌ Nå computer level 10");
            Goals.Items.Add(goalCompleted[19] ? "✅ Nå computer level 25" : "❌ Nå computer level 25");

            Goals.Items.Add(goalCompleted[20] ? "✅ Nå 5$ per tick" : "❌ Nå 5$ per tick");
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