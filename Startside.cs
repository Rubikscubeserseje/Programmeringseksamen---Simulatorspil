using System;
using System.IO;
using System.Windows.Forms;

namespace Programmeringseksamen___Simulatorspil
{
    public partial class Startside : Form
    {
        private string SaveFilePath => Path.Combine(Application.StartupPath, "savegame.json");

        public Startside()
        {
            InitializeComponent();
        }

        private void Startside_Load(object sender, EventArgs e)
        {

        }

        // Continue
        private void button1_Click(object sender, EventArgs e)
        {
            SpilSide spilSide = new SpilSide();
            this.Hide();
            spilSide.Show();
        }

        // New Game
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Er du sikker på, at du vil starte et nyt spil? Dit gamle save bliver slettet.",
                "New Game",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            if (File.Exists(SaveFilePath))
                File.Delete(SaveFilePath);

            SpilSide spilSide = new SpilSide();
            this.Hide();
            spilSide.Show();
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void PW_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}