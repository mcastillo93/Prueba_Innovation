using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba_Innovation.Models;
using Prueba_Innovation.ViewModels;

namespace Prueba_Innovation.Controllers
{
    public class InfraccionController : Controller
    {
        private readonly InnovationContext _context;

        public InfraccionController(InnovationContext context)
        {
            _context = context;
        }

        // GET: Infraccion
        public async Task<IActionResult> Index()
        {
            var List = await _context.Infracciones
               .Include(c => c.Conductor)
               .Include(v => v.Vehiculo)
               .Select(x => new InfraccionViewModel
               {
                   Id = x.Id,
                   Descripcion = x.Descripcion,
                   Puntos = x.Puntos,
                   Fecha = x.Fecha,
                   Hora = x.Hora,
                   ConductorNombre = x.Conductor.Nombre + " " + x.Conductor.Apellidos,
                   Matricula_Vehiculo = x.Matricula_Vehiculo,
               }).ToListAsync();

            return View(List);
        }

        // GET: Infraccion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            object Error;
            if (id == null)
            {
                Error = new ErrorViewModel
                {
                    Error = "Error al ontener la información en el Sistema.",
                    Message = "Verificar la información ingresada"
                };
                return View("~/Views/Shared/Error.cshtml", Error);
            }

            var infracciones = await _context.Infracciones
                .Include(i => i.Conductor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (infracciones == null)
            {
                Error = new ErrorViewModel
                {
                    Error = "Error al ontener la información en el Sistema.",
                    Message = "Verificar la información ingresada"
                };
                return View("~/Views/Shared/Error.cshtml", Error);
            }

            return View(infracciones);
        }

        // GET: Infraccion/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Conductor = await _context.Conductores.ToListAsync();
            ViewBag.Vehiculo = await _context.Vehiculos.ToListAsync();
            return View();
        }

        // POST: Infraccion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Puntos,DNI_Conductor,Matricula_Vehiculo")] InfraccionViewModel infracciones)
        {
            object Error;
            if (ModelState.IsValid)
            {
                try
                {
                    var Vehiculo = await _context.Vehiculos.FindAsync(infracciones.Matricula_Vehiculo);
                    var Conductor = await _context.Conductores.FindAsync(Vehiculo.DNI_Conductor);

                    infracciones.DNI_Conductor = Conductor.DNI;
                    infracciones.Fecha = DateTime.Today;
                    infracciones.Hora = DateTime.Now.ToShortTimeString();
                    _context.Add(infracciones.ToEntity());
                    await _context.SaveChangesAsync();

                    Conductor.Puntos = (Conductor.Puntos - infracciones.Puntos);
                    _context.Update(Conductor);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Error = new ErrorViewModel
                    {
                        Error = "Error al momento de ingresar la informacion al Sistema.",
                        Message = ex.Message
                    };
                    return View("~/Views/Shared/Error.cshtml", Error);
                }
                
            }
            Error = new ErrorViewModel
            {
                Error = "Error al momento de ingresar la información al Sistema.",
                Message = "Verificar la información ingresada"
            };

            return View("~/Views/Shared/Error.cshtml", Error);
        }
    }
}
