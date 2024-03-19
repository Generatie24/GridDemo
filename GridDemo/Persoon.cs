using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridDemo
{
    public class Persoon
    {
        public string Naam { get; set; }
        public int Leeftijd { get; set; }
        public string Geslacht { get; set; }
        public string Land { get; set; }

        public Persoon(string naam, int leeftijd, string geschat, string land)
        {
            Naam = naam;
            Leeftijd = leeftijd;
            Geslacht = geschat; 
            Land = land;
        }
    }
}
