using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerApp.Models.Domain_Classes
{
    public class Specificatie
    {
        public int SpecificatieID { get; private set; }
        public string Kleur { get; private set; }
        public bool Bluetooth { get; private set; }
        public int Geheugen { get; private set; }
        public bool WiFi { get; private set; }
        public bool DrieG { get; private set; }
        public bool VierG { get; private set; }
        public bool Draadloos { get; private set; }
        public decimal Amphere { get; private set; }

        public Specificatie(int specificatieId, string kleur, bool bluetooth, int geheugen, bool wifi, bool drieG, bool vierG,
            bool draadloos, decimal amphere)
        {

        }

        public Specificatie()
        {

        }

        
    }
}