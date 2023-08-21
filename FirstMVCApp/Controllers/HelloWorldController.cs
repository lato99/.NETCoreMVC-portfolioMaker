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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioMakerApp.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {

            return View();
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

                return View(persons);

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

                return View("Privacy", persons);
            }


        }










    }
}

