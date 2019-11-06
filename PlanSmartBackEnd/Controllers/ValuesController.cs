using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlanSmartBackEnd.Models;
using System.Data.SqlClient;
using System.Web.Http.Cors;

namespace PlanSmartBackEnd.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "firstname", "jethro" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [EnableCors(origins: "*","*","*")]
        public IEnumerable<string> Post([FromBody]UserModel user)
        {
            string conneciionString = @"Data Source=DESKTOP-GLPCHOA;Initial Catalog=Todo;User ID=DESKTOP-GLPCHOA\Jethro; Integrated Security=true";
            SqlConnection connection = new SqlConnection(conneciionString);
            connection.Open();

            string sqlQuery = $"INSERT INTO [dbo].[User] ([name] ,[lastName] ,[email] ,[userName] ,[password]) VALUES ('{user.name}',  '{user.lastName}', '{user.email}', '{user.userName}', '{user.password}')";

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.ExecuteNonQuery();
            return new string[] { user.name, user.lastName, user.email };
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
