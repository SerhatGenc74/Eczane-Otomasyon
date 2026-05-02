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
            this.btn_ilacekle.Location = new System.Drawing.Point(309, 0);
            this.btn_ilacekle.Name = "btn_ilacekle";
            this.btn_ilacekle.Size = new System.Drawing.Size(124, 35);
            this.btn_ilacekle.TabIndex = 1;
            this.btn_ilacekle.Text = "İlaç Ekle";
            this.btn_ilacekle.UseVisualStyleBackColor = true;
            this.btn_ilacekle.Click += new System.EventHandler(this.btn_ilacekle_Click);
            // 
            // txt_find
            // 
            this.txt_find.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_find.Location = new System.Drawing.Point(6, 3);
            this.txt_find.Name = "txt_find";
            this.txt_find.Size = new System.Drawing.Size(147, 20);
            this.txt_find.TabIndex = 0;
            this.txt_find.Text = "Arama Kutusu";
            this.txt_find.TextChanged += new System.EventHandler(this.txt_find_TextChanged);
            // 
            // btn_fiyat_guncelle
            // 
            this.btn_fiyat_guncelle.Location = new System.Drawing.Point(99, 88);
            this.btn_fiyat_guncelle.Name = "btn_fiyat_guncelle";
            this.btn_fiyat_guncelle.Size = new System.Drawing.Size(132, 29);
            this.btn_fiyat_guncelle.TabIndex = 5;
            this.btn_fiyat_guncelle.Text = "Etiketi Fiyatını güncelle";
            this.btn_fiyat_guncelle.UseVisualStyleBackColor = true;
            this.btn_fiyat_guncelle.Click += new System.EventHandler(this.btn_fiyat_guncelle_Click);
            // 
            // btn_update_stock
            // 
            this.btn_update_stock.Location = new System.Drawing.Point(0, 88);
            this.btn_update_stock.Name = "btn_update_stock";
            this.btn_update_stock.Size = new System.Drawing.Size(93, 29);
            this.btn_update_stock.TabIndex = 4;
            this.btn_update_stock.Text = "Stok Yenile";
            this.btn_update_stock.UseVisualStyleBackColor = true;
            this.btn_update_stock.Click += new System.EventHandler(this.btn_update_stock_Click);
            // 
            // btn_sktt
            // 
            this.btn_sktt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_sktt.Location = new System.Drawing.Point(408, 53);
            this.btn_sktt.Name = "btn_sktt";
            this.btn_sktt.Size = new System.Drawing.Size(61, 61);
            this.btn_sktt.TabIndex = 3;
            this.btn_sktt.Text = "SKTT";
            this.btn_sktt.UseVisualStyleBackColor = true;
            this.btn_sktt.Click += new System.EventHandler(this.btn_sktt_Click);
            // 
            // btn_stok_kritik
            // 
            this.btn_stok_kritik.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_stok_kritik.Location = new System.Drawing.Point(408, 3);
            this.btn_stok_kritik.Name = "btn_stok_kritik";
            this.btn_stok_kritik.Size = new System.Drawing.Size(61, 47);
            this.btn_stok_kritik.TabIndex = 2;
            this.btn_stok_kritik.Text = "Kritik Stok Listele";
            this.btn_stok_kritik.UseVisualStyleBackColor = true;
            this.btn_stok_kritik.Click += new System.EventHandler(this.btn_stok_kritik_Click);
            // 
            // dgw_ilaclar
            // 
            this.dgw_ilaclar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_ilaclar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgw_ilaclar.Location = new System.Drawing.Point(0, 50);
            this.dgw_ilaclar.Name = "dgw_ilaclar";
            this.dgw_ilaclar.Size = new System.Drawing.Size(472, 365);
            this.dgw_ilaclar.TabIndex = 1;
            // 
            // pnl_islembar
            // 
            this.pnl_islembar.Controls.Add(this.label3);
            this.pnl_islembar.Controls.Add(this.lbl_ilacbilgi);
            this.pnl_islembar.Controls.Add(this.label1);
            this.pnl_islembar.Controls.Add(this.nud_adet);
            this.pnl_islembar.Controls.Add(this.btn_stok_kritik);
            this.pnl_islembar.Controls.Add(this.btn_sktt);
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
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(140, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Adet/Fiyat";
            // 
            // lbl_ilacbilgi
            // 
            this.lbl_ilacbilgi.AutoSize = true;
            this.lbl_ilacbilgi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_ilacbilgi.Location = new System.Drawing.Point(3, 33);
            this.lbl_ilacbilgi.Name = "lbl_ilacbilgi";
            this.lbl_ilacbilgi.Size = new System.Drawing.Size(91, 17);
            this.lbl_ilacbilgi.TabIndex = 8;
            this.lbl_ilacbilgi.Text = "Seçilen İlaç : ";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(-1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Hızlı İşlemler Paneli";
            // 
            // nud_adet
            // 
            this.nud_adet.DecimalPlaces = 2;
            this.nud_adet.Location = new System.Drawing.Point(3, 53);
            this.nud_adet.Maximum = new decimal(new int[] {
            655356,
            0,
            0,
            0});
            this.nud_adet.Name = "nud_adet";
            this.nud_adet.Size = new System.Drawing.Size(120, 20);
            this.nud_adet.TabIndex = 6;
            // 
            // UcIlacStok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_islembar);
            this.Controls.Add(this.dgw_ilaclar);
            this.Controls.Add(this.pnl_topbar);
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
        private System.Windows.Forms.Panel pnl_islembar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_adet;
        private System.Windows.Forms.Label lbl_ilacbilgi;
        private System.Windows.Forms.Label label3;
    }
}
