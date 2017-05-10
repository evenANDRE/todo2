using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace todo2.Models
{
    public class Item
    {
        public int id { get; set; }
        public int personId { get; set; } //foreign key
        public int Number { get; set; }
        public string Tittel { get; set; }
        public string Beskrivelse { get; set; }
        public string Produkt { get; set; }
        public string Type { get; set; }
    }
}