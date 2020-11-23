using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrarioVideolezioni
{
    class LinkAttivo
    {
        public string Link;
        public string NomeMat;
        public int Id;

        public LinkAttivo(string l = "", string n = "", int i = 0)
        {
            Link = l;
            NomeMat = n;
            Id = i;
        }
    }
}
