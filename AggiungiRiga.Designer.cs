namespace OrarioVideolezioni
{
    partial class AggiungiRiga
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AggiungiRiga));
            this.giornoSettimana_txt = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.link_txt = new System.Windows.Forms.TextBox();
            this.annullaBtn = new System.Windows.Forms.Button();
            this.aggiungiBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.materia_txt = new System.Windows.Forms.ComboBox();
            this.linkPrefix_txt = new System.Windows.Forms.ComboBox();
            this.inizio_dtp = new System.Windows.Forms.DateTimePicker();
            this.fine_dtp = new System.Windows.Forms.DateTimePicker();
            this.closeOnAdd = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // giornoSettimana_txt
            // 
            this.giornoSettimana_txt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.giornoSettimana_txt.FormattingEnabled = true;
            this.giornoSettimana_txt.Items.AddRange(new object[] {
            "Lunedì",
            "Martedì",
            "Mercoledì",
            "Giovedì",
            "Venerdì",
            "Sabato",
            "Domenica"});
            this.giornoSettimana_txt.Location = new System.Drawing.Point(132, 12);
            this.giornoSettimana_txt.Name = "giornoSettimana_txt";
            this.giornoSettimana_txt.Size = new System.Drawing.Size(254, 21);
            this.giornoSettimana_txt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Giorno della settimana:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ora di inizio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ora di fine:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Link:";
            // 
            // link_txt
            // 
            this.link_txt.Location = new System.Drawing.Point(205, 91);
            this.link_txt.Name = "link_txt";
            this.link_txt.Size = new System.Drawing.Size(181, 20);
            this.link_txt.TabIndex = 9;
            // 
            // annullaBtn
            // 
            this.annullaBtn.Location = new System.Drawing.Point(230, 144);
            this.annullaBtn.Name = "annullaBtn";
            this.annullaBtn.Size = new System.Drawing.Size(75, 23);
            this.annullaBtn.TabIndex = 10;
            this.annullaBtn.Text = "Esci";
            this.annullaBtn.UseVisualStyleBackColor = true;
            this.annullaBtn.Click += new System.EventHandler(this.chiudiFinestra);
            // 
            // aggiungiBtn
            // 
            this.aggiungiBtn.Location = new System.Drawing.Point(311, 144);
            this.aggiungiBtn.Name = "aggiungiBtn";
            this.aggiungiBtn.Size = new System.Drawing.Size(75, 23);
            this.aggiungiBtn.TabIndex = 11;
            this.aggiungiBtn.Text = "Aggiungi";
            this.aggiungiBtn.UseVisualStyleBackColor = true;
            this.aggiungiBtn.Click += new System.EventHandler(this.aggiungi);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Materia:";
            // 
            // materia_txt
            // 
            this.materia_txt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materia_txt.FormattingEnabled = true;
            this.materia_txt.Location = new System.Drawing.Point(132, 117);
            this.materia_txt.Name = "materia_txt";
            this.materia_txt.Size = new System.Drawing.Size(254, 21);
            this.materia_txt.TabIndex = 14;
            // 
            // linkPrefix_txt
            // 
            this.linkPrefix_txt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.linkPrefix_txt.FormattingEnabled = true;
            this.linkPrefix_txt.Items.AddRange(new object[] {
            "http://",
            "https://"});
            this.linkPrefix_txt.Location = new System.Drawing.Point(132, 90);
            this.linkPrefix_txt.Name = "linkPrefix_txt";
            this.linkPrefix_txt.Size = new System.Drawing.Size(67, 21);
            this.linkPrefix_txt.TabIndex = 16;
            // 
            // inizio_dtp
            // 
            this.inizio_dtp.Cursor = System.Windows.Forms.Cursors.Default;
            this.inizio_dtp.CustomFormat = "HH:mm";
            this.inizio_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.inizio_dtp.Location = new System.Drawing.Point(132, 39);
            this.inizio_dtp.Name = "inizio_dtp";
            this.inizio_dtp.ShowUpDown = true;
            this.inizio_dtp.Size = new System.Drawing.Size(254, 20);
            this.inizio_dtp.TabIndex = 17;
            this.inizio_dtp.Value = new System.DateTime(2020, 11, 22, 0, 0, 0, 0);
            // 
            // fine_dtp
            // 
            this.fine_dtp.Cursor = System.Windows.Forms.Cursors.Default;
            this.fine_dtp.CustomFormat = "HH:mm";
            this.fine_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.fine_dtp.Location = new System.Drawing.Point(132, 64);
            this.fine_dtp.Name = "fine_dtp";
            this.fine_dtp.ShowUpDown = true;
            this.fine_dtp.Size = new System.Drawing.Size(254, 20);
            this.fine_dtp.TabIndex = 18;
            this.fine_dtp.Value = new System.DateTime(2020, 11, 22, 0, 0, 0, 0);
            // 
            // closeOnAdd
            // 
            this.closeOnAdd.AutoSize = true;
            this.closeOnAdd.Checked = true;
            this.closeOnAdd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.closeOnAdd.Location = new System.Drawing.Point(15, 148);
            this.closeOnAdd.Name = "closeOnAdd";
            this.closeOnAdd.Size = new System.Drawing.Size(126, 17);
            this.closeOnAdd.TabIndex = 19;
            this.closeOnAdd.Text = "Chiudi dopo aggiunta";
            this.closeOnAdd.UseVisualStyleBackColor = true;
            // 
            // AggiungiRiga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 178);
            this.Controls.Add(this.closeOnAdd);
            this.Controls.Add(this.fine_dtp);
            this.Controls.Add(this.inizio_dtp);
            this.Controls.Add(this.linkPrefix_txt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.materia_txt);
            this.Controls.Add(this.aggiungiBtn);
            this.Controls.Add(this.annullaBtn);
            this.Controls.Add(this.link_txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.giornoSettimana_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AggiungiRiga";
            this.Text = "Aggiungi Riga";
            this.Load += new System.EventHandler(this.AggiungiRiga_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox giornoSettimana_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox link_txt;
        private System.Windows.Forms.Button annullaBtn;
        private System.Windows.Forms.Button aggiungiBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox materia_txt;
        private System.Windows.Forms.ComboBox linkPrefix_txt;
        private System.Windows.Forms.DateTimePicker inizio_dtp;
        private System.Windows.Forms.DateTimePicker fine_dtp;
        private System.Windows.Forms.CheckBox closeOnAdd;
    }
}