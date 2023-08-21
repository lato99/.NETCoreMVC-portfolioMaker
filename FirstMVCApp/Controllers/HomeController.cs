using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortfolioMakerApp.Models;
using MySql.Data.MySqlClient;
using System;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Google.Protobuf.WireFormat;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Asn1.X509;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;
using Org.BouncyCastle.Utilities.Zlib;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI;
using System.Linq;
using System.Configuration;
using Org.BouncyCastle.Crypto;
using System.Reflection.PortableExecutable;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;

namespace PortfolioMakerApp.Controllers;

public class HomeController : Controller
{


  
    public HomeController()
    {



    }

    public IActionResult Index()
    {
        
            return View("OpeningScreen");
            
            //return GetAllUsers();
        
    }


    [HttpPost]
    public void AddToDiller(int int1, string str1, string str2, string str3, string str4, string str5, string str6)
    {

        string cmd1 = "INSERT INTO testdb.languages (id, dilIsmi, genelDilDerecesi, okumaDerecesi, yazmaDerecesi, dinlemeDerecesi, konusmaDerecesi) " +
                      "VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');";
        // Use string.Format to replace placeholders {0s {1}, ..., {6} with the provided values
    
        string cmd2;

        cmd2 = string.Format(cmd1, int1, str1, str2, str3, str4, str5, str6);

        string connectionString = "server=localhost;port=3306;database=testdb;user=root;password=loltac182003;";



        //Create mysql connection
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            con.Open();
            //create command object for creating the query to get the data
            MySqlCommand cmd = new MySqlCommand(cmd2, con);

            //the reader will execute the reader and give us the data
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {


            }
            reader.Close();
            con.Close();
        }


