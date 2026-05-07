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
            button1 = new Button();
            Username = new TextBox();
            PW = new TextBox();
            Login = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(59, -6);
            button1.Margin = new Padding(4, 4, 4, 4);
            button1.Name = "button1";
            button1.Size = new Size(118, 36);
            button1.TabIndex = 0;
            button1.Text = "continue";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Username
            // 
            Username.Location = new Point(116, 70);
            Username.Name = "Username";
            Username.Size = new Size(150, 31);
            Username.TabIndex = 1;
            Username.TextChanged += Username_TextChanged;
            // 
            // PW
            // 
            PW.Location = new Point(114, 122);
            PW.Name = "PW";
            PW.Size = new Size(150, 31);
            PW.TabIndex = 2;
            PW.TextChanged += PW_TextChanged;
            // 
            // Login
            // 
            Login.Location = new Point(114, 167);
            Login.Name = "Login";
            Login.Size = new Size(112, 34);
            Login.TabIndex = 3;
            Login.Text = "login";
            Login.UseVisualStyleBackColor = true;
            Login.Click += Login_Click;
            // 
            // Startside
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(Login);
            Controls.Add(PW);
            Controls.Add(Username);
            Controls.Add(button1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Startside";
            Text = "Startside";
            Load += Startside_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox Username;
        private TextBox PW;
        private Button Login;
    }
}