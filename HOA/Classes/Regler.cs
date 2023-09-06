using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOA.Classes
{
    public class Regler
    {
        public int id { get; set; }
        public string regel { get; set; }
        public string beskrivelse { get; set; }

        public Regler() { }
        public Regler(int id, string regel, string beskrivelse)
        {
            this.id = id;
            this.regel = regel;
            this.beskrivelse = beskrivelse;
        }
    }
}
