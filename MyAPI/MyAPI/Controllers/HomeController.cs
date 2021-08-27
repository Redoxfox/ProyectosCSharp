using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public async Task<IActionResult> Get() 
        {
           
            var Homes = new List<entityHome>();
            string query = @"select id, nombre from casa";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaulfConnection");
            MySqlDataReader myReader;
            using (MySqlConnection connection = new MySqlConnection(sqlDataSource))
            {
                await connection.OpenAsync();
                using(MySqlCommand mycommand = new MySqlCommand(query, connection)) 
                {
                    myReader = mycommand.ExecuteReader();
                    //table.Load(myReader);
                    while (await myReader.ReadAsync())
                    {
                        var newhome = new entityHome()
                        {
                            id = myReader.GetInt32(0),
                            nombre = myReader.GetString(1)
                        };

                        Homes.Add(newhome);
                        
                    }

                    myReader.Close();
                    connection.Close();
                }
            }

            return Ok(Homes);
        }

    }
}
