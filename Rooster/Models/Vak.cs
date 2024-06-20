using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Rooster.Models
{
    public class Vak

    {
        public int VakId { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
    }
}
