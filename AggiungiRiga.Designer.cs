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
            this.inizioOra_nm = new System.Windows.Forms.NumericUpDown();
            this.inizioMinuti_nm = new System.Windows.Forms.NumericUpDown();
            this.fineMinuti_nm = new System.Windows.Forms.NumericUpDown();
            this.fineOra_nm = new System.Windows.Forms.NumericUpDown();
            this.link_txt = new System.Windows.Forms.TextBox();
            this.annullaBtn = new System.Windows.Forms.Button();
            this.aggiungiBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inizioOra_nm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inizioMinuti_nm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fineMinuti_nm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fineOra_nm)).BeginInit();
            this.SuspendLayout();
            // 
            // giornoSettimana_txt
            // 
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
            // inizioOra_nm
            // 
            this.inizioOra_nm.Location = new System.Drawing.Point(132, 39);
            this.inizioOra_nm.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.inizioOra_nm.Name = "inizioOra_nm";
            this.inizioOra_nm.Size = new System.Drawing.Size(51, 20);
            this.inizioOra_nm.TabIndex = 5;
            // 
            // inizioMinuti_nm
            // 
            this.inizioMinuti_nm.Location = new System.Drawing.Point(202, 39);
            this.inizioMinuti_nm.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.inizioMinuti_nm.Name = "inizioMinuti_nm";
            this.inizioMinuti_nm.Size = new System.Drawing.Size(51, 20);
            this.inizioMinuti_nm.TabIndex = 6;
            // 
            // fineMinuti_nm
            // 
            this.fineMinuti_nm.Location = new System.Drawing.Point(202, 65);
            this.fineMinuti_nm.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.fineMinuti_nm.Name = "fineMinuti_nm";
            this.fineMinuti_nm.Size = new System.Drawing.Size(51, 20);
            this.fineMinuti_nm.TabIndex = 8;
            // 
            // fineOra_nm
            // 
            this.fineOra_nm.Location = new System.Drawing.Point(132, 65);
            this.fineOra_nm.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.fineOra_nm.Name = "fineOra_nm";
            this.fineOra_nm.Size = new System.Drawing.Size(51, 20);
            this.fineOra_nm.TabIndex = 7;
            // 
            // link_txt
            // 
            this.link_txt.Location = new System.Drawing.Point(132, 91);
            this.link_txt.Name = "link_txt";
            this.link_txt.Size = new System.Drawing.Size(254, 20);
            this.link_txt.TabIndex = 9;
            // 
            // annullaBtn
            // 
            this.annullaBtn.Location = new System.Drawing.Point(230, 117);
            this.annullaBtn.Name = "annullaBtn";
            this.annullaBtn.Size = new System.Drawing.Size(75, 23);
            this.annullaBtn.TabIndex = 10;
            this.annullaBtn.Text = "Annulla";
            this.annullaBtn.UseVisualStyleBackColor = true;
            this.annullaBtn.Click += new System.EventHandler(this.chiudiFinestra);
            // 
            // aggiungiBtn
            // 
            this.aggiungiBtn.Location = new System.Drawing.Point(311, 117);
            this.aggiungiBtn.Name = "aggiungiBtn";
            this.aggiungiBtn.Size = new System.Drawing.Size(75, 23);
            this.aggiungiBtn.TabIndex = 11;
            this.aggiungiBtn.Text = "Aggiungi";
            this.aggiungiBtn.UseVisualStyleBackColor = true;
            this.aggiungiBtn.Click += new System.EventHandler(this.aggiungi);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(185, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(185, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = ":";
            // 
            // AggiungiRiga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 150);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.aggiungiBtn);
            this.Controls.Add(this.annullaBtn);
            this.Controls.Add(this.link_txt);
            this.Controls.Add(this.fineMinuti_nm);
            this.Controls.Add(this.fineOra_nm);
            this.Controls.Add(this.inizioMinuti_nm);
            this.Controls.Add(this.inizioOra_nm);
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
            ((System.ComponentModel.ISupportInitialize)(this.inizioOra_nm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inizioMinuti_nm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fineMinuti_nm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fineOra_nm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox giornoSettimana_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown inizioOra_nm;
        private System.Windows.Forms.NumericUpDown inizioMinuti_nm;
        private System.Windows.Forms.NumericUpDown fineMinuti_nm;
        private System.Windows.Forms.NumericUpDown fineOra_nm;
        private System.Windows.Forms.TextBox link_txt;
        private System.Windows.Forms.Button annullaBtn;
        private System.Windows.Forms.Button aggiungiBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
    }
}