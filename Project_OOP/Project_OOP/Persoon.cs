using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    internal class Persoon : Gegevens
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
      

        public override string ToString()
        {
            string result = "";
            if (Voornaam != null )
            {
                result += "Vooraam: " + Voornaam + "\n";
            }
            if (Achternaam != null)
            {
                result += "Achternaam: " + Achternaam + "\n";
            }
          
            result += base.ToString();
            return result;
        }
        public Persoon(string voornaam, string achternaam, string adres, string nummer = null, string mail = null)
        {
            Voornaam = voornaam;
            Adres = adres;
            Telefoonnummer = nummer;
            Email = mail;
            Achternaam = achternaam;
        }
    }
}
