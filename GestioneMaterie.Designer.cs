namespace OrarioVideolezioni
{
    partial class GestioneMaterie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestioneMaterie));
            this.aggmat_btn = new System.Windows.Forms.Button();
            this.nomeMat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nomeProf = new System.Windows.Forms.TextBox();
            this.remmat_btn = new System.Windows.Forms.Button();
            this.tabellamaterie = new System.Windows.Forms.DataGridView();
            this.escibtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabellamaterie)).BeginInit();
            this.SuspendLayout();
            // 
            // aggmat_btn
            // 
            this.aggmat_btn.Location = new System.Drawing.Point(9, 97);
            this.aggmat_btn.Name = "aggmat_btn";
            this.aggmat_btn.Size = new System.Drawing.Size(147, 23);
            this.aggmat_btn.TabIndex = 1;
            this.aggmat_btn.Text = "Aggiungi";
            this.aggmat_btn.UseVisualStyleBackColor = true;
            this.aggmat_btn.Click += new System.EventHandler(this.aggmat_btn_Click);
            // 
            // nomeMat
            // 
            this.nomeMat.Location = new System.Drawing.Point(9, 32);
            this.nomeMat.Name = "nomeMat";
            this.nomeMat.Size = new System.Drawing.Size(147, 20);
            this.nomeMat.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome Materia";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.aggmat_btn);
            this.groupBox1.Controls.Add(this.nomeProf);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nomeMat);
            this.groupBox1.Location = new System.Drawing.Point(333, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 130);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Aggiungi Materia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nome Professore";
            // 
            // nomeProf
            // 
            this.nomeProf.Location = new System.Drawing.Point(9, 71);
            this.nomeProf.Name = "nomeProf";
            this.nomeProf.Size = new System.Drawing.Size(147, 20);
            this.nomeProf.TabIndex = 5;
            // 
            // remmat_btn
            // 
            this.remmat_btn.Location = new System.Drawing.Point(342, 177);
            this.remmat_btn.Name = "remmat_btn";
            this.remmat_btn.Size = new System.Drawing.Size(147, 23);
            this.remmat_btn.TabIndex = 7;
            this.remmat_btn.Text = "Rimuovi materia selezionata";
            this.remmat_btn.UseVisualStyleBackColor = true;
            this.remmat_btn.Click += new System.EventHandler(this.remmat_btn_Click);
            // 
            // tabellamaterie
            // 
            this.tabellamaterie.AllowUserToAddRows = false;
            this.tabellamaterie.AllowUserToDeleteRows = false;
            this.tabellamaterie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabellamaterie.Location = new System.Drawing.Point(12, 12);
            this.tabellamaterie.Name = "tabellamaterie";
            this.tabellamaterie.ReadOnly = true;
            this.tabellamaterie.Size = new System.Drawing.Size(315, 245);
            this.tabellamaterie.TabIndex = 8;
            // 
            // escibtn
            // 
            this.escibtn.Location = new System.Drawing.Point(432, 234);
            this.escibtn.Name = "escibtn";
            this.escibtn.Size = new System.Drawing.Size(63, 23);
            this.escibtn.TabIndex = 9;
            this.escibtn.Text = "Esci";
            this.escibtn.UseVisualStyleBackColor = true;
            this.escibtn.Click += new System.EventHandler(this.esci);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Modifica materia selez.";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.modmatclick);
            // 
            // GestioneMaterie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 269);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.escibtn);
            this.Controls.Add(this.tabellamaterie);
            this.Controls.Add(this.remmat_btn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GestioneMaterie";
            this.Text = "Gestione Materie";
            this.Load += new System.EventHandler(this.GestioneMaterie_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabellamaterie)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button aggmat_btn;
        private System.Windows.Forms.TextBox nomeMat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nomeProf;
        private System.Windows.Forms.Button remmat_btn;
        private System.Windows.Forms.DataGridView tabellamaterie;
        private System.Windows.Forms.Button escibtn;
        private System.Windows.Forms.Button button1;
    }
}