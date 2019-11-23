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
    public class ItemsController : ApiController
    {
        // GET: api/Items
        [EnableCors(origins: "*", "*", "*")]
        public IEnumerable<ItemModel> Post([FromBody]UserModel userId)
        {

            string itemsConnection = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(itemsConnection);
            connection.Open();

            string itemQuery = $"select * from ToDo.dbo.[items] where dbo.[items].item_id = {userId.id} ;";
            SqlCommand itemCommand = new SqlCommand(itemQuery, connection);
            SqlDataReader results = itemCommand.ExecuteReader();
           

            List<ItemModel> infoArray = new List<ItemModel>();
            while (results.Read())
            {
                ItemModel itemInfo = new ItemModel
                {
                    date = results.GetDateTime(1),
                    commitment = results.GetString(2),
                    id = results.GetInt32(0),
                };
                infoArray.Add(itemInfo);

                
            }
            return infoArray;

        }

        // GET: api/Items/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Items
        
  

        // PUT: api/Items/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Items/5
        public void Delete(int id)
        {
        }
    }
}
