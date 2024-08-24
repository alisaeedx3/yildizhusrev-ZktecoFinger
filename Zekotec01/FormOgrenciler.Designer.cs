using System;

namespace Zekotec01
{
    partial class FormOgrenciler
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.dataGridView_ogrliste = new System.Windows.Forms.DataGridView();
            this.buttonOgrYeniEkle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_KayitDurum = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button_resim_cek = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox_islem = new System.Windows.Forms.GroupBox();
            this.textBoxCihazID = new System.Windows.Forms.TextBox();
            this.button_CihazGuncelle = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonOgrSil = new System.Windows.Forms.Button();
            this.textBoxnotlar = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_Adres = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_AileTel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Tc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_OdaNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_CepTel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonOgrGuncelle = new System.Windows.Forms.Button();
            this.comboBox_Durum = new System.Windows.Forms.ComboBox();
            this.textBox_Ad = new System.Windows.Forms.TextBox();
            this.label_UserID = new System.Windows.Forms.Label();
            this.label_Durum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label_İzinID = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button_güncelle = new System.Windows.Forms.Button();
            this.button_sil = new System.Windows.Forms.Button();
            this.buttonYeniizinEkle = new System.Windows.Forms.Button();
            this.dateTimePickerStop = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewIzinbilgileri = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button_yenihareketekle = new System.Windows.Forms.Button();
            this.dateTimePicker_stop_tum = new System.Windows.Forms.DateTimePicker();
            this.button_CihazOkuma = new System.Windows.Forms.Button();
            this.dateTimePicker_start_tum = new System.Windows.Forms.DateTimePicker();
            this.dataGridView_tum_veriler = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ogrliste)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_islem.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIzinbilgileri)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tum_veriler)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonSearch);
            this.groupBox2.Controls.Add(this.textBoxSearch);
            this.groupBox2.Controls.Add(this.dataGridView_ogrliste);
            this.groupBox2.Controls.Add(this.buttonOgrYeniEkle);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 534);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Öğrenciler";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Image = global::Zekotec01.Properties.Resources.search_3_16;
            this.buttonSearch.Location = new System.Drawing.Point(156, 68);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(45, 26);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxSearch.Location = new System.Drawing.Point(3, 68);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(147, 26);
            this.textBoxSearch.TabIndex = 1;
            // 
            // dataGridView_ogrliste
            // 
            this.dataGridView_ogrliste.AllowUserToAddRows = false;
            this.dataGridView_ogrliste.AllowUserToDeleteRows = false;
            this.dataGridView_ogrliste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ogrliste.Location = new System.Drawing.Point(3, 102);
            this.dataGridView_ogrliste.Name = "dataGridView_ogrliste";
            this.dataGridView_ogrliste.ReadOnly = true;
            this.dataGridView_ogrliste.Size = new System.Drawing.Size(198, 426);
            this.dataGridView_ogrliste.TabIndex = 0;
            this.dataGridView_ogrliste.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_ogrliste_CellMouseDoubleClick);
            this.dataGridView_ogrliste.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_ogrliste_RowHeaderMouseDoubleClick);
            // 
            // buttonOgrYeniEkle
            // 
            this.buttonOgrYeniEkle.BackColor = System.Drawing.Color.Lime;
            this.buttonOgrYeniEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonOgrYeniEkle.Location = new System.Drawing.Point(6, 19);
            this.buttonOgrYeniEkle.Name = "buttonOgrYeniEkle";
            this.buttonOgrYeniEkle.Size = new System.Drawing.Size(195, 36);
            this.buttonOgrYeniEkle.TabIndex = 6;
            this.buttonOgrYeniEkle.Text = "Yeni Kayıt";
            this.buttonOgrYeniEkle.UseVisualStyleBackColor = false;
            this.buttonOgrYeniEkle.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_KayitDurum);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button_resim_cek);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.groupBox_islem);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 490);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Öğrenci Bilgileri";
            // 
            // label_KayitDurum
            // 
            this.label_KayitDurum.AutoSize = true;
            this.label_KayitDurum.Location = new System.Drawing.Point(6, 299);
            this.label_KayitDurum.Name = "label_KayitDurum";
            this.label_KayitDurum.Size = new System.Drawing.Size(63, 13);
            this.label_KayitDurum.TabIndex = 7;
            this.label_KayitDurum.Text = "Güncelleme";
            this.label_KayitDurum.Visible = false;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Image = global::Zekotec01.Properties.Resources.add_file_64;
            this.button4.Location = new System.Drawing.Point(90, 198);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 66);
            this.button4.TabIndex = 7;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button_resim_cek
            // 
            this.button_resim_cek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_resim_cek.ForeColor = System.Drawing.Color.Transparent;
            this.button_resim_cek.Image = global::Zekotec01.Properties.Resources.camera_2_64;
            this.button_resim_cek.Location = new System.Drawing.Point(6, 198);
            this.button_resim_cek.Name = "button_resim_cek";
            this.button_resim_cek.Size = new System.Drawing.Size(66, 66);
            this.button_resim_cek.TabIndex = 6;
            this.button_resim_cek.UseVisualStyleBackColor = true;
            this.button_resim_cek.Click += new System.EventHandler(this.button_resim_cek_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::Zekotec01.Properties.Resources.BayanAvatar;
            this.pictureBox1.Location = new System.Drawing.Point(6, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // groupBox_islem
            // 
            this.groupBox_islem.Controls.Add(this.textBoxCihazID);
            this.groupBox_islem.Controls.Add(this.button_CihazGuncelle);
            this.groupBox_islem.Controls.Add(this.label8);
            this.groupBox_islem.Controls.Add(this.buttonOgrSil);
            this.groupBox_islem.Controls.Add(this.textBoxnotlar);
            this.groupBox_islem.Controls.Add(this.label12);
            this.groupBox_islem.Controls.Add(this.textBox_Adres);
            this.groupBox_islem.Controls.Add(this.label9);
            this.groupBox_islem.Controls.Add(this.textBox_AileTel);
            this.groupBox_islem.Controls.Add(this.label6);
            this.groupBox_islem.Controls.Add(this.textBox_Tc);
            this.groupBox_islem.Controls.Add(this.label11);
            this.groupBox_islem.Controls.Add(this.textBox_OdaNo);
            this.groupBox_islem.Controls.Add(this.label10);
            this.groupBox_islem.Controls.Add(this.textBox_CepTel);
            this.groupBox_islem.Controls.Add(this.label4);
            this.groupBox_islem.Controls.Add(this.buttonOgrGuncelle);
            this.groupBox_islem.Controls.Add(this.comboBox_Durum);
            this.groupBox_islem.Controls.Add(this.textBox_Ad);
            this.groupBox_islem.Controls.Add(this.label_UserID);
            this.groupBox_islem.Controls.Add(this.label_Durum);
            this.groupBox_islem.Controls.Add(this.label2);
            this.groupBox_islem.Location = new System.Drawing.Point(162, 19);
            this.groupBox_islem.Name = "groupBox_islem";
            this.groupBox_islem.Size = new System.Drawing.Size(322, 465);
            this.groupBox_islem.TabIndex = 4;
            this.groupBox_islem.TabStop = false;
            // 
            // textBoxCihazID
            // 
            this.textBoxCihazID.Location = new System.Drawing.Point(255, 33);
            this.textBoxCihazID.Name = "textBoxCihazID";
            this.textBoxCihazID.Size = new System.Drawing.Size(58, 20);
            this.textBoxCihazID.TabIndex = 1;
            // 
            // button_CihazGuncelle
            // 
            this.button_CihazGuncelle.Enabled = false;
            this.button_CihazGuncelle.Location = new System.Drawing.Point(10, 417);
            this.button_CihazGuncelle.Name = "button_CihazGuncelle";
            this.button_CihazGuncelle.Size = new System.Drawing.Size(115, 36);
            this.button_CihazGuncelle.TabIndex = 21;
            this.button_CihazGuncelle.Text = "Cihaz Güncelle";
            this.button_CihazGuncelle.UseVisualStyleBackColor = true;
            this.button_CihazGuncelle.Click += new System.EventHandler(this.button5_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Cihaz ID";
            // 
            // buttonOgrSil
            // 
            this.buttonOgrSil.Image = global::Zekotec01.Properties.Resources.delete_16;
            this.buttonOgrSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOgrSil.Location = new System.Drawing.Point(131, 417);
            this.buttonOgrSil.Name = "buttonOgrSil";
            this.buttonOgrSil.Size = new System.Drawing.Size(88, 36);
            this.buttonOgrSil.TabIndex = 16;
            this.buttonOgrSil.Text = "Sil";
            this.buttonOgrSil.UseVisualStyleBackColor = true;
            this.buttonOgrSil.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxnotlar
            // 
            this.textBoxnotlar.Location = new System.Drawing.Point(163, 313);
            this.textBoxnotlar.Multiline = true;
            this.textBoxnotlar.Name = "textBoxnotlar";
            this.textBoxnotlar.Size = new System.Drawing.Size(150, 87);
            this.textBoxnotlar.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 320);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Notlar";
            // 
            // textBox_Adres
            // 
            this.textBox_Adres.Location = new System.Drawing.Point(163, 206);
            this.textBox_Adres.Multiline = true;
            this.textBox_Adres.Name = "textBox_Adres";
            this.textBox_Adres.Size = new System.Drawing.Size(150, 87);
            this.textBox_Adres.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Adres";
            // 
            // textBox_AileTel
            // 
            this.textBox_AileTel.Location = new System.Drawing.Point(163, 180);
            this.textBox_AileTel.Name = "textBox_AileTel";
            this.textBox_AileTel.Size = new System.Drawing.Size(150, 20);
            this.textBox_AileTel.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Aile Telefonu";
            // 
            // textBox_Tc
            // 
            this.textBox_Tc.Location = new System.Drawing.Point(163, 85);
            this.textBox_Tc.Name = "textBox_Tc";
            this.textBox_Tc.Size = new System.Drawing.Size(150, 20);
            this.textBox_Tc.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Tc Kimlik No";
            // 
            // textBox_OdaNo
            // 
            this.textBox_OdaNo.Location = new System.Drawing.Point(251, 137);
            this.textBox_OdaNo.Name = "textBox_OdaNo";
            this.textBox_OdaNo.Size = new System.Drawing.Size(62, 20);
            this.textBox_OdaNo.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Oda Numarası";
            // 
            // textBox_CepTel
            // 
            this.textBox_CepTel.Location = new System.Drawing.Point(163, 111);
            this.textBox_CepTel.Name = "textBox_CepTel";
            this.textBox_CepTel.Size = new System.Drawing.Size(150, 20);
            this.textBox_CepTel.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Cep Telefonu";
            // 
            // buttonOgrGuncelle
            // 
            this.buttonOgrGuncelle.Image = global::Zekotec01.Properties.Resources.save_16;
            this.buttonOgrGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOgrGuncelle.Location = new System.Drawing.Point(225, 417);
            this.buttonOgrGuncelle.Name = "buttonOgrGuncelle";
            this.buttonOgrGuncelle.Size = new System.Drawing.Size(88, 36);
            this.buttonOgrGuncelle.TabIndex = 9;
            this.buttonOgrGuncelle.Text = "Kaydet";
            this.buttonOgrGuncelle.UseVisualStyleBackColor = true;
            this.buttonOgrGuncelle.Click += new System.EventHandler(this.button_Kaydet_Click);
            // 
            // comboBox_Durum
            // 
            this.comboBox_Durum.FormattingEnabled = true;
            this.comboBox_Durum.Location = new System.Drawing.Point(51, 7);
            this.comboBox_Durum.Name = "comboBox_Durum";
            this.comboBox_Durum.Size = new System.Drawing.Size(102, 21);
            this.comboBox_Durum.TabIndex = 5;
            this.comboBox_Durum.Visible = false;
            // 
            // textBox_Ad
            // 
            this.textBox_Ad.Location = new System.Drawing.Point(163, 59);
            this.textBox_Ad.Name = "textBox_Ad";
            this.textBox_Ad.Size = new System.Drawing.Size(150, 20);
            this.textBox_Ad.TabIndex = 2;
            // 
            // label_UserID
            // 
            this.label_UserID.AutoSize = true;
            this.label_UserID.Location = new System.Drawing.Point(163, 10);
            this.label_UserID.Name = "label_UserID";
            this.label_UserID.Size = new System.Drawing.Size(13, 13);
            this.label_UserID.TabIndex = 7;
            this.label_UserID.Text = "0";
            this.label_UserID.Visible = false;
            // 
            // label_Durum
            // 
            this.label_Durum.AutoSize = true;
            this.label_Durum.Location = new System.Drawing.Point(7, 15);
            this.label_Durum.Name = "label_Durum";
            this.label_Durum.Size = new System.Drawing.Size(38, 13);
            this.label_Durum.TabIndex = 5;
            this.label_Durum.Text = "Durum";
            this.label_Durum.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Adı";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(225, 18);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(675, 528);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(502, 502);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Öğrenci Bilgileri";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(667, 502);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "İzin Bilgileri";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label_İzinID);
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Controls.Add(this.dataGridViewIzinbilgileri);
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(677, 496);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Öğrenci İzin Bilgileri";
            // 
            // label_İzinID
            // 
            this.label_İzinID.AutoSize = true;
            this.label_İzinID.Location = new System.Drawing.Point(366, 26);
            this.label_İzinID.Name = "label_İzinID";
            this.label_İzinID.Size = new System.Drawing.Size(0, 13);
            this.label_İzinID.TabIndex = 15;
            this.label_İzinID.Visible = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.button_güncelle);
            this.groupBox7.Controls.Add(this.button_sil);
            this.groupBox7.Controls.Add(this.buttonYeniizinEkle);
            this.groupBox7.Controls.Add(this.dateTimePickerStop);
            this.groupBox7.Controls.Add(this.dateTimePickerStart);
            this.groupBox7.Location = new System.Drawing.Point(6, 19);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(345, 143);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "İzin Tarihleri";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "İzin Bitiş Tarihi";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "İzin Başlama Tarihi";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(130, 133);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 13);
            this.label13.TabIndex = 5;
            // 
            // button_güncelle
            // 
            this.button_güncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_güncelle.ForeColor = System.Drawing.Color.DarkGreen;
            this.button_güncelle.Location = new System.Drawing.Point(228, 80);
            this.button_güncelle.Name = "button_güncelle";
            this.button_güncelle.Size = new System.Drawing.Size(89, 44);
            this.button_güncelle.TabIndex = 4;
            this.button_güncelle.Text = "Güncelle";
            this.button_güncelle.UseVisualStyleBackColor = true;
            this.button_güncelle.Visible = false;
            this.button_güncelle.Click += new System.EventHandler(this.izinbutton_güncelle_Click);
            // 
            // button_sil
            // 
            this.button_sil.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_sil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_sil.ForeColor = System.Drawing.Color.Red;
            this.button_sil.Location = new System.Drawing.Point(136, 80);
            this.button_sil.Name = "button_sil";
            this.button_sil.Size = new System.Drawing.Size(86, 44);
            this.button_sil.TabIndex = 3;
            this.button_sil.Text = "Sil";
            this.button_sil.UseVisualStyleBackColor = false;
            this.button_sil.Visible = false;
            this.button_sil.Click += new System.EventHandler(this.izinbutton_sil_Click);
            // 
            // buttonYeniizinEkle
            // 
            this.buttonYeniizinEkle.Location = new System.Drawing.Point(136, 80);
            this.buttonYeniizinEkle.Name = "buttonYeniizinEkle";
            this.buttonYeniizinEkle.Size = new System.Drawing.Size(181, 44);
            this.buttonYeniizinEkle.TabIndex = 2;
            this.buttonYeniizinEkle.Text = "Yeni İzin Ekle";
            this.buttonYeniizinEkle.UseVisualStyleBackColor = true;
            this.buttonYeniizinEkle.Click += new System.EventHandler(this.izinbuttonYeniizinEkle_Click);
            // 
            // dateTimePickerStop
            // 
            this.dateTimePickerStop.Location = new System.Drawing.Point(136, 54);
            this.dateTimePickerStop.Name = "dateTimePickerStop";
            this.dateTimePickerStop.Size = new System.Drawing.Size(181, 20);
            this.dateTimePickerStop.TabIndex = 1;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(136, 19);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(181, 20);
            this.dateTimePickerStart.TabIndex = 0;
            // 
            // dataGridViewIzinbilgileri
            // 
            this.dataGridViewIzinbilgileri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIzinbilgileri.Location = new System.Drawing.Point(6, 201);
            this.dataGridViewIzinbilgileri.Name = "dataGridViewIzinbilgileri";
            this.dataGridViewIzinbilgileri.Size = new System.Drawing.Size(655, 289);
            this.dataGridViewIzinbilgileri.TabIndex = 0;
            this.dataGridViewIzinbilgileri.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.izindataGridView1_RowHeaderMouseDoubleClick);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox6);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(502, 502);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Cihaz Okuma Bilgileri";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button_yenihareketekle);
            this.groupBox6.Controls.Add(this.dateTimePicker_stop_tum);
            this.groupBox6.Controls.Add(this.button_CihazOkuma);
            this.groupBox6.Controls.Add(this.dateTimePicker_start_tum);
            this.groupBox6.Controls.Add(this.dataGridView_tum_veriler);
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(496, 496);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Öğrenci Cihaz Parmak Okuyucu Bilgileri";
            // 
            // button_yenihareketekle
            // 
            this.button_yenihareketekle.Location = new System.Drawing.Point(6, 37);
            this.button_yenihareketekle.Name = "button_yenihareketekle";
            this.button_yenihareketekle.Size = new System.Drawing.Size(87, 58);
            this.button_yenihareketekle.TabIndex = 4;
            this.button_yenihareketekle.Text = "Yeni Hareket Ekle";
            this.button_yenihareketekle.UseVisualStyleBackColor = true;
            this.button_yenihareketekle.Click += new System.EventHandler(this.button_yenihareketekle_Click);
            // 
            // dateTimePicker_stop_tum
            // 
            this.dateTimePicker_stop_tum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker_stop_tum.Location = new System.Drawing.Point(99, 69);
            this.dateTimePicker_stop_tum.Name = "dateTimePicker_stop_tum";
            this.dateTimePicker_stop_tum.Size = new System.Drawing.Size(201, 26);
            this.dateTimePicker_stop_tum.TabIndex = 3;
            // 
            // button_CihazOkuma
            // 
            this.button_CihazOkuma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_CihazOkuma.Location = new System.Drawing.Point(320, 37);
            this.button_CihazOkuma.Name = "button_CihazOkuma";
            this.button_CihazOkuma.Size = new System.Drawing.Size(170, 58);
            this.button_CihazOkuma.TabIndex = 2;
            this.button_CihazOkuma.Text = "Okuma Bilgilerini Göster";
            this.button_CihazOkuma.UseVisualStyleBackColor = true;
            this.button_CihazOkuma.Click += new System.EventHandler(this.button_CihazOkuma_Click);
            // 
            // dateTimePicker_start_tum
            // 
            this.dateTimePicker_start_tum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker_start_tum.Location = new System.Drawing.Point(99, 37);
            this.dateTimePicker_start_tum.Name = "dateTimePicker_start_tum";
            this.dateTimePicker_start_tum.Size = new System.Drawing.Size(201, 26);
            this.dateTimePicker_start_tum.TabIndex = 1;
            // 
            // dataGridView_tum_veriler
            // 
            this.dataGridView_tum_veriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_tum_veriler.Location = new System.Drawing.Point(6, 111);
            this.dataGridView_tum_veriler.Name = "dataGridView_tum_veriler";
            this.dataGridView_tum_veriler.Size = new System.Drawing.Size(484, 379);
            this.dataGridView_tum_veriler.TabIndex = 0;
            this.dataGridView_tum_veriler.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_tum_veriler_RowHeaderMouseDoubleClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(502, 502);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Toplu İşlem";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.Color.DarkRed;
            this.button3.Location = new System.Drawing.Point(87, 40);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(315, 66);
            this.button3.TabIndex = 0;
            this.button3.Text = "Veri Tabanındaki Tüm Kayıtları Sil";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormOgrenciler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(921, 558);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "FormOgrenciler";
            this.Text = "Öğrenciler";
            this.Load += new System.EventHandler(this.FormOgrenciler_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ogrliste)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_islem.ResumeLayout(false);
            this.groupBox_islem.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIzinbilgileri)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tum_veriler)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

       

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_ogrliste;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOgrGuncelle;
        private System.Windows.Forms.Label label_UserID;
        private System.Windows.Forms.Label label_Durum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Ad;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBox_Durum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox_islem;
        private System.Windows.Forms.TextBox textBox_AileTel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_CepTel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonOgrSil;
        private System.Windows.Forms.Button buttonOgrYeniEkle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_CihazGuncelle;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBoxCihazID;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_resim_cek;
        private System.Windows.Forms.TextBox textBox_Adres;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_Tc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_OdaNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataGridViewIzinbilgileri;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dataGridView_tum_veriler;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.TextBox textBoxnotlar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button_güncelle;
        private System.Windows.Forms.Button button_sil;
        private System.Windows.Forms.Button buttonYeniizinEkle;
        private System.Windows.Forms.DateTimePicker dateTimePickerStop;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label label_İzinID;
        private System.Windows.Forms.Label label_KayitDurum;
        private System.Windows.Forms.DateTimePicker dateTimePicker_stop_tum;
        private System.Windows.Forms.Button button_CihazOkuma;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start_tum;
        private System.Windows.Forms.Button button_yenihareketekle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_OgrGüncelle;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}