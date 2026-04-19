namespace EczaneOtomasyon.UI
{
    partial class FrmIlacEkle
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
            this.txt_ilacad = new System.Windows.Forms.TextBox();
            this.cbox_kategori = new System.Windows.Forms.ComboBox();
            this.nud_stokadet = new System.Windows.Forms.NumericUpDown();
            this.nud_kritik = new System.Windows.Forms.NumericUpDown();
            this.dtp_sktt = new System.Windows.Forms.DateTimePicker();
            this.nud_birimfiyat = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_iptal = new System.Windows.Forms.Button();
            this.btn_kaydet = new System.Windows.Forms.Button();
            this.cbox_recetetur = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_stokadet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_kritik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_birimfiyat)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_ilacad
            // 
            this.txt_ilacad.Location = new System.Drawing.Point(82, 56);
            this.txt_ilacad.Name = "txt_ilacad";
            this.txt_ilacad.Size = new System.Drawing.Size(202, 20);
            this.txt_ilacad.TabIndex = 0;
            // 
            // cbox_kategori
            // 
            this.cbox_kategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_kategori.FormattingEnabled = true;
            this.cbox_kategori.Location = new System.Drawing.Point(83, 95);
            this.cbox_kategori.Name = "cbox_kategori";
            this.cbox_kategori.Size = new System.Drawing.Size(201, 21);
            this.cbox_kategori.TabIndex = 1;
            // 
            // nud_stokadet
            // 
            this.nud_stokadet.Location = new System.Drawing.Point(84, 135);
            this.nud_stokadet.Name = "nud_stokadet";
            this.nud_stokadet.Size = new System.Drawing.Size(200, 20);
            this.nud_stokadet.TabIndex = 2;
            // 
            // nud_kritik
            // 
            this.nud_kritik.Location = new System.Drawing.Point(84, 174);
            this.nud_kritik.Name = "nud_kritik";
            this.nud_kritik.Size = new System.Drawing.Size(200, 20);
            this.nud_kritik.TabIndex = 3;
            // 
            // dtp_sktt
            // 
            this.dtp_sktt.Location = new System.Drawing.Point(84, 252);
            this.dtp_sktt.Name = "dtp_sktt";
            this.dtp_sktt.Size = new System.Drawing.Size(200, 20);
            this.dtp_sktt.TabIndex = 4;
            // 
            // nud_birimfiyat
            // 
            this.nud_birimfiyat.Location = new System.Drawing.Point(84, 213);
            this.nud_birimfiyat.Name = "nud_birimfiyat";
            this.nud_birimfiyat.Size = new System.Drawing.Size(200, 20);
            this.nud_birimfiyat.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "İlaç Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kategori";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Stok Adet";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Kritik Seviye";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Son Kullanma Tarihi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Birim Fiyat";
            // 
            // btn_iptal
            // 
            this.btn_iptal.BackColor = System.Drawing.Color.Red;
            this.btn_iptal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_iptal.Location = new System.Drawing.Point(103, 305);
            this.btn_iptal.Name = "btn_iptal";
            this.btn_iptal.Size = new System.Drawing.Size(75, 23);
            this.btn_iptal.TabIndex = 7;
            this.btn_iptal.Text = "İptal";
            this.btn_iptal.UseVisualStyleBackColor = false;
            this.btn_iptal.Click += new System.EventHandler(this.btn_iptal_Click);
            // 
            // btn_kaydet
            // 
            this.btn_kaydet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_kaydet.Location = new System.Drawing.Point(184, 305);
            this.btn_kaydet.Name = "btn_kaydet";
            this.btn_kaydet.Size = new System.Drawing.Size(75, 23);
            this.btn_kaydet.TabIndex = 7;
            this.btn_kaydet.Text = "Kaydet";
            this.btn_kaydet.UseVisualStyleBackColor = true;
            this.btn_kaydet.Click += new System.EventHandler(this.btn_kaydet_Click);
            // 
            // cbox_recetetur
            // 
            this.cbox_recetetur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_recetetur.FormattingEnabled = true;
            this.cbox_recetetur.Location = new System.Drawing.Point(290, 95);
            this.cbox_recetetur.Name = "cbox_recetetur";
            this.cbox_recetetur.Size = new System.Drawing.Size(201, 21);
            this.cbox_recetetur.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(287, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Reçete Türü";
            // 
            // FrmIlacEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 372);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbox_recetetur);
            this.Controls.Add(this.btn_kaydet);
            this.Controls.Add(this.btn_iptal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nud_birimfiyat);
            this.Controls.Add(this.dtp_sktt);
            this.Controls.Add(this.nud_kritik);
            this.Controls.Add(this.nud_stokadet);
            this.Controls.Add(this.cbox_kategori);
            this.Controls.Add(this.txt_ilacad);
            this.Name = "FrmIlacEkle";
            this.Text = "frmIlacEkle";
            this.Load += new System.EventHandler(this.FrmIlacEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_stokadet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_kritik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_birimfiyat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ilacad;
        private System.Windows.Forms.ComboBox cbox_kategori;
        private System.Windows.Forms.NumericUpDown nud_stokadet;
        private System.Windows.Forms.NumericUpDown nud_kritik;
        private System.Windows.Forms.DateTimePicker dtp_sktt;
        private System.Windows.Forms.NumericUpDown nud_birimfiyat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_iptal;
        private System.Windows.Forms.Button btn_kaydet;
        private System.Windows.Forms.ComboBox cbox_recetetur;
        private System.Windows.Forms.Label label7;
    }
}