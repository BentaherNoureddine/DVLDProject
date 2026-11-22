using System;
using System.Windows.Forms;







namespace DVLDUI.sharedForms
{
    public partial class CloseButton : UserControl
    {
        public CloseButton()
        {
            InitializeComponent();
            pictureBox1.Click += CloseButton_Click;
            this.label1.Click += CloseButton_Click;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
        }

        private void CloseButton_Load(object sender, EventArgs e)
        {

        }
    }
}
