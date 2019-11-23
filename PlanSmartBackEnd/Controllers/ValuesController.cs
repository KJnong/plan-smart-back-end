using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlanSmartBackEnd.Models;
using System.Data.SqlClient;
using System.Web.Http.Cors;
using System.Configuration;

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
        [EnableCors(origins: "*", "*", "*")]
        public IEnumerable<string> Post([FromBody]UserModel user)
        {
            string conneciionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(conneciionString);
            connection.Open();

            string sqlQuery = "UserInsert";

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Name", user.name);
            command.Parameters.AddWithValue("@LastName", user.lastName);
            command.Parameters.AddWithValue("@Email", user.email);
            command.Parameters.AddWithValue("@Username", user.userName);
            command.Parameters.AddWithValue("@Password", user.password);

            command.ExecuteNonQuery();
            ;

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
