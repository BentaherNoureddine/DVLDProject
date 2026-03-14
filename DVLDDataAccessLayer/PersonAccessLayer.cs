using System;
using System.Data;
using System.Data.SqlClient;


namespace DVLDDataAccessLayer
{
    public class PersonAccessLayer
    {




        public static int createPerson(string nationalNO, string firstname, string secondName, string thirdName, string lastName, DateTime dateOfBirth, char gender, string address, string phone, string email, int CountryID, string imagePath)
        {

            int PersonID = -1;

            SqlConnection connection = new SqlConnection(DataAccessLayerSettings.ConnectionString);

            string query = @"
            INSERT INTO People
            (
                NationalNo,
                FirstName,
                SecondName,
                ThirdName,
                LastName,
                DateOfBirth,
                Gender,
                Address,
                Phone,
                Email,
                CountryID,
                ImagePath
            )
            VALUES
            (
                @NationalNo,
                @FirstName,
                @SecondName,
                @ThirdName,
                @LastName,
                @DateOfBirth,
                @Gender,
                @Address,
                @Phone,
                @Email,
                @CountryID,
                @ImagePath
            );

            SELECT SCOPE_IDENTITY();
            ";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@NationalNo", nationalNO);
            command.Parameters.AddWithValue("@FirstName", firstname);
            command.Parameters.AddWithValue("@SecondName", secondName);
            command.Parameters.AddWithValue("@ThirdName", thirdName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@Gender", gender);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            if (imagePath != null)
            {
                command.Parameters.AddWithValue("@ImagePath", imagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }




            try
            {
                connection.Open();

                PersonID = Convert.ToInt32(command.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw new Exception("Error ", ex);
            }
            finally
            {
                connection.Close();
                command.Dispose();
            }



            return PersonID;


        }






        public static bool updatePerson(int PersonID, string nationalNO, string firstname, string secondName, string thirdName, string lastName, DateTime dateOfBirth, char gender, string address, string phone, string email, int CountryID, string imagePath)
        {
            bool isUpdated = false;

            SqlConnection connection = new SqlConnection(DataAccessLayerSettings.ConnectionString);

            string query = @"
          UPDATE People
            SET
                NationalNo = @NationalNo,
                FirstName = @FirstName,
                SecondName = @SecondName,
                ThirdName = @ThirdName,
                LastName = @LastName,
                DateOfBirth = @DateOfBirth,
                Gender = @Gender,
                Address = @Address,
                Phone = @Phone,
                Email = @Email,
                CountryID = @CountryID,
                ImagePath = @ImagePath
            WHERE PersonID = @PersonID

            ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", nationalNO);
            command.Parameters.AddWithValue("@FirstName", firstname);
            command.Parameters.AddWithValue("@SecondName", secondName);
            command.Parameters.AddWithValue("@ThirdName", thirdName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@Gender", gender);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            if (imagePath != null)
            {
                command.Parameters.AddWithValue("@ImagePath", imagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }




            try
            {
                connection.Open();

                isUpdated = command.ExecuteNonQuery() > 0;

            }
            catch (Exception ex)
            {
                throw new Exception("Error ", ex);
            }
            finally
            {
                connection.Close();
                command.Dispose();
            }



            return isUpdated;


        }





        public static bool DeletePerson(int PersonID)
        {
            bool isDeleted = false;

            SqlConnection connection = new SqlConnection(DataAccessLayerSettings.ConnectionString);

            string query = @"  DELETE FROM People  WHERE PersonID = @PersonID  ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);




            try
            {
                connection.Open();

                isDeleted = command.ExecuteNonQuery() > 0;

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                connection.Close();
                command.Dispose();
            }



            return isDeleted;
        }

        public static bool isPersonExistsById(int PersonID)
        {
            bool isExists = false;

            SqlConnection connection = new SqlConnection(DataAccessLayerSettings.ConnectionString);

            string query = @"  SELECT COUNT(*) FROM People  WHERE PersonID = @PersonID  ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);




            try
            {
                connection.Open();

                isExists = Convert.ToInt32(command.ExecuteScalar()) > 0;

            }
            catch (Exception ex)
            {
                throw new Exception("Error ", ex);
            }
            finally
            {
                connection.Close();
                command.Dispose();
            }



            return isExists;
        }

        public static bool FindPersonByID(
           int personID,
           ref string nationalNO,
           ref string firstname,
           ref string secondName,
           ref string thirdName,
           ref string lastName,
           ref DateTime dateOfBirth,
           ref char gender,
           ref string address,
           ref string phone,
           ref string email,
           ref int countryID,
           ref string imagePath)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessLayerSettings.ConnectionString);

            string query = @"SELECT * FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", personID);

            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    nationalNO = (string)reader["NationalNo"];
                    firstname = (string)reader["FirstName"];
                    secondName = (string)reader["SecondName"];
                    thirdName = (string)reader["ThirdName"];
                    lastName = (string)reader["LastName"];
                    dateOfBirth = (DateTime)reader["DateOfBirth"];
                    gender = Convert.ToChar(reader["Gender"]);
                    address = (string)reader["Address"];
                    phone = (string)reader["Phone"];
                    email = (string)reader["Email"];
                    countryID = (int)reader["CountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                        imagePath = (string)reader["ImagePath"];
                    else
                        imagePath = "";

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Error finding person", ex);
            }
            finally
            {
                connection.Close();
                command.Dispose();
            }

            return isFound;

        }





        public static bool FindPersonByName(
         ref int personID,
         ref string nationalNO,
         string firstname,
         ref string secondName,
         ref string thirdName,
         ref string lastName,
         ref DateTime dateOfBirth,
         ref char gender,
         ref string address,
         ref string phone,
         ref string email,
         ref int countryID,
         ref string imagePath)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessLayerSettings.ConnectionString);

