using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDUI.sharedForms
{
    public partial class SaveButton : UserControl
    {
        public SaveButton()
        {
            InitializeComponent();
            this.Click += SaveButton_Click;
            this.pictureBox1.Click += SaveButton_Click;
            this.label1.Click += SaveButton_Click;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SaveButton_Load(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }
    }
}