        // You can return a JSON response or any other response as needed
        //return Json(new { message = "Data added successfully" });
    }

    [HttpPost]
    public void DeleteFromDiller(int int1, string str1, string str2, string str3, string str4, string str5, string str6)
    {
        // Create the DELETE SQL query
        string cmd1 = "DELETE FROM testdb.languages WHERE id = {0} AND dilIsmi = '{1}' AND genelDilDerecesi = '{2}' AND okumaDerecesi = '{3}' AND yazmaDerecesi = '{4}' AND dinlemeDerecesi = '{5}' AND konusmaDerecesi = '{6}';";
        string cmd2;
      

      
        cmd2 = string.Format(cmd1, int1, str1, str2, str3, str4, str5, str6);

        // Normally this connection string should be inside the appsettings.json
        string connectionString = "server=localhost;port=3306;database=testdb;user=root;password=loltac182003;";

        //Create mysql connection
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            con.Open();
            //create command object for creating the query to get the data
            MySqlCommand cmd = new MySqlCommand(cmd2, con);

            //the reader will execute the reader and give us the data
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {


            }
            reader.Close();
        }


        // You can return a JSON response or any other response as needed
        //return Json(new { message = "Data added successfully" });
    }

    [HttpPost]
    public void AddToOkullar(int int1, string str1, string str2, string str3, string str4, DateTime str5, DateTime str6)
    {



        string cmd1 = "INSERT INTO testdb.okul (id, OkulIsmi, OkulAdresi, BolumIsmi, LisansTipi, baslangicTarihi, bitisTarihi) " +
                      "VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');";

  

        // Use string.Format to replace placeholders {0s {1}, ..., {6} with the provided values
        string cmd2 = string.Format(cmd1,int1, str1, str2, str3, str4, str5, str6);
        //normally this connection string should be inside the appsettings.json
        string connectionString = "server=localhost;port=3306;database=testdb;user=root;password=loltac182003;";



        //Create mysql connection
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            con.Open();
            //create command object for creating the query to get the data
            MySqlCommand cmd = new MySqlCommand(cmd2, con);

            //the reader will execute the reader and give us the data
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {


            }
            reader.Close();
            con.Close();
        }


        // You can return a JSON response or any other response as needed
        //return Json(new { message = "Data added successfully" });
    }


    [HttpPost]
    public void DeleteFromOkullar(int int1, string str1, string str2, string str3, string str4, DateTime str5, DateTime str6)
    {
        // Assuming you have a database connection or an ORM context instance called 'dbContext'
        string cmd1 = "DELETE FROM testdb.okul " +
                           "WHERE id = {0} " +
                           "AND OkulIsmi = '{1}' " +
                           "AND OkulAdresi = '{2}' " +
                           "AND BolumIsmi = '{3}' " +
                           "AND LisansTipi = '{4}' " +
                           "AND baslangicTarihi = '{5}' " +
                           "AND bitisTarihi = '{6}';";
        // Use string.Format to replace placeholders {0s {1}, ..., {6} with the provided values
        string cmd2 = string.Format(cmd1, int1, str1, str2, str3, str4, str5, str6);
        //normally this connection string should be inside the appsettings.json
        string connectionString = "server=localhost;port=3306;database=testdb;user=root;password=loltac182003;";



        //Create mysql connection
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            con.Open();
            //create command object for creating the query to get the data
            MySqlCommand cmd = new MySqlCommand(cmd2, con);

            //the reader will execute the reader and give us the data
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {


            }
            reader.Close();
        }


        // You can return a JSON response or any other response as needed
        //return Json(new { message = "Data added successfully" });
    }


    [HttpPost]
    public void Work(int int1, string str1, string str2, string str3, string str4, DateTime str5, DateTime str6)
    {


        string sql = "INSERT INTO testdb.workhist (id, companyName, companyAddress, departmant, workType, startDate, endDate) " +
                       "VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');";



        // Use string.Format to replace placeholders {0s {1}, ..., {6} with the provided values
        string cmd2 = string.Format(sql, int1, str1, str2, str3, str4, str5, str6);
        //normally this connection string should be inside the appsettings.json
        string connectionString = "server=localhost;port=3306;database=testdb;user=root;password=loltac182003;";


        //Create mysql connection
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            con.Open();
            //create command object for creating the query to get the data
            MySqlCommand cmd = new MySqlCommand(cmd2, con);

            //the reader will execute the reader and give us the data
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {


            }
            reader.Close();
            con.Close();
        }


        // You can return a JSON response or any other response as needed
        //return Json(new { message = "Data added successfully" });
    }



    [HttpPost]
    public void DeleteFromWorkHistory(int int1, string str1, string str2, string str3, string str4, DateTime str5, DateTime str6)
    {
        // Assuming you have a database connection or an ORM context instance called 'dbContext'
        string deleteCmd = "DELETE FROM testdb.workhist " +
                           "WHERE id = {0} " +
                           "AND companyName = '{1}' " +
                           "AND companyAddress = '{2}' " +
                           "AND departmant = '{3}' " +
                           "AND workType = '{4}' " +
                           "AND startDate = '{5}' " +
                           "AND endDate = '{6}';";



        // Use string.Format to replace placeholders {0s {1}, ..., {6} with the provided values
        string cmd2 = string.Format(deleteCmd, int1, str1, str2, str3, str4, str5, str6);
        //normally this connection string should be inside the appsettings.json
        string connectionString = "server=localhost;port=3306;database=testdb;user=root;password=loltac182003;";



        //Create mysql connection
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            con.Open();
            //create command object for creating the query to get the data
            MySqlCommand cmd = new MySqlCommand(cmd2, con);

            //the reader will execute the reader and give us the data
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {


            }
            reader.Close();
        }
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }







    //[HttpPost]
    //public void deleteOldUsers()
    //{

    //    string query = "DELETE FROM testdb.person WHERE " +
    //                   "firstName = '{0}' AND " +
    //                   "lastName = '{1}' AND " +
    //                   "age = '{2}' AND " +
    //                   "address = '{3}' AND " +
    //                   "martialStatus = '{4}' AND " +
    //                   "telephone = '{5}' AND " +
    //                   "email = '{6}'";
    //    // Use string.Format to replace placeholders {0s {1}, ..., {6} with the provided values
    //    string cmd2 = string.Format(query, -1, -1, -1, -1, -1, -1, -1);
    //    //normally this connection string should be inside the appsettings.json
    //    string connectionString = "server=localhost;port=3306;database=testdb;user=root;password=loltac182003;";



    //    //Create mysql connection
    //    using (MySqlConnection con = new MySqlConnection(connectionString))
    //    {
    //        con.Open();
    //        //create command object for creating the query to get the data
    //        MySqlCommand cmd = new MySqlCommand(cmd2, con);

    //        //the reader will execute the reader and give us the data
    //        MySqlDataReader reader = cmd.ExecuteReader();
    //        while (reader.Read())
    //        {


    //        }
    //        reader.Close();
    //    }


    //    // You can return a JSON response or any other response as needed
    //    //return Json(new { message = "Data added successfully" });
    //}



    [HttpPost]
    public void initializeUser()
    {

        string cmd1 = "INSERT INTO testdb.person (firstName, lastName, age, address, martialStatus, telephone,email) " +
                      "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');";
        // Use string.Format to replace placeholders {0s {1}, ..., {6} with the provided values


        string cmd2 = string.Format(cmd1, -1, -1, -1, -1, -1, -1, -1);
        //normally this connection string should be inside the appsettings.json
        string connectionString = "server=localhost;port=3306;database=testdb;user=root;password=loltac182003;";



        //Create mysql connection
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            con.Open();
            //create command object for creating the query to get the data
            MySqlCommand cmd = new MySqlCommand(cmd2, con);

            //the reader will execute the reader and give us the data
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {


            }
            reader.Close();
        }


        // You can return a JSON response or any other response as needed
        //return Json(new { message = "Data added successfully" });
    }




    [HttpPost]
    public IActionResult AddUserToUsersDB(string str1, string str2, string str3, string str4, string str5, string str6, string str7, string str8)
    {
        // Construct the UPDATE query to set all fields to -1 for the specified user ID
        string query;
        string cmd2;
        int lastInsertedId;

        // Normally this connection string should be inside the appsettings.json
        string connectionString = "server=localhost;port=3306;database=testdb;user=root;password=loltac182003;";
        if (str8 != "-1")
        {
            query = "UPDATE testdb.person " +
                    "SET firstName = '{0}', lastName = '{1}', age = '{2}', " +
                    "address = '{3}', martialStatus = '{4}', " +
                    "telephone = '{5}', email = '{6}' " +
                    "WHERE Id = {7};";

            cmd2 = string.Format(query, str1, str2, str3, str4, str5, str6, str7,str8);
            // Create mysql connection
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                // Create command object for creating the query to get the data
                MySqlCommand cmd = new MySqlCommand(cmd2, con);

                // Execute the query (UPDATE command)
                cmd.ExecuteNonQuery();

                // Get the last inserted ID
                lastInsertedId = (int)cmd.LastInsertedId;
                con.Close();
            }

            return Json(int.Parse(str8));

        }
        else
        {
            query = "INSERT INTO testdb.person (firstName, lastName, age, address, martialStatus, telephone, email) " +
                    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');";
            cmd2 = string.Format(query, str1, str2, str3, str4, str5, str6, str7);
            // Create mysql connection
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                // Create command object for creating the query to get the data
                MySqlCommand cmd = new MySqlCommand(cmd2, con);

                // Execute the query (UPDATE command)
                cmd.ExecuteNonQuery();

                // Get the last inserted ID
                lastInsertedId = (int)cmd.LastInsertedId;
                con.Close();
            }

            return Json(lastInsertedId);
        }

        // Use string.Format to replace placeholders {0}, {1}, ..., {6}, and {7} with the provided values
        //string cmd2 = string.Format(query, str1,str2, str3, str4, str5, str6, str7);

        


    }

    [HttpPost]
    public IActionResult OpenUserPage()
    {
        return View("UserPage");
    }














    [HttpPost]
    public IActionResult GetAllUsers()
    {
        string query = "SELECT * FROM testdb.person";

        List<person_user> persons = new List<person_user>();
        string connectionString = "server=localhost;port=3306;database=testdb;user=root;password=loltac182003;";


        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                person_user person = new person_user
                {
                    firstName = reader["firstName"].ToString(),
                    lastName = reader["lastName"].ToString(),
                    age = reader["age"].ToString(),
                    address = reader["address"].ToString(),
                    martialStatus = reader["martialStatus"].ToString(),
                    telephone = reader["telephone"].ToString(),
                    email = reader["email"].ToString()
                };

                persons.Add(person);
            }

            reader.Close();
        }

        return View(persons);
    }









   

    [HttpPost]
    public IActionResult FilterUsers(string fname, string sname, int? minAge, int? maxAge, string city, string mstatus)
    {
        if (fname == "-11")
        {
            string query = "SELECT * FROM testdb.person";

            List<person_user> persons = new List<person_user>();
            string connectionString = "server=localhost;port=3306;database=testdb;user=root;password=loltac182003;";


            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    person_user person = new person_user
                    {
                        firstName = reader["firstName"].ToString(),
                        lastName = reader["lastName"].ToString(),
                        age = reader["age"].ToString(),
                        address = reader["address"].ToString(),
                        martialStatus = reader["martialStatus"].ToString(),
                        telephone = reader["telephone"].ToString(),
                        email = reader["email"].ToString()
                    };

                    persons.Add(person);
                }

                reader.Close();
            }

            return View("UserPage", persons);

            // Now you have the executed queries and the query results stored in your data structures.
            // You can use them as needed.
        }
        else
        {
            string connectionString = "server=localhost;port=3306;database=testdb;user=root;password=loltac182003;";
            string query = "SELECT * FROM testdb.person WHERE 1=1";

            if (!string.IsNullOrEmpty(fname))
                query += $" AND firstName LIKE '{fname}%'";

            if (!string.IsNullOrEmpty(sname))
                query += $" AND lastName LIKE '{sname}%'";

            if (minAge != null)
                query += $" AND age >= {minAge}";

            if (maxAge != null)
                query += $" AND age <= {maxAge}";

            if (!string.IsNullOrEmpty(city))
                query += $" AND address LIKE '{city}%'";

            if (!string.IsNullOrEmpty(mstatus))
                query += $" AND martialStatus = '{mstatus}'";

            List<person_user> persons = new List<person_user>();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    person_user person = new person_user
                    {
                        firstName = reader["firstName"].ToString(),
                        lastName = reader["lastName"].ToString(),
                        age = reader["age"].ToString(),
                        address = reader["address"].ToString(),
                        martialStatus = reader["martialStatus"].ToString(),
                        telephone = reader["telephone"].ToString(),
                        email = reader["email"].ToString()
                    };

                    persons.Add(person);
                }

                reader.Close();
            }

            return View("Index",persons);
        }

    }

   [HttpPost]
   public IActionResult goToUserPage()
    {
        string query = "SELECT * FROM testdb.person";

        List<person_user> persons = new List<person_user>();
        string connectionString = "server=localhost;port=3306;database=testdb;user=root;password=loltac182003;";


        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                person_user person = new person_user
                {
                    firstName = reader["firstName"].ToString(),
                    lastName = reader["lastName"].ToString(),
                    age = reader["age"].ToString(),
                    address = reader["address"].ToString(),
                    martialStatus = reader["martialStatus"].ToString(),
                    telephone = reader["telephone"].ToString(),
                    email = reader["email"].ToString()
                };

                persons.Add(person);
            }

            reader.Close();
        }

        return View("Index", persons);
    }

    [HttpPost]
    public IActionResult goToAdminPage()
    {
        string query = "SELECT * FROM testdb.person";

        List<person_user> persons = new List<person_user>();
        string connectionString = "server=localhost;port=3306;database=testdb;user=root;password=loltac182003;";


        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                person_user person = new person_user
                {
                    firstName = reader["firstName"].ToString(),
                    lastName = reader["lastName"].ToString(),
                    age = reader["age"].ToString(),
                    address = reader["address"].ToString(),
                    martialStatus = reader["martialStatus"].ToString(),
                    telephone = reader["telephone"].ToString(),
                    email = reader["email"].ToString()
                };

                persons.Add(person);
            }

            reader.Close();
        }

        return View("Privacy", persons);
    }

    [HttpPost]
    public async void UploadImage(string userId, IFormFile userImage, [FromServices] IWebHostEnvironment hostingEnvironment)
    {
        if (userImage != null && userImage.Length > 0)
        {
            // Generate a unique file name
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(userImage.FileName);

            // Combine the file path with the "images" folder in the current directory
            string folderPath = Path.Combine(hostingEnvironment.ContentRootPath, "images");
            string filePath = Path.Combine(folderPath, fileName);

            // Ensure the "images" folder exists
            Directory.CreateDirectory(folderPath);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await userImage.CopyToAsync(fileStream);
            }

            // You can save 'filePath' to a database or use it as needed

            // Since the return type is void, you don't need to explicitly return anything

            // Perform any additional logic or actions here if


            string cmd1 = "INSERT INTO testdb.user_images (imageName, person_id) " +
                          "VALUES ('{0}', '{1}');";
            // Use string.Format to replace placeholders {0s {1}, ..., {6} with the provided values

            string cmd2;

            cmd2 = string.Format(cmd1, fileName, userId);

            string connectionString = "server=localhost;port=3306;database=testdb;user=root;password=loltac182003;";



            //Create mysql connection
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                //create command object for creating the query to get the data
                MySqlCommand cmd = new MySqlCommand(cmd2, con);

                //the reader will execute the reader and give us the data
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                }
                reader.Close();
                con.Close();
            }
        }


        // If the upload fails, no need to return anything
    }


}

//ViewBag.Message = lastInsertedId.ToString();





//var EksikUrunID = $('#EksikUrunID').val();
//var formdata = new FormData();
//var EksikUrunResim = $('#EksikUrunResim').get(0).files;
//                formdata.append('', EksikUrunResim);
//                $.ajax({
//url: '@Url.Action("EksiUrunResimYukle", "Urunler")',
//                    data: { EksikUrunID: 1, EksikUrunResim: null },
//                    async: true,
//                    type: 'POST',
//                    processData: false,
//                    contentType: false,
//                    success: function() {
//    }
//});