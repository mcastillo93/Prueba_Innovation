using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Prueba_Innovation.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Innovation.ViewModels
{
    public class InfraccionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public decimal Puntos { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string DNI_Conductor { get; set; }
        [Display(Name = "Conductor")]
        public string ConductorNombre { get; set; }
        [Display(Name = "Matricula")]
        public string Matricula_Vehiculo { get; set; }


        public InfraccionViewModel() { }

        public InfraccionViewModel(Models.Infracciones x) {
            this.Id = x.Id;
            this.Descripcion = x.Descripcion;
            this.Puntos = x.Puntos;
            this.Fecha = x.Fecha;
            this.Hora = x.Hora;
            this.DNI_Conductor = x.DNI_Conductor;
            this.Matricula_Vehiculo = x.Matricula_Vehiculo;
        }

        public Models.Infracciones ToEntity()
        {
            return new Models.Infracciones {
                Id = this.Id,
                Descripcion = this.Descripcion,
                Puntos = this.Puntos,
                Fecha = this.Fecha,
                Hora = this.Hora,
                DNI_Conductor = this.DNI_Conductor,
                Matricula_Vehiculo = this.Matricula_Vehiculo
            };
        }

    }
}
