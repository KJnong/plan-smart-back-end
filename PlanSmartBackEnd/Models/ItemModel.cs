using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanSmartBackEnd.Models
{
    public class ItemModel
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string commitment { get; set; }
        public int item_id { get; set; }

    }
}