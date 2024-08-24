namespace Zekotec01
{
    partial class FormCihazlar
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_cihazTipi = new System.Windows.Forms.ComboBox();
            this.button_ChzSil = new System.Windows.Forms.Button();
            this.button_ChzGuncelle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_ChazEkle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_chzport = new System.Windows.Forms.TextBox();
            this.textBox_chzip = new System.Windows.Forms.TextBox();
            this.textBox_chzAdi = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Cihazlar = new System.Windows.Forms.DataGridView();
            this.label_Id = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cihazlar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox_cihazTipi);
            this.groupBox1.Controls.Add(this.button_ChzSil);
            this.groupBox1.Controls.Add(this.button_ChzGuncelle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button_ChazEkle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_chzport);
            this.groupBox1.Controls.Add(this.textBox_chzip);
            this.groupBox1.Controls.Add(this.textBox_chzAdi);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 181);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cihaz Bilgileri";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cihaz Tipi";
            // 
            // comboBox_cihazTipi
            // 
            this.comboBox_cihazTipi.FormattingEnabled = true;
            this.comboBox_cihazTipi.Location = new System.Drawing.Point(114, 49);
            this.comboBox_cihazTipi.Name = "comboBox_cihazTipi";
            this.comboBox_cihazTipi.Size = new System.Drawing.Size(123, 21);
            this.comboBox_cihazTipi.TabIndex = 6;
            // 
            // button_ChzSil
            // 
            this.button_ChzSil.Location = new System.Drawing.Point(6, 152);
            this.button_ChzSil.Name = "button_ChzSil";
            this.button_ChzSil.Size = new System.Drawing.Size(68, 23);
            this.button_ChzSil.TabIndex = 5;
            this.button_ChzSil.Text = "Cihaz Sil";
            this.button_ChzSil.UseVisualStyleBackColor = true;
            this.button_ChzSil.Click += new System.EventHandler(this.button_ChzSil_Click);
            // 
            // button_ChzGuncelle
            // 
            this.button_ChzGuncelle.Location = new System.Drawing.Point(154, 152);
            this.button_ChzGuncelle.Name = "button_ChzGuncelle";
            this.button_ChzGuncelle.Size = new System.Drawing.Size(94, 23);
            this.button_ChzGuncelle.TabIndex = 4;
            this.button_ChzGuncelle.Text = "Cihaz Güncelle";
            this.button_ChzGuncelle.UseVisualStyleBackColor = true;
            this.button_ChzGuncelle.Click += new System.EventHandler(this.button_ChzGuncelle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cihaz IP";
            // 
            // button_ChazEkle
            // 
            this.button_ChazEkle.Location = new System.Drawing.Point(80, 152);
            this.button_ChazEkle.Name = "button_ChazEkle";
            this.button_ChazEkle.Size = new System.Drawing.Size(68, 23);
            this.button_ChazEkle.TabIndex = 3;
            this.button_ChazEkle.Text = "Cihaz Ekle";
            this.button_ChazEkle.UseVisualStyleBackColor = true;
            this.button_ChazEkle.Click += new System.EventHandler(this.button_ChazEkle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cihaz Adı";
            // 
            // textBox_chzport
            // 
            this.textBox_chzport.Location = new System.Drawing.Point(114, 104);
            this.textBox_chzport.Name = "textBox_chzport";
            this.textBox_chzport.Size = new System.Drawing.Size(57, 20);
            this.textBox_chzport.TabIndex = 2;
            this.textBox_chzport.Text = "4370";
            // 
            // textBox_chzip
            // 
            this.textBox_chzip.Location = new System.Drawing.Point(114, 76);
            this.textBox_chzip.Name = "textBox_chzip";
            this.textBox_chzip.Size = new System.Drawing.Size(123, 20);
            this.textBox_chzip.TabIndex = 1;
            this.textBox_chzip.Text = "192.168.1.201";
            // 
            // textBox_chzAdi
            // 
            this.textBox_chzAdi.Location = new System.Drawing.Point(114, 20);
            this.textBox_chzAdi.Name = "textBox_chzAdi";
            this.textBox_chzAdi.Size = new System.Drawing.Size(123, 20);
            this.textBox_chzAdi.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_Cihazlar);
            this.groupBox2.Location = new System.Drawing.Point(279, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 181);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cihazlar";
            // 
            // dataGridView_Cihazlar
            // 
            this.dataGridView_Cihazlar.AllowUserToAddRows = false;
            this.dataGridView_Cihazlar.AllowUserToDeleteRows = false;
            this.dataGridView_Cihazlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Cihazlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Cihazlar.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_Cihazlar.Name = "dataGridView_Cihazlar";
            this.dataGridView_Cihazlar.ReadOnly = true;
            this.dataGridView_Cihazlar.RowHeadersVisible = false;
            this.dataGridView_Cihazlar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Cihazlar.Size = new System.Drawing.Size(330, 162);
            this.dataGridView_Cihazlar.TabIndex = 0;
            this.dataGridView_Cihazlar.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Cihazlar_CellMouseDoubleClick);
            this.dataGridView_Cihazlar.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Cihazlar_RowHeaderMouseDoubleClick);
            // 
            // label_Id
            // 
            this.label_Id.AutoSize = true;
            this.label_Id.Location = new System.Drawing.Point(577, 9);
            this.label_Id.Name = "label_Id";
            this.label_Id.Size = new System.Drawing.Size(0, 13);
            this.label_Id.TabIndex = 2;
            // 
            // FormCihazlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 207);
            this.Controls.Add(this.label_Id);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormCihazlar";
            this.Text = "FormCihazlar";
            this.Load += new System.EventHandler(this.FormCihazlar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cihazlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_chzport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_chzip;
        private System.Windows.Forms.TextBox textBox_chzAdi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_Cihazlar;
        private System.Windows.Forms.Button button_ChzSil;
        private System.Windows.Forms.Button button_ChzGuncelle;
        private System.Windows.Forms.Button button_ChazEkle;
        private System.Windows.Forms.Label label_Id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_cihazTipi;
    }
}