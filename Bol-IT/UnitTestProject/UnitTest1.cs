using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using BusinessLayer;
using DataAccessLayer;
using ClosedXML.Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Xml;
using System.Text.RegularExpressions;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (SqlConnection connection = DataAccessLayerFacade.GetConnection())
            {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandText = "INSERT INTO personalData OUTPUT INSERTED.id VALUES (@fName, @mName, @lName, @phoneNr, @address, @zipcode, @mail)";
                    command1.Parameters.AddWithValue("@fName", "Christoffwer");
                    command1.Parameters.AddWithValue("@mName", "kraggh");
                    command1.Parameters.AddWithValue("@lname", "Pwedersen");
                    command1.Parameters.AddWithValue("@phoneNr", "53565529");
                    command1.Parameters.AddWithValue("@address", "Her212");
                    command1.Parameters.AddWithValue("@zipcode", "7100");
                    command1.Parameters.AddWithValue("@mail", "Christoffwer@stuff.dk");
                    connection.Open();
                    int user1ID = (int)command1.ExecuteScalar();
                    connection.Close();

                    SqlCommand command2 = new SqlCommand();
                    command2.Connection = connection;
                    command2.CommandText = "INSERT INTO personalData OUTPUT INSERTED.id VALUES (@fName, @mName, @lName, @phoneNr, @address, @zipcode, @mail)";
                    command2.Parameters.AddWithValue("@fName", "Simone");
                    command2.Parameters.AddWithValue("@mName", "etellerandet");
                    command2.Parameters.AddWithValue("@lname", "kanikkehuskehvadduhedder");
                    command2.Parameters.AddWithValue("@phoneNr", 66642069);
                    command2.Parameters.AddWithValue("@address", "Her222");
                    command2.Parameters.AddWithValue("@zipcode", 7100);
                    command2.Parameters.AddWithValue("@mail", "simone@stuff.dk");
                    connection.Open();
                    int user2ID = (int)command2.ExecuteScalar();
                    connection.Close();

                    //USER 1
                    SqlCommand command3 = new SqlCommand();
                    command3.Connection = connection;
                    command3.CommandText = "INSERT INTO agent VALUES (@aId, @nrOfSales)";
                    command3.Parameters.AddWithValue("@aId", user2ID);
                    command3.Parameters.AddWithValue("@nrOfSales", 4);
                    connection.Open();
                    command3.ExecuteNonQuery();
                    connection.Close();

                    //USER 2
                    SqlCommand command4 = new SqlCommand();
                    command4.Connection = connection;
                    command4.CommandText = "INSERT INTO seller VALUES (@sId, @aId)";
                    command4.Parameters.AddWithValue("@sId", user2ID);
                    command4.Parameters.AddWithValue("@aId", 120);
                    connection.Open();
                    command4.ExecuteNonQuery();
                    connection.Close();
                
            }
            
            //GetLatLongFromAddress("Engblommevej 19", "Horsens", "Midtjylland", "8700");

        }



        static string GetLatLongFromAddress(string street, string city, string state, string zip)
        {
            string bingMapsUri = string.Format(@"http://dev.virtualearth.net/REST/v1/Locations/DK/" + Regex.Replace
            (street, "#", "") + ", " + city + ", " + state + "?o=xml&amp;key=BingMapsKey");
            XmlDocument bingMapsXmlDoc = new XmlDocument();
            bingMapsXmlDoc.Load(bingMapsUri);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(bingMapsXmlDoc.NameTable);
            nsmgr.AddNamespace("rest", "http://schemas.microsoft.com/search/local/ws/rest/v1");
            string sLong = bingMapsXmlDoc.DocumentElement.SelectSingleNode(@".//rest:Longitude", nsmgr).InnerText;
            string sLat = bingMapsXmlDoc.DocumentElement.SelectSingleNode(@".//rest:Latitude", nsmgr).InnerText;

            return sLat + "~" + sLong;
        }
    }
}