using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlanSmartBackEnd
{
    public class DbQuerying
    {

        public bool Insert(string cmdText,Dictionary<string, string> parms)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand(cmdText, cn);

            return false;
        }
    }
}