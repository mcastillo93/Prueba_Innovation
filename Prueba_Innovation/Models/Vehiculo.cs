using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Innovation.Models
{
    public class Vehiculo
    {
        [Key]
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string DNI_Conductor { get; set; }
        [ForeignKey("DNI_Conductor")]
        public virtual Conductor Conductor { get; set; }

    }
}
