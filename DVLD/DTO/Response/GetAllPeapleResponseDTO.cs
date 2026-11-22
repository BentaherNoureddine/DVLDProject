

using DVLDBuisnessLayer.Peaple;
using Shared.SharedPersonStrigs;
using System;
using System.Data;

namespace DTO.Response
{
    public class GetAllPeapleResponseDTO
    {
       


        public static DataTable GetAllPeapleResponseDTOFromPeapleDataTable(DataTable peapleDataTable)
        {
            DataTable responseDataTable = new DataTable();

            responseDataTable.Columns.Add(PersonStrings.PersonIDString, typeof(int));
            responseDataTable.Columns.Add(PersonStrings.NationalNumberString, typeof(string));
            responseDataTable.Columns.Add(PersonStrings.FirstNameString, typeof(string));
            responseDataTable.Columns.Add(PersonStrings.SecondNameString, typeof(string));
            responseDataTable.Columns.Add(PersonStrings.ThridNameString, typeof(string));
            responseDataTable.Columns.Add(PersonStrings.LastNameString, typeof(string));
            responseDataTable.Columns.Add(PersonStrings.DateOfBirthStrring, typeof(DateTime));
            responseDataTable.Columns.Add(PersonStrings.GenderString, typeof(string));
            responseDataTable.Columns.Add(PersonStrings.CountryNameString, typeof(string));
            responseDataTable.Columns.Add(PersonStrings.PhoneString, typeof(string));
            responseDataTable.Columns.Add(PersonStrings.EmailString, typeof(string));



            responseDataTable.Merge(peapleDataTable, false, MissingSchemaAction.Ignore);

            foreach (DataRow row in responseDataTable.Rows) 
            {
                row[PersonStrings.GenderString] = Person.getGenderFromCharToString(Convert.ToChar(row[PersonStrings.GenderString]));
            }

            return responseDataTable;
            


        }




    }
}
