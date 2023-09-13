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
        public decimal lattitude { get; set; }
        public decimal longtitude { get; set; }
        public int regel_id { get; set; }
        public Image photo { get; set; }

        public Anmeldelse() { }
        public Anmeldelse(int andmelder_id, decimal lattitude, decimal longtitude, int regel_id, Image photo)
        {
            this.andmelder_id = andmelder_id;
            this.lattitude = lattitude;
            this.longtitude = longtitude;
            this.regel_id = regel_id;
            this.photo = photo;
        }
        public Anmeldelse(int andmelder_id, decimal lattitude, decimal longtitude, int regel_id)
        {
            this.andmelder_id = andmelder_id;
            this.lattitude = lattitude;
            this.longtitude = longtitude;
            this.regel_id = regel_id;
        }
    }
}
