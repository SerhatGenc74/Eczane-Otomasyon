namespace EczaneOtomasyon.UI
{
    partial class UcIlacStok
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_topbar = new System.Windows.Forms.Panel();
            this.btn_ilacekle = new System.Windows.Forms.Button();
            this.txt_find = new System.Windows.Forms.TextBox();
            this.btn_fiyat_guncelle = new System.Windows.Forms.Button();
            this.btn_update_stock = new System.Windows.Forms.Button();
            this.btn_tum_ilaclar = new System.Windows.Forms.Button();
            this.btn_sktt = new System.Windows.Forms.Button();
            this.btn_stok_kritik = new System.Windows.Forms.Button();
            this.dgw_ilaclar = new System.Windows.Forms.DataGridView();
            this.pnl_islembar = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_ilacbilgi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_adet = new System.Windows.Forms.NumericUpDown();
            this.pnl_topbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_ilaclar)).BeginInit();
            this.pnl_islembar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_adet)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_topbar
            // 
            this.pnl_topbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(100)))));
            this.pnl_topbar.Controls.Add(this.btn_ilacekle);
            this.pnl_topbar.Controls.Add(this.txt_find);
            this.pnl_topbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_topbar.Location = new System.Drawing.Point(0, 0);
            this.pnl_topbar.Name = "pnl_topbar";
            this.pnl_topbar.Size = new System.Drawing.Size(472, 50);
            this.pnl_topbar.TabIndex = 0;
            // 
            // btn_ilacekle
            // 
            this.btn_ilacekle.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_ilacekle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ilacekle.FlatAppearance.BorderSize = 0;
            this.btn_ilacekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ilacekle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_ilacekle.ForeColor = System.Drawing.Color.White;
            this.btn_ilacekle.Location = new System.Drawing.Point(340, 8);
            this.btn_ilacekle.Name = "btn_ilacekle";
            this.btn_ilacekle.Size = new System.Drawing.Size(120, 35);
            this.btn_ilacekle.TabIndex = 1;
            this.btn_ilacekle.Text = "İlaç Ekle";
            this.btn_ilacekle.UseVisualStyleBackColor = false;
            this.btn_ilacekle.Click += new System.EventHandler(this.btn_ilacekle_Click);
            // 
            // txt_find
            // 
            this.txt_find.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_find.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txt_find.Location = new System.Drawing.Point(12, 12);
            this.txt_find.Name = "txt_find";
            this.txt_find.Size = new System.Drawing.Size(180, 27);
            this.txt_find.TabIndex = 0;
            this.txt_find.Text = "Arama Kutusu";
            this.txt_find.TextChanged += new System.EventHandler(this.txt_find_TextChanged);
            // 
            // btn_fiyat_guncelle
            // 
            this.btn_fiyat_guncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btn_fiyat_guncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_fiyat_guncelle.FlatAppearance.BorderSize = 0;
            this.btn_fiyat_guncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_fiyat_guncelle.ForeColor = System.Drawing.Color.White;
            this.btn_fiyat_guncelle.Location = new System.Drawing.Point(103, 76);
            this.btn_fiyat_guncelle.Name = "btn_fiyat_guncelle";
            this.btn_fiyat_guncelle.Size = new System.Drawing.Size(132, 29);
            this.btn_fiyat_guncelle.TabIndex = 5;
            this.btn_fiyat_guncelle.Text = "Etiketi Fiyatını güncelle";
            this.btn_fiyat_guncelle.UseVisualStyleBackColor = false;
            this.btn_fiyat_guncelle.Click += new System.EventHandler(this.btn_fiyat_guncelle_Click);
            // 
            // btn_update_stock
            // 
            this.btn_update_stock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btn_update_stock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_update_stock.FlatAppearance.BorderSize = 0;
            this.btn_update_stock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_update_stock.ForeColor = System.Drawing.Color.White;
            this.btn_update_stock.Location = new System.Drawing.Point(4, 76);
            this.btn_update_stock.Name = "btn_update_stock";
            this.btn_update_stock.Size = new System.Drawing.Size(93, 29);
            this.btn_update_stock.TabIndex = 4;
            this.btn_update_stock.Text = "Stok Yenile";
            this.btn_update_stock.UseVisualStyleBackColor = false;
            this.btn_update_stock.Click += new System.EventHandler(this.btn_update_stock_Click);
            // 
            // btn_tum_ilaclar
            // 
            this.btn_tum_ilaclar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(100)))));
            this.btn_tum_ilaclar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_tum_ilaclar.FlatAppearance.BorderSize = 0;
            this.btn_tum_ilaclar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tum_ilaclar.ForeColor = System.Drawing.Color.White;
            this.btn_tum_ilaclar.Location = new System.Drawing.Point(241, 76);
            this.btn_tum_ilaclar.Name = "btn_tum_ilaclar";
            this.btn_tum_ilaclar.Size = new System.Drawing.Size(141, 29);
            this.btn_tum_ilaclar.TabIndex = 10;
            this.btn_tum_ilaclar.Text = "Tüm İlaçlar";
            this.btn_tum_ilaclar.UseVisualStyleBackColor = false;
            this.btn_tum_ilaclar.Click += new System.EventHandler(this.btn_tum_ilaclar_Click);
            // 
            // btn_sktt
            // 
            this.btn_sktt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_sktt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btn_sktt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sktt.FlatAppearance.BorderSize = 0;
            this.btn_sktt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sktt.ForeColor = System.Drawing.Color.White;
            this.btn_sktt.Location = new System.Drawing.Point(388, 62);
            this.btn_sktt.Name = "btn_sktt";
            this.btn_sktt.Size = new System.Drawing.Size(75, 43);
            this.btn_sktt.TabIndex = 3;
            this.btn_sktt.Text = "SKTT";
            this.btn_sktt.UseVisualStyleBackColor = false;
            this.btn_sktt.Click += new System.EventHandler(this.btn_sktt_Click);
            // 
            // btn_stok_kritik
            // 
            this.btn_stok_kritik.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_stok_kritik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btn_stok_kritik.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_stok_kritik.FlatAppearance.BorderSize = 0;
            this.btn_stok_kritik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stok_kritik.ForeColor = System.Drawing.Color.White;
            this.btn_stok_kritik.Location = new System.Drawing.Point(388, 13);
            this.btn_stok_kritik.Name = "btn_stok_kritik";
            this.btn_stok_kritik.Size = new System.Drawing.Size(75, 43);
            this.btn_stok_kritik.TabIndex = 2;
            this.btn_stok_kritik.Text = "Kritik Stok Listele";
            this.btn_stok_kritik.UseVisualStyleBackColor = false;
            this.btn_stok_kritik.Click += new System.EventHandler(this.btn_stok_kritik_Click);
            // 
            // dgw_ilaclar
            // 
            this.dgw_ilaclar.AllowUserToAddRows = false;
            this.dgw_ilaclar.AllowUserToDeleteRows = false;
            this.dgw_ilaclar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw_ilaclar.BackgroundColor = System.Drawing.Color.White;
            this.dgw_ilaclar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgw_ilaclar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgw_ilaclar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw_ilaclar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgw_ilaclar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_ilaclar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgw_ilaclar.EnableHeadersVisualStyles = false;
            this.dgw_ilaclar.GridColor = System.Drawing.Color.Gainsboro;
            this.dgw_ilaclar.Location = new System.Drawing.Point(0, 50);
            this.dgw_ilaclar.Name = "dgw_ilaclar";
            this.dgw_ilaclar.ReadOnly = true;
            this.dgw_ilaclar.RowHeadersVisible = false;
            this.dgw_ilaclar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_ilaclar.Size = new System.Drawing.Size(472, 365);
            this.dgw_ilaclar.TabIndex = 1;
            // 
            // pnl_islembar
            // 
            this.pnl_islembar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_islembar.Controls.Add(this.label3);
            this.pnl_islembar.Controls.Add(this.lbl_ilacbilgi);
            this.pnl_islembar.Controls.Add(this.label1);
            this.pnl_islembar.Controls.Add(this.nud_adet);
            this.pnl_islembar.Controls.Add(this.btn_stok_kritik);
            this.pnl_islembar.Controls.Add(this.btn_sktt);
            this.pnl_islembar.Controls.Add(this.btn_tum_ilaclar);
            this.pnl_islembar.Controls.Add(this.btn_fiyat_guncelle);
            this.pnl_islembar.Controls.Add(this.btn_update_stock);
            this.pnl_islembar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_islembar.Location = new System.Drawing.Point(0, 298);
            this.pnl_islembar.Name = "pnl_islembar";
            this.pnl_islembar.Size = new System.Drawing.Size(472, 117);
            this.pnl_islembar.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(125, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Adet/Fiyat";
            // 
            // lbl_ilacbilgi
            // 
            this.lbl_ilacbilgi.AutoSize = true;
            this.lbl_ilacbilgi.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_ilacbilgi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(100)))));
            this.lbl_ilacbilgi.Location = new System.Drawing.Point(3, 22);
            this.lbl_ilacbilgi.Name = "lbl_ilacbilgi";
            this.lbl_ilacbilgi.Size = new System.Drawing.Size(81, 17);
            this.lbl_ilacbilgi.TabIndex = 8;
            this.lbl_ilacbilgi.Text = "Seçilen İlaç : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Hızlı İşlemler Paneli";
            // 
            // nud_adet
            // 
            this.nud_adet.DecimalPlaces = 2;
            this.nud_adet.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.nud_adet.Location = new System.Drawing.Point(4, 45);
            this.nud_adet.Maximum = new decimal(new int[] {
            655356,
            0,
            0,
            0});
            this.nud_adet.Name = "nud_adet";
            this.nud_adet.Size = new System.Drawing.Size(115, 25);
            this.nud_adet.TabIndex = 6;
            // 
            // UcIlacStok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnl_islembar);
            this.Controls.Add(this.dgw_ilaclar);
            this.Controls.Add(this.pnl_topbar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "UcIlacStok";
            this.Size = new System.Drawing.Size(472, 415);
            this.Load += new System.EventHandler(this.UcIlacStok_Load);
            this.pnl_topbar.ResumeLayout(false);
            this.pnl_topbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_ilaclar)).EndInit();
            this.pnl_islembar.ResumeLayout(false);
            this.pnl_islembar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_adet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_topbar;
        private System.Windows.Forms.TextBox txt_find;
        private System.Windows.Forms.DataGridView dgw_ilaclar;
        private System.Windows.Forms.Button btn_ilacekle;
        private System.Windows.Forms.Button btn_stok_kritik;
        private System.Windows.Forms.Button btn_sktt;
        private System.Windows.Forms.Button btn_fiyat_guncelle;
        private System.Windows.Forms.Button btn_update_stock;
        private System.Windows.Forms.Button btn_tum_ilaclar;
        private System.Windows.Forms.Panel pnl_islembar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_adet;
        private System.Windows.Forms.Label lbl_ilacbilgi;
        private System.Windows.Forms.Label label3;
    }
}
