using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Innovation.Models
{
    public class Conductor
    {
        [Key]
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public decimal Puntos { get; set; }
    }
}
