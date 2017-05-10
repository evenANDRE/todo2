using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace todo2.Models
{
    public class Person
    {
        public int id { get; set; }
        public int personId { get; set; }
        public string navn { get; set; }
        public string epost { get; set; }
        public int tlfnr { get; set; }
        public int count { get; set; }
    }
}