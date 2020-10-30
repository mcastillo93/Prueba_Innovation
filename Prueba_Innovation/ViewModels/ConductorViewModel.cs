using Prueba_Innovation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Innovation.ViewModels
{
    public class ConductorViewModel
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(10, ErrorMessage = "Excede El Numero De Caracteres Permitidos")]
        [Display(Name = "DNI")]
        public string DNI { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Nombre Conductor")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Apellidos Conductor")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public decimal Puntos { get; set; }
    
        public ConductorViewModel() { }

        public ConductorViewModel(Conductor c) {
            this.DNI = c.DNI;
            this.Nombre = c.Nombre;
            this.Apellidos = c.Apellidos;
            this.Puntos = c.Puntos;
        }

        public Models.Conductor ToEntity()
        {
            return new Models.Conductor
            {
                DNI = this.DNI,
                Nombre = this.Nombre,
                Apellidos = this.Apellidos,
                Puntos = this.Puntos
            };
        }
    }

}
