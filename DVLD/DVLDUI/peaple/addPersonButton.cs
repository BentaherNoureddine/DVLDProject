using DVLDBuisnessLayer.Peaple;
using Shared.sharedUIConfig;
using System;
using System.Windows.Forms;


namespace DVLDUI.peaple
{
    public partial class addPersonButton : UserControl
    {
        public addPersonButton()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            addNewUpdateUserContainer addNewUpdateUserContainer = new addNewUpdateUserContainer(UIMode.CreateMode);

            addNewUpdateUserContainer.OnPersonCreated += AddNewUpdateUserContainer_OnPersonCreated;
            addNewUpdateUserContainer.ShowDialog();

        }


        public event Action<Person> OnPersonCreated;

        private void AddNewUpdateUserContainer_OnPersonCreated(Person newPerson)
        {
            OnPersonCreated?.Invoke(newPerson);
        }


    }
}
