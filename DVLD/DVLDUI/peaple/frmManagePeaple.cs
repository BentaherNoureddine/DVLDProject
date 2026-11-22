using DVLDBuisnessLayer.Peaple;
using System;
using System.Windows.Forms;



namespace DVLDUI
{
    public partial class frmManagePeaple : Form
    {
        public frmManagePeaple()
        {
            InitializeComponent();
            addPersonButton1.OnPersonCreated += (person) => _refreshGird()  ;


        }


        private void _refreshGird()
        {
            getAllPeapleGrid1.refereshGrid();
            numberOfPeaple.Text = getAllPeapleGrid1.NumberOfPeople.ToString();
        }

        private void getAllPeapleGrid1_Load(object sender, EventArgs e)
        {
           // numberOfPeaple.Text = getAllPeapleGrid1.NumberOfPeople.ToString();
        }

        private void recorsLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void numberOfPeaple_Click(object sender, EventArgs e)
        {

        }

        private void frmManagePeaple_Load(object sender, EventArgs e)
        {

        }

        private void addPersonButton1_Load(object sender, EventArgs e)
        {

        }

        private void getAllPeapleGrid1_Load_1(object sender, EventArgs e)
        {

        }

        private void addPersonButton1_Click(object sender, EventArgs e)
        {

        }


 
 


    }
}
