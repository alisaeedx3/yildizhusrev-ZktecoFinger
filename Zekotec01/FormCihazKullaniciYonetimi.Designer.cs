namespace Zekotec01
{
    partial class FormCihazKullaniciYonetimi
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_OgrGüncelle = new System.Windows.Forms.Button();
            this.label_status = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.button6);
            this.groupBox4.Location = new System.Drawing.Point(12, 130);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(284, 104);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tüm Kayıtları Güncelleme";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGreen;
            this.label7.Location = new System.Drawing.Point(9, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(254, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Veri Tabanındaki isimlerle güncellenecektir ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cihaz kullanıcı bilgileri";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 53);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(251, 31);
            this.button6.TabIndex = 1;
            this.button6.Text = "Tüm Kayıtları Güncelle";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Cihaz Bağlantı Durumu";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.button_OgrGüncelle);
            this.groupBox3.Location = new System.Drawing.Point(12, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(284, 103);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // button_OgrGüncelle
            // 
            this.button_OgrGüncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OgrGüncelle.Location = new System.Drawing.Point(43, 64);
            this.button_OgrGüncelle.Name = "button_OgrGüncelle";
            this.button_OgrGüncelle.Size = new System.Drawing.Size(205, 31);
            this.button_OgrGüncelle.TabIndex = 1;
            this.button_OgrGüncelle.Text = "Cizhaz Oku";
            this.button_OgrGüncelle.UseVisualStyleBackColor = true;
            this.button_OgrGüncelle.Click += new System.EventHandler(this.button_OgrGüncelle_Click);
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(132, 237);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(86, 13);
            this.label_status.TabIndex = 14;
            this.label_status.Text = "Cihaz Bağlı Değil";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(23, 16);
            this.label2.MaximumSize = new System.Drawing.Size(275, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 45);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seçilen Cihaza Ait Kullanıcılar Kontrol Edilir ve Veritabanı ile karşılaştırılara" +
    "k Sonuçlar Bildirilir";
            // 
            // FormCihazKullaniciYonetimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 278);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label_status);
            this.Name = "FormCihazKullaniciYonetimi";
            this.Text = "FormCihazKullaniciYonetimi";
            this.Load += new System.EventHandler(this.FormCihazKullaniciYonetimi_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_OgrGüncelle;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Label label2;
    }
}