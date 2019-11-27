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
    public class InsertController : ApiController
    {
        // GET: api/Insert
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Insert/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Insert
        [EnableCors(origins: "*", "*", "*")]
        public void Post([FromBody] ItemModel insert)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQuery = $"insert into plansmart.dbo.[items](date , commitment , user_id) values ('{insert.date}' , '{insert.commitment}' , {insert.item_id} )";

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.ExecuteNonQuery();
            connection.Close();


        }

        // PUT api/values/5
        // PUT: api/Insert/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Insert/5
        [EnableCors(origins: "*", "*", "*")]
        public void Delete(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQuery = $"DELETE FROM plansmart.dbo.[items] WHERE id = {id} ";

            SqlCommand command = new SqlCommand(sqlQuery, connection);


            command.ExecuteNonQuery();
            
        }
    }
}
