using DVLDBuisnessLayer.NationalityCountry;
using DVLDBuisnessLayer.Peaple;
using Shared.sharedUIConfig;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;



namespace DVLDUI.peaple
{
    public partial class addNewUpdateUserContainer : Form
    {


        private Person person;

        

        private addNewUpdateUserContainer()
        {

        }
        public addNewUpdateUserContainer(UIMode mode,Person person = null)
        {
            this.person = person;
            InitializeComponent();
            this.dateTimePicker1.MaxDate = _getMiDateOfBirth();
            _loadCountriesComboBox();
        }


        private void initComponents(UIMode mode)
        {
            switch(mode)
            {
                case UIMode.CreateMode:
                    _initComponentsForAdd();
                    break;
                case UIMode.EditMode:
                    _initComponentsForUpdate();
                    break;
                case UIMode.ViewMode:
                    _initComponentsForView();
                    break;

            }
        }


  



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.user_image_control.Image = Image.FromFile("G:\\projects\\DVLD\\DVLDProject\\images\\default_user_image.jpg") ;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _selectAndSaveUserImage();
        }

    


        private  DateTime _getMiDateOfBirth()
        {
            return DateTime.Now.AddYears(-18);
        }


        private void nationalNumberTextBox_Leave(object sender, EventArgs e)
        {
            _validateNationalNumber();
        }

        private void _validateNationalNumber()
        {

           string nationalNumber = this.nationalNumberTextBox.Text.Trim();

            if (this.nationalNumberTextBox.Text.Length>0 && Person.isPersonExistsByNationalNumber(ref nationalNumber))
            {
                this.nationalNumberTextBox.Text = "";
                MessageBox.Show("Person with this national number already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void _loadCountriesComboBox()
        {
            Dictionary<string, int> countries = Country.getAllcountryNamesAndIds();

            this.countriesComboBox.DataSource = new BindingSource(countries,null);
            this.countriesComboBox.DisplayMember = "Key";
            this.countriesComboBox.ValueMember = "Value";
            this.countriesComboBox.SelectedItem = countries.FirstOrDefault(
                (item) => item.Key == "Tunisia" 
                
                );
        }

        private void _selectAndSaveUserImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Select an Image";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK) { 
                string selectedFilePath = openFileDialog.FileName;
                user_image_control.Image = Image.FromFile(selectedFilePath); 
            }
        }


        private void user_image_control_Click(object sender, EventArgs e)
        {
            _selectAndSaveUserImage();
        }

        private void femaleRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            this.user_image_control.Image = Image.FromFile("G:\\projects\\DVLD\\DVLDProject\\images\\default_female_image.png");
        }

        private void _validatePhoneNumber()
        {
            if(this.phonenumberTextField.Text.Trim().Length == 0)
            {
                _DisplayFieldRequiredMessage("PhoneNumber");

            }
           if(Person.isPersonExistsByPhonenumber(this.phonenumberTextField.Text))
            {
                MessageBox.Show("Phone Number already exists", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.phonenumberTextField.Text = "";
            }
        }

        private void phonenumberTextField_Leave(object sender, EventArgs e)
        {
            _validatePhoneNumber();
        }

        private void _validateEmail()
        {

            if (string.IsNullOrWhiteSpace(this.emailTextBox.Text))
            {
                _DisplayFieldRequiredMessage("Email");
                return;
            }

            try { 
                 MailAddress email = new MailAddress(this.emailTextBox.Text);

                if (!(email.Address == this.emailTextBox.Text))
                {
                    MessageBox.Show("Email Format Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            } catch (Exception e){
                MessageBox.Show("Email Format Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
       



            if (Person.isPersonExistsByEmail(this.emailTextBox.Text))
            {
                MessageBox.Show("Email Already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            


        }

        private void adressTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailTextBox_Leave(object sender, EventArgs e)
        {
            _validateEmail();
        }

        private void _createAndSavePerson()
        {

            Char gender;
            if (this.maleRadioButton.Checked) {
                gender = 'M';
            }
            else
            {
                gender = 'F';
            }

            var selected = (KeyValuePair<string, int>)countriesComboBox.SelectedItem;

            string countryName = selected.Key;
            int countryId = selected.Value;

            Country country = new Country(selected.Value, selected.Key);

            Person newPerson = new Person(
                this.nationalNumberTextBox.Text,
                this.firstNameTextBox.Text,
                this.secondNameTextBox.Text,
                this.thirdNameTextBox.Text,
                this.lastNameTextBox.Text,
                this.dateTimePicker1.Value,
                gender,
                this.adressTextBox.Text,
                this.phonenumberTextField.Text,
                this.emailTextBox.Text,
                country,
                this.user_image_control.ImageLocation
               
                );
            if (newPerson.save())
            {
                MessageBox.Show("person created successfully","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                RaiseOnPersonCreated(newPerson);
            }
            else
            {
                MessageBox.Show("There was a problem creating new person", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addNewUpdateUserContainer_Load(object sender, EventArgs e)
        {

        }



      

        private void saveButton1_Click_1(object sender, EventArgs e)
        {
            if (_ValidateRequiredInputs())
            {
                _createAndSavePerson();
                this.Close();
            }
          

        }




        private bool _ValidateRequiredInputs()
        {
            if (!_ValidateTextBox(nationalNumberTextBox, "National Number"))
                return false;

            if (!_ValidateTextBox(firstNameTextBox, "First Name"))
                return false;

            if (!_ValidateTextBox(secondNameTextBox, "Second Name"))
                return false;

            if (!_ValidateTextBox(lastNameTextBox, "Last Name"))
                return false;

            if (!_ValidateTextBox(phonenumberTextField, "Phone Number"))
                return false;

            if (!_ValidateTextBox(emailTextBox, "Email"))
                return false;

        

            return true;
        }


      


       
        private bool _ValidateTextBox(TextBox textBox, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                _DisplayFieldRequiredMessage(fieldName);
                textBox.Focus();
                return false;
            }

            return true;
        }

        private void _DisplayFieldRequiredMessage(string message)
        {
            MessageBox.Show(
                $"{message} is Required",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

     

        // Event to notify when a new person is created
        public event Action<Person> OnPersonCreated;


        protected virtual void RaiseOnPersonCreated(Person newPerson)
        {
            OnPersonCreated?.Invoke(newPerson);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
