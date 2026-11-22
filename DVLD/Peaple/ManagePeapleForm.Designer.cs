namespace DVLD.Peaple
{
    partial class ManagePeapleForm
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
            this.peapleDataGridControl1 = new DVLD.Peaple.PeapleDataGridControl();
            this.SuspendLayout();
            // 
            // peapleDataGridControl1
            // 
            this.peapleDataGridControl1.Location = new System.Drawing.Point(24, 138);
            this.peapleDataGridControl1.Name = "peapleDataGridControl1";
            this.peapleDataGridControl1.Size = new System.Drawing.Size(1501, 459);
            this.peapleDataGridControl1.TabIndex = 0;
            // 
            // ManagePeapleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1537, 592);
            this.Controls.Add(this.peapleDataGridControl1);
            this.Name = "ManagePeapleForm";
            this.Text = "ManagePeapleForm";
            this.ResumeLayout(false);

        }

        #endregion

        private DVLD.Peaple.PeapleDataGridControl peapleDataGridControl1;
    }
}