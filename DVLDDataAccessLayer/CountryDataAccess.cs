

using System;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public class CountryDataAccess
    {

  
        public static bool findCountryByID(int CountryID, ref string countryName)
        {



            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessLayerSettings.ConnectionString);

            string query = @"SELECT * FROM Countries WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    countryName = (string)reader["countryName"];

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Error finding country", ex);
            }
            finally
            {
                connection.Close();
                command.Dispose();
            }

            return isFound;

        }
    }
}
