using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOA.Classes
{
    internal class validUser
    {
        public bool valid { get; set; }


        public validUser() { }
        public validUser(bool valid)
        {
            this.valid = valid;
        }
    }
}
