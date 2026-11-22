using DVLDBuisnessLayer.Peaple;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Peaple
{
    public partial class PeapleDataGridControl : UserControl
    {
        public PeapleDataGridControl()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PeapleDataGridControl_Load(object sender, EventArgs e)
        {
           dataGridView1.DataSource = Person.getAllPersons();
        }
    }
}
