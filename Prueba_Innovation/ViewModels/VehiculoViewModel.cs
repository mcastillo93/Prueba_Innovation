using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Innovation.ViewModels
{
    public class VehiculoViewModel
    {
        
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(20, ErrorMessage = "Excede El Numero De Caracteres Permitidos")]
        public string Matricula { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(25, ErrorMessage = "Excede El Numero De Caracteres Permitidos")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(10, ErrorMessage = "Excede El Numero De Caracteres Permitidos")]
        public string Modelo { get; set; }
        [Display(Name = "DNI Conductor")]
        public string DNI_Conductor { get; set; }
        [Display(Name = "Conductor")]
        public string ConductorNombre { get; set; }
        public virtual ConductorViewModel Conductor { get; set; }

        public VehiculoViewModel() { }

        public VehiculoViewModel(Models.Vehiculo x) {
            this.Matricula = x.Matricula;
            this.Marca = x.Marca;
            this.Modelo = x.Modelo;
            this.DNI_Conductor = x.Conductor.DNI;
            this.ConductorNombre = x.Conductor.Nombre + " " + x.Conductor.Apellidos;
        }

        

        public Models.Vehiculo ToEntity()
        {
            return new Models.Vehiculo
            {
                Matricula = this.Matricula,
                Marca = this.Marca,
                Modelo = this.Modelo,
                DNI_Conductor = this.DNI_Conductor
            };
        }
    }
}
