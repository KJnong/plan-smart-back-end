﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanSmartBackEnd.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

    }
}