using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HOA.Classes
{
    public class Beboer
    {
        public string navn { get; set; }
        public string adresse { get; set; }
        public int tlf { get; set; }
        public string brugernavn { get; set; }
        public string password { get; set; }
        public string mail { get; set; }


        public Beboer() { }
        public Beboer(string brugernavn, string password)
        {
            this.brugernavn = brugernavn;
            this.password = password;
        }
        public Beboer(string navn, string adresse, int tlf, string brugernavn, string password, string mail)
        {
            this.navn = navn;
            this.adresse = adresse;
            this.tlf = tlf;
            this.brugernavn = brugernavn;
            this.password = password;
            this.mail = mail;
        }
    }
}
