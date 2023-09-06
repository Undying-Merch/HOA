using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOA.Classes
{
    internal class Anmeldelse
    {
        public int id { get; set; }
        public int andmelder_id { get; set; }
        public int location_id { get; set; }
        public int regel_id { get; set; }

        public Anmeldelse() { }
        public Anmeldelse(int id, int andmelder_id, int location_id, int regel_id)
        {
            this.id = id;
            this.andmelder_id = andmelder_id;
            this.location_id = location_id;
            this.regel_id = regel_id;
        }
    }
}
