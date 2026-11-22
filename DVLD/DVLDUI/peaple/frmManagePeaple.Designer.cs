namespace DVLDUI
{
    partial class frmManagePeaple
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
            this.numberOfPeaple = new System.Windows.Forms.Label();
            this.recorsLabel = new System.Windows.Forms.Label();
            this.addPersonButton1 = new DVLDUI.peaple.addPersonButton();
            this.getAllPeapleGrid1 = new DVLDUI.peaple.getAllPeapleGrid();
            this.SuspendLayout();
            // 
            // numberOfPeaple
            // 
            this.numberOfPeaple.AutoSize = true;
            this.numberOfPeaple.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfPeaple.Location = new System.Drawing.Point(156, 511);
            this.numberOfPeaple.Name = "numberOfPeaple";
            this.numberOfPeaple.Size = new System.Drawing.Size(24, 25);
            this.numberOfPeaple.TabIndex = 10;
            this.numberOfPeaple.Text = "?";
            this.numberOfPeaple.Click += new System.EventHandler(this.numberOfPeaple_Click);
            // 
            // recorsLabel
            // 
            this.recorsLabel.AutoSize = true;
            this.recorsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recorsLabel.Location = new System.Drawing.Point(28, 511);
            this.recorsLabel.Name = "recorsLabel";
            this.recorsLabel.Size = new System.Drawing.Size(122, 25);
            this.recorsLabel.TabIndex = 9;
            this.recorsLabel.Text = "# Records :";
            this.recorsLabel.Click += new System.EventHandler(this.recorsLabel_Click);
            // 
            // addPersonButton1
            // 
            this.addPersonButton1.Location = new System.Drawing.Point(1809, 79);
            this.addPersonButton1.Name = "addPersonButton1";
            this.addPersonButton1.Size = new System.Drawing.Size(87, 79);
            this.addPersonButton1.TabIndex = 12;
            this.addPersonButton1.Load += new System.EventHandler(this.addPersonButton1_Load);
            this.addPersonButton1.Click += new System.EventHandler(this.addPersonButton1_Click);
            // 
            // getAllPeapleGrid1
            // 
            this.getAllPeapleGrid1.Location = new System.Drawing.Point(33, 245);
            this.getAllPeapleGrid1.Name = "getAllPeapleGrid1";
            this.getAllPeapleGrid1.Size = new System.Drawing.Size(2053, 263);
            this.getAllPeapleGrid1.TabIndex = 11;
            this.getAllPeapleGrid1.Load += new System.EventHandler(this.getAllPeapleGrid1_Load_1);
            // 
            // frmManagePeaple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 613);
            this.Controls.Add(this.addPersonButton1);
            this.Controls.Add(this.getAllPeapleGrid1);
            this.Controls.Add(this.numberOfPeaple);
            this.Controls.Add(this.recorsLabel);
            this.Name = "frmManagePeaple";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmManagePeaple_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numberOfPeaple;
        private System.Windows.Forms.Label recorsLabel;
        private peaple.getAllPeapleGrid getAllPeapleGrid1;
        private peaple.addPersonButton addPersonButton1;
    }
}

