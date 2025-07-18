using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class Match
    {
        public int id { get; set; }
        public string name { get; set; }
        public string p1 { get; set; }
        public string p2 { get; set; }
        public string result { get; set; }
        public string moveHistory { get; set; }
        public DateTime date { get; set; }
    }
}
