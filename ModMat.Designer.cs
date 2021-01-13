
namespace OrarioVideolezioni
{
    partial class ModMat
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
            this.label1 = new System.Windows.Forms.Label();
            this.nomenuovo = new System.Windows.Forms.TextBox();
            this.apply = new System.Windows.Forms.Button();
            this.esci = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nuovo Prof:";
            // 
            // nomenuovo
            // 
            this.nomenuovo.Location = new System.Drawing.Point(12, 25);
            this.nomenuovo.Name = "nomenuovo";
            this.nomenuovo.Size = new System.Drawing.Size(277, 20);
            this.nomenuovo.TabIndex = 1;
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(295, 23);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(75, 23);
            this.apply.TabIndex = 2;
            this.apply.Text = "Applica";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // esci
            // 
            this.esci.Location = new System.Drawing.Point(376, 23);
            this.esci.Name = "esci";
            this.esci.Size = new System.Drawing.Size(75, 23);
            this.esci.TabIndex = 3;
            this.esci.Text = "Chiudi";
            this.esci.UseVisualStyleBackColor = true;
            this.esci.Click += new System.EventHandler(this.esci_Click);
            // 
            // ModMat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 59);
            this.ControlBox = false;
            this.Controls.Add(this.esci);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.nomenuovo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ModMat";
            this.Text = "Cambia nome professore";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nomenuovo;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Button esci;
    }
}