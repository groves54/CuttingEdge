﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuttingEdge.Models
{
    public class Appointments
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime date { get; set; }
        public string Description { get; set; }
    }
}