namespace OrarioVideolezioni
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabella = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.aggiungiRigaBtn = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.refresher = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabella)).BeginInit();
            this.SuspendLayout();
            // 
            // tabella
            // 
            this.tabella.AllowUserToAddRows = false;
            this.tabella.AllowUserToDeleteRows = false;
            this.tabella.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabella.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabella.Location = new System.Drawing.Point(12, 12);
            this.tabella.Name = "tabella";
            this.tabella.ReadOnly = true;
            this.tabella.Size = new System.Drawing.Size(615, 537);
            this.tabella.TabIndex = 0;
            this.tabella.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabella_CellContentClick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(13, 556);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "APRI LINK ATTIVO";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // aggiungiRigaBtn
            // 
            this.aggiungiRigaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.aggiungiRigaBtn.Location = new System.Drawing.Point(149, 556);
            this.aggiungiRigaBtn.Name = "aggiungiRigaBtn";
            this.aggiungiRigaBtn.Size = new System.Drawing.Size(108, 23);
            this.aggiungiRigaBtn.TabIndex = 2;
            this.aggiungiRigaBtn.Text = "AGGIUNGI RIGA";
            this.aggiungiRigaBtn.UseVisualStyleBackColor = true;
            this.aggiungiRigaBtn.Click += new System.EventHandler(this.apriFinestraAggRiga);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(440, 560);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(139, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "APRI IN AUTOMATICO";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // refresher
            // 
            this.refresher.Interval = 10000;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(263, 556);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "RIMUOVI RIGA SELEZIONATA";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 589);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.aggiungiRigaBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabella);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Orario Videolezioni";
            this.Load += new System.EventHandler(this.finestraCaricata);
            ((System.ComponentModel.ISupportInitialize)(this.tabella)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tabella;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button aggiungiRigaBtn;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer refresher;
        private System.Windows.Forms.Button button2;
    }
}

