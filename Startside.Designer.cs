namespace Programmeringseksamen___Simulatorspil
{
    partial class Startside
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Startside));
            button1 = new Button();
            button2 = new Button();
            Background = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)Background).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(352, 86);
            button1.Name = "button1";
            button1.Size = new Size(125, 47);
            button1.TabIndex = 0;
            button1.Text = "continue game";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(352, 192);
            button2.Name = "button2";
            button2.Size = new Size(125, 48);
            button2.TabIndex = 1;
            button2.Text = "new game";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Background
            // 
            Background.BackgroundImage = (Image)resources.GetObject("Background.BackgroundImage");
            Background.Location = new Point(5, 3);
            Background.Name = "Background";
            Background.Size = new Size(794, 445);
            Background.TabIndex = 2;
            Background.TabStop = false;
            // 
            // Startside
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(Background);
            Name = "Startside";
            Text = "Startside";
            Load += Startside_Load;
            ((System.ComponentModel.ISupportInitialize)Background).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private PictureBox Background;
    }
}