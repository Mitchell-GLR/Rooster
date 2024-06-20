using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Rooster.Models
{
    public class Les
    {
        public int LesId { get; set; }
        public int VakId { get; set; }
        public int DocentId { get; set; }
        public int DagId { get; set; }
        public int LokaalId { get; set; }
        public TimeSpan StartTijd { get; set; }
        public TimeSpan EindTijd { get; set ; }

        [Ignore]
        public string VakNaam { get; set; }
        [Ignore]
        public string DocentNaam { get; set; }
        [Ignore]
        public string KlasLokaal { get; set; }
    }
}
