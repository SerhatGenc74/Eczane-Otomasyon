namespace EczaneOtomasyon
{
    partial class Frmlogin
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
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_login = new System.Windows.Forms.Panel();
            this.pnl_logincard = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnl_sidebar = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnl_Ilaclar = new System.Windows.Forms.Panel();
            this.pnl_content = new System.Windows.Forms.Panel();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.pnl_login.SuspendLayout();
            this.pnl_logincard.SuspendLayout();
            this.pnl_sidebar.SuspendLayout();
            this.pnl_Ilaclar.SuspendLayout();
            this.pnl_header.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(133, 95);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(100, 20);
            this.txt_username.TabIndex = 0;
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(133, 141);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(100, 20);
            this.txt_password.TabIndex = 1;
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_login.FlatAppearance.BorderSize = 0;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_login.ForeColor = System.Drawing.Color.White;
            this.btn_login.Location = new System.Drawing.Point(133, 188);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(100, 23);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "Giriş Yap";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Şifre";
            // 
            // pnl_login
            // 
            this.pnl_login.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pnl_login.Controls.Add(this.pnl_logincard);
            this.pnl_login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_login.Location = new System.Drawing.Point(0, 0);
            this.pnl_login.Name = "pnl_login";
            this.pnl_login.Size = new System.Drawing.Size(800, 450);
            this.pnl_login.TabIndex = 5;
            this.pnl_login.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_login_Paint);
            // 
            // pnl_logincard
            // 
            this.pnl_logincard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnl_logincard.BackColor = System.Drawing.Color.White;
            this.pnl_logincard.Controls.Add(this.label3);
            this.pnl_logincard.Controls.Add(this.btn_login);
            this.pnl_logincard.Controls.Add(this.txt_password);
            this.pnl_logincard.Controls.Add(this.label2);
            this.pnl_logincard.Controls.Add(this.label1);
            this.pnl_logincard.Controls.Add(this.txt_username);
            this.pnl_logincard.Location = new System.Drawing.Point(217, 50);
            this.pnl_logincard.Name = "pnl_logincard";
            this.pnl_logincard.Size = new System.Drawing.Size(350, 341);
            this.pnl_logincard.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "HOŞ GELDİNİZ";
            // 
            // pnl_sidebar
            // 
            this.pnl_sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnl_sidebar.Controls.Add(this.button3);
            this.pnl_sidebar.Controls.Add(this.button2);
            this.pnl_sidebar.Controls.Add(this.button1);
            this.pnl_sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_sidebar.Location = new System.Drawing.Point(0, 60);
            this.pnl_sidebar.Name = "pnl_sidebar";
            this.pnl_sidebar.Size = new System.Drawing.Size(200, 390);
            this.pnl_sidebar.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(0, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 50);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(0, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pnl_Ilaclar
            // 
            this.pnl_Ilaclar.Controls.Add(this.pnl_sidebar);
            this.pnl_Ilaclar.Controls.Add(this.pnl_content);
            this.pnl_Ilaclar.Controls.Add(this.pnl_header);
            this.pnl_Ilaclar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Ilaclar.Location = new System.Drawing.Point(0, 0);
            this.pnl_Ilaclar.Name = "pnl_Ilaclar";
            this.pnl_Ilaclar.Size = new System.Drawing.Size(800, 450);
            this.pnl_Ilaclar.TabIndex = 7;
            this.pnl_Ilaclar.Visible = false;
            // 
            // pnl_content
            // 
            this.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_content.Location = new System.Drawing.Point(0, 60);
            this.pnl_content.Name = "pnl_content";
            this.pnl_content.Size = new System.Drawing.Size(800, 390);
            this.pnl_content.TabIndex = 8;
            // 
            // pnl_header
            // 
            this.pnl_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(100)))));
            this.pnl_header.Controls.Add(this.button4);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(800, 60);
            this.pnl_header.TabIndex = 7;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Right;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.SystemColors.Control;
            this.button4.Location = new System.Drawing.Point(664, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(136, 60);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // frmlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnl_Ilaclar);
            this.Controls.Add(this.pnl_login);
            this.Name = "frmlogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmlogin";
            this.pnl_login.ResumeLayout(false);
            this.pnl_logincard.ResumeLayout(false);
            this.pnl_logincard.PerformLayout();
            this.pnl_sidebar.ResumeLayout(false);
            this.pnl_Ilaclar.ResumeLayout(false);
            this.pnl_header.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnl_login;
        private System.Windows.Forms.Panel pnl_sidebar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnl_Ilaclar;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Panel pnl_content;
        private System.Windows.Forms.Panel pnl_logincard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
    }
}

