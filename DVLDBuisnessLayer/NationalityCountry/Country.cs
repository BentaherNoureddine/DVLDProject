



using DVLDDataAccessLayer;

namespace DVLDBuisnessLayer.NationalityCountry
{
    public class Country
    {

        public int CountryID { get; set; }
        public string CountryName { get; set; }




        public Country(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }



        public static bool findCountryByIDAndGetCountryName(int countryID, ref string countryName)
        {
            return CountryDataAccess.findCountryByID(countryID, ref countryName);

        }

        public static Country tryToGetCountryByID(int countryID)
        {
            string countryName = "";
            if (CountryDataAccess.findCountryByID(countryID, ref countryName))
            {
                return new Country(countryID, countryName);
            }
            else
            {
                return new Country(countryID, "Unknown");
            }

        }









    }
}
