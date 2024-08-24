namespace Zekotec01
{
    partial class FormYeniHareketEkle
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
            this.dateTimePicker_hareket = new System.Windows.Forms.DateTimePicker();
            this.button_hareket_ekle = new System.Windows.Forms.Button();
            this.comboBox_cihaz = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker_hareket
            // 
            this.dateTimePicker_hareket.CustomFormat = "";
            this.dateTimePicker_hareket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker_hareket.Location = new System.Drawing.Point(56, 63);
            this.dateTimePicker_hareket.Name = "dateTimePicker_hareket";
            this.dateTimePicker_hareket.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker_hareket.TabIndex = 0;
            // 
            // button_hareket_ekle
            // 
            this.button_hareket_ekle.Location = new System.Drawing.Point(158, 120);
            this.button_hareket_ekle.Name = "button_hareket_ekle";
            this.button_hareket_ekle.Size = new System.Drawing.Size(83, 28);
            this.button_hareket_ekle.TabIndex = 1;
            this.button_hareket_ekle.Text = "Tamam";
            this.button_hareket_ekle.UseVisualStyleBackColor = true;
            this.button_hareket_ekle.Click += new System.EventHandler(this.button_hareket_ekle_Click);
            // 
            // comboBox_cihaz
            // 
            this.comboBox_cihaz.FormattingEnabled = true;
            this.comboBox_cihaz.Location = new System.Drawing.Point(56, 36);
            this.comboBox_cihaz.Name = "comboBox_cihaz";
            this.comboBox_cihaz.Size = new System.Drawing.Size(200, 21);
            this.comboBox_cihaz.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(247, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "İptal";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormYeniHareketEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 160);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox_cihaz);
            this.Controls.Add(this.button_hareket_ekle);
            this.Controls.Add(this.dateTimePicker_hareket);
            this.Name = "FormYeniHareketEkle";
            this.Text = "FormYeniHareketEkle";
            this.Load += new System.EventHandler(this.FormYeniHareketEkle_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_hareket;
        private System.Windows.Forms.Button button_hareket_ekle;
        private System.Windows.Forms.ComboBox comboBox_cihaz;
        private System.Windows.Forms.Button button1;
    }
}