            string query = @"SELECT * FROM People WHERE FirstName = @FirstName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", personID);

            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    nationalNO = (string)reader["NationalNo"];
                    personID = Convert.ToInt32(reader["PersonID"]);
                    secondName = (string)reader["SecondName"];
                    thirdName = (string)reader["ThirdName"];
                    lastName = (string)reader["LastName"];
                    dateOfBirth = (DateTime)reader["DateOfBirth"];
                    gender = Convert.ToChar(reader["Gender"]);
                    address = (string)reader["Address"];
                    phone = (string)reader["Phone"];
                    email = (string)reader["Email"];
                    countryID = (int)reader["CountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                        imagePath = (string)reader["ImagePath"];
                    else
                        imagePath = "";

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Error finding person", ex);
            }
            finally
            {
                connection.Close();
                command.Dispose();
            }

            return isFound;

        }





        public static bool FindPersonByNationalNumber(
           ref int personID,
           string nationalNO,
           ref string firstname,
           ref string secondName,
           ref string thirdName,
           ref string lastName,
           ref DateTime dateOfBirth,
           ref char gender,
           ref string address,
           ref string phone,
           ref string email,
           ref int countryID,
           ref string imagePath)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessLayerSettings.ConnectionString);

            string query = @"SELECT * FROM People WHERE NationalNO = @NationalNO";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", personID);

            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    firstname = (string)reader["FirstName"];
                    personID = Convert.ToInt32(reader["PersonID"]);
                    secondName = (string)reader["SecondName"];
                    thirdName = (string)reader["ThirdName"];
                    lastName = (string)reader["LastName"];
                    dateOfBirth = (DateTime)reader["DateOfBirth"];
                    gender = Convert.ToChar(reader["Gender"]);
                    address = (string)reader["Address"];
                    phone = (string)reader["Phone"];
                    email = (string)reader["Email"];
                    countryID = (int)reader["CountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                        imagePath = (string)reader["ImagePath"];
                    else
                        imagePath = "";

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Error finding person", ex);
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
