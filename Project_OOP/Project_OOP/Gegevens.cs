using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    abstract class Gegevens
    {
        public string Telefoonnummer { get; set; }
        public string Adres { get; set; }

        public string Email { get; set; }

        public override string ToString()
        {
            string result = "";
            if (Telefoonnummer != null)
            {
                result += "Telefoonnummer: " + Telefoonnummer + "\n";
            }
            if (Email != null)
            {
                result += "Email: " + Email + "\n";
            }
            if (Adres != null)
            {
                result += "Adres: " + Adres + "\n";
            }
            return result;


        }


    }
}
