using DTO.Response;
using DVLDBuisnessLayer.Peaple ;
using Shared.sharedUIConfig;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLDUI.peaple
{
    public partial class getAllPeapleGrid : UserControl
    {

        public int NumberOfPeople { get; private set; }
        private DataTable PeapleDataTable;

        public getAllPeapleGrid()
        {
            InitializeComponent();

        }


        private void _loadAllPeaple()
        {
          
             this.PeapleDataTable = Person.GetAllPeopleWithCountyName();
           
        }

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void getAllPeapleGrid_Load(object sender, EventArgs e)
        {
            _loadAllPeaple();

            this.dataGridView1.DataSource = GetAllPeapleResponseDTO.GetAllPeapleResponseDTOFromPeapleDataTable(PeapleDataTable);
            NumberOfPeople = this.dataGridView1.RowCount;

        }


        public void refereshGrid()
        {
            _loadAllPeaple();
            this.dataGridView1.DataSource = GetAllPeapleResponseDTO.GetAllPeapleResponseDTOFromPeapleDataTable(PeapleDataTable);
            NumberOfPeople = this.dataGridView1.RowCount;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void numberOfPeapleCountLabel_Click(object sender, EventArgs e)
        {

        }

        private void recorsLabel_Click(object sender, EventArgs e)
        {

        }

        private void numberOfPeaple_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {

        }

        private void showDetails_Click(object sender, EventArgs e)
        {

            addNewUpdateUserContainer addNewUpdateUserContainer = new addNewUpdateUserContainer(UIMode.ViewMode,Int32 personID);
            addNewUpdateUserContainer.ShowDialog();

        }
    }
}
