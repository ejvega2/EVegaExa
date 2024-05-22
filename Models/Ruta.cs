using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVegaExa.Models
{
    public class Ruta
    {
        public int id_ruta { get; set; }
        public int id_conductor { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
    }
}
