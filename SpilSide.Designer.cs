namespace Programmeringseksamen___Simulatorspil
{
    partial class SpilSide
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
            components = new System.ComponentModel.Container();
            MoneyCounter = new Label();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            BusinessImage = new PictureBox();
            Goals = new ListBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)BusinessImage).BeginInit();
            SuspendLayout();
            // 
            // MoneyCounter
            // 
            MoneyCounter.AutoSize = true;
            MoneyCounter.BackColor = SystemColors.Control;
            MoneyCounter.Location = new Point(12, 9);
            MoneyCounter.Name = "MoneyCounter";
            MoneyCounter.Size = new Size(50, 20);
            MoneyCounter.TabIndex = 0;
            MoneyCounter.Text = "label1";
            MoneyCounter.Click += MoneyCounter_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 220);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 1;
            label1.Text = "label2";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(354, 220);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 2;
            label2.Text = "v 5.0";
            label2.Click += label2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 87);
            button1.Name = "button1";
            button1.Size = new Size(165, 82);
            button1.TabIndex = 3;
            button1.Text = "multiplier";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(218, 87);
            button2.Name = "button2";
            button2.Size = new Size(164, 82);
            button2.TabIndex = 4;
            button2.Text = "Speed";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // BusinessImage
            // 
            BusinessImage.Location = new Point(0, 1);
            BusinessImage.Name = "BusinessImage";
            BusinessImage.Size = new Size(802, 448);
            BusinessImage.SizeMode = PictureBoxSizeMode.StretchImage;
            BusinessImage.TabIndex = 6;
            BusinessImage.TabStop = false;
            BusinessImage.Click += BusinessImage_Click;
            // 
            // Goals
            // 
            Goals.FormattingEnabled = true;
            Goals.Location = new Point(592, 34);
            Goals.Name = "Goals";
            Goals.Size = new Size(210, 404);
            Goals.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(676, 9);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 8;
            label3.Text = "Goals";
            // 
            // SpilSide
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(Goals);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(MoneyCounter);
            Controls.Add(BusinessImage);
            Name = "SpilSide";
            Text = "SpilSide";
            Load += SpilSide_Load;
            ((System.ComponentModel.ISupportInitialize)BusinessImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label MoneyCounter;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private System.Windows.Forms.Timer timer1;
        private PictureBox BusinessImage;
        private ListBox Goals;
        private Label label3;
    }
}