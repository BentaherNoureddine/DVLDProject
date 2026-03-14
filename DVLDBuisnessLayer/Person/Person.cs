using DVLDBuisnessLayer.NationalityCountry;
using DVLDDataAccessLayer;
using System;
using System.Data;



namespace DVLDBuisnessLayer.Peaple
{
    public class Person
    {
        private enum Mode
        {
            Add,
            Edit
        }


        public int PersonID{  get; set; }

        public string NationalNO { get; set; }

        public string Firstname { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }   

        public string LastName { get; set; }    

        public DateTime DateOfBirth { get; set; }

        public char Gender { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public Country NationalityCountry {  get; set; }

        public string ImagePath { get; set; }


        private Mode _Mode;






        private Person(int personID, string nationalNO, string firstname, string secondName, string thirdName, string lastName, DateTime dateOfBirth, char gender, string address, string phone, string email, Country nationalityCountry, string imagePath)
        {
            PersonID = personID;
            NationalNO = nationalNO;
            Firstname = firstname;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountry = nationalityCountry;
            this.ImagePath = imagePath;
            this._Mode = Mode.Edit;
        }


        public Person( string nationalNO, string firstname, string secondName, string thirdName, string lastName, DateTime dateOfBirth, char gender, string address, string phone, string email, Country nationalityCountry, string imagePath)
        {

            NationalNO = nationalNO;
            Firstname = firstname;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountry = nationalityCountry;
            this.ImagePath = imagePath;
            this._Mode = Mode.Add;

        }








        private bool _createPerson()
        {
          this.PersonID = PersonAccessLayer.createPerson(NationalNO, Firstname, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, this.NationalityCountry.CountryID, ImagePath);
            if (this.PersonID >= 0)
            {
                return true;
            }
            return false;
        }


        private bool _updatePerson()
        {
            return PersonAccessLayer.updatePerson(PersonID, NationalNO, Firstname, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, this.NationalityCountry.CountryID, ImagePath);
        }


        public static bool isPersonExistsById(int PersonID)
        {
            return PersonAccessLayer.isPersonExistsById(PersonID);
        }



        public static bool FindPersonByID(int PersonID, ref string NationalNO,ref string Firstname, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref char Gender, ref string Address, ref string Phone, ref string Email, ref Country NationalityCountry, ref string ImagePath)
        {



            int countryID = 0;
            bool isFound=  PersonAccessLayer.FindPersonByID(PersonID,ref NationalNO, ref Firstname, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref countryID , ref ImagePath);

            if (isFound)
            {
                NationalityCountry = Country.tryToGetCountryByID(countryID);

            }
            return isFound;
        }


       

        public static bool FindPersonByName(ref int PersonID, ref string NationalNO,string Firstname, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref char Gender, ref string Address, ref string Phone, ref string Email, ref Country NationalityCountry, ref string ImagePath)
        {

            int countryID=0;
            bool isFound= PersonAccessLayer.FindPersonByName(ref PersonID,ref NationalNO, Firstname, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email,ref countryID, ref ImagePath);
            if (isFound)
            {
                NationalityCountry = Country.tryToGetCountryByID(countryID);

            }
            return isFound;

        }


        public static bool FindPersonByNationalNumber(ref int PersonID, ref string NationalNO,ref string Firstname, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref char Gender, ref string Address, ref string Phone, ref string Email, ref Country NationalityCountry, ref string ImagePath)
        {

            int countryID = 0;
            bool isFound=PersonAccessLayer.FindPersonByName(ref PersonID, ref NationalNO,Firstname, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email,ref countryID, ref ImagePath);
            if (isFound)
            {
                NationalityCountry = Country.tryToGetCountryByID(countryID);

            }
            return isFound;
        }


        public static DataTable getAllPersons()
        {
            return PersonAccessLayer.GetAllPeople();
        }



        public bool save()
        {
            switch(_Mode)
            {
                case Mode.Add:
                    if (_createPerson())
                    {
                        _Mode = Mode.Edit;
                        return true;
                    }
                    return false;
                case Mode.Edit:
                    if (_updatePerson())
                    {
                        _Mode = Mode.Edit;
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }




        








    }
}
