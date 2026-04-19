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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnl_topbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_topbar
            // 
            this.pnl_topbar.Controls.Add(this.btn_ilacekle);
            this.pnl_topbar.Controls.Add(this.txt_find);
            this.pnl_topbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_topbar.Location = new System.Drawing.Point(0, 0);
            this.pnl_topbar.Name = "pnl_topbar";
            this.pnl_topbar.Size = new System.Drawing.Size(236, 70);
            this.pnl_topbar.TabIndex = 0;
            // 
            // btn_ilacekle
            // 
            this.btn_ilacekle.Location = new System.Drawing.Point(3, 3);
            this.btn_ilacekle.Name = "btn_ilacekle";
            this.btn_ilacekle.Size = new System.Drawing.Size(75, 23);
            this.btn_ilacekle.TabIndex = 1;
            this.btn_ilacekle.Text = "İlaç Ekle";
            this.btn_ilacekle.UseVisualStyleBackColor = true;
            this.btn_ilacekle.Click += new System.EventHandler(this.btn_ilacekle_Click);
            // 
            // txt_find
            // 
            this.txt_find.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_find.Location = new System.Drawing.Point(126, 6);
            this.txt_find.Name = "txt_find";
            this.txt_find.Size = new System.Drawing.Size(97, 20);
            this.txt_find.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(236, 121);
            this.dataGridView1.TabIndex = 1;
            // 
            // UcIlacStok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnl_topbar);
            this.Name = "UcIlacStok";
            this.Size = new System.Drawing.Size(236, 191);
            this.pnl_topbar.ResumeLayout(false);
            this.pnl_topbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_topbar;
        private System.Windows.Forms.TextBox txt_find;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_ilacekle;
    }
}
