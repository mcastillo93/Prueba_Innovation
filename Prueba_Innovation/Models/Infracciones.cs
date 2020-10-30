using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Innovation.Models
{
    public class Infracciones
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Puntos { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string DNI_Conductor { get; set; }
        [ForeignKey("DNI_Conductor")]
        public virtual Conductor Conductor { get; set; }

        public string Matricula_Vehiculo { get; set; }
        [ForeignKey("Matricula_Vehiculo")]
        public virtual Vehiculo Vehiculo { get; set; }
    }
}
