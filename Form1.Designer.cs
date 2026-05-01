namespace Programmeringseksamen___Simulatorspil
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            MoneyCounter = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // MoneyCounter
            // 
            MoneyCounter.Location = new Point(22, 20);
            MoneyCounter.Name = "MoneyCounter";
            MoneyCounter.Size = new Size(111, 25);
            MoneyCounter.TabIndex = 0;
            MoneyCounter.Text = "0";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // button1
            // 
            button1.Location = new Point(153, 61);
            button1.Name = "button1";
            button1.Size = new Size(143, 87);
            button1.TabIndex = 1;
            button1.Text = "Upgrade Multiplier";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(354, 62);
            button2.Name = "button2";
            button2.Size = new Size(141, 88);
            button2.TabIndex = 2;
            button2.Text = "Upgrade Speed";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(117, 189);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 3;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(702, 210);
            label2.Name = "label2";
            label2.Size = new Size(33, 25);
            label2.TabIndex = 4;
            label2.Text = "V1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(MoneyCounter);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label MoneyCounter;
        private System.Windows.Forms.Timer timer1;
        private Button multiplier;
        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
    }
}
