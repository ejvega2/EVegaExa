using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVegaExa.Models
{
    public class Estudiante
    {
        public int id_estudiante { get; set; }
        public int id_conductor { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string cedula { get; set; }
        public string ruta { get; set; }
    }
}
