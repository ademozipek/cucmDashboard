using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGBIS
{
    internal class Device
    {
        public string Name
        {
            get;
            set;
        }
        public string Line
        {
            get;
            set;
        }
        public string Model
        {
            get;
            set;
        }

        public Device(string n, string l, string m)
        {
            Name = n;
            Line = l;
            Model = m;
        }
    }
}
