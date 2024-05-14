using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    internal class Bedrijf : Gegevens
    {
        public string Naam { get; set; }

        public override string ToString()
        {
            string result = "";
            if (Naam != null)
            {
                result += "Naam: " + Naam + "\n";
            }
            result += base.ToString();
            return result;
        }
        public Bedrijf(string naam, string adres, string telefoonnummer = null, string email = null)
        {
            Naam = naam;
            Adres = adres;
            Telefoonnummer = telefoonnummer;
            Email = email;
        }
    }
}
