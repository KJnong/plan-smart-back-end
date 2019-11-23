using PlanSmartBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PlanSmartBackEnd.Controllers
{
    public class LoginController : ApiController
    {
        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        [EnableCors(origins: "*", "*", "*")]
        public IHttpActionResult Post([FromBody]LoginModel userLogin)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQuery = $"select * FROM ToDo.dbo.[user] WHERE userName = '{userLogin.userName}' AND password ='{userLogin.password}'";

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            SqlDataReader results = command.ExecuteReader();
            bool read = results.Read();
            if (read)
            {
                UserModel loggedInUser = new UserModel
                {
                    id = results.GetInt32(0),
                    name = results.GetString(1),
                    lastName = results.GetString(2),
                    email = results.GetString(3),
                    userName = results.GetString(4),
                    password = results.GetString(5)
                };

                return Ok(loggedInUser);
            }

            return NotFound();
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id) 
        {
        }
    }
}
