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
    public class VehiculoController : Controller
    {
        private readonly InnovationContext _context;

        public VehiculoController(InnovationContext context)
        {
            _context = context;
        }

        // GET: Vehiculo
        public async Task<IActionResult> Index()
        {
            var List = await _context.Vehiculos
                .Include(v => v.Conductor)
                .Select(x=> new VehiculoViewModel { 
                    Matricula = x.Matricula,
                    Marca = x.Marca,
                    Modelo = x.Modelo,
                    ConductorNombre = x.Conductor.Nombre + " " + x.Conductor.Apellidos
                }).ToListAsync();
            return View(List);
        }

        // GET: Vehiculo/Details/5
        public async Task<IActionResult> Details(string id)
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

            var vehiculo = await _context.Vehiculos
                .Include(v => v.Conductor)
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (vehiculo == null)
            {
                Error = new ErrorViewModel
                {
                    Error = "Error al ontener la información en el Sistema.",
                    Message = "Verificar la información ingresada"
                };

                return View("~/Views/Shared/Error.cshtml", Error);
            }

            return View(vehiculo);
        }

        // GET: Vehiculo/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Conductor = await _context.Conductores.ToListAsync();
            return View();
        }

        // POST: Vehiculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matricula,Marca,Modelo,DNI_Conductor")] Vehiculo vehiculo)
        {
            object Error;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(vehiculo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }catch(Exception ex)
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

        // GET: Vehiculo/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            object Error;
            if (id == null)
            {
                Error = new ErrorViewModel
                {
                    Error = "Error al momento de localizar la información en el Sistema.",
                    Message = "No se encuentra el registro."
                };

                return View("~/Views/Shared/Error.cshtml", Error);
            }

            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                Error = new ErrorViewModel
                {
                    Error = "Error al momento de localizar la información en el Sistema.",
                    Message = "No se encuentra el registro."
                };

                return View("~/Views/Shared/Error.cshtml", Error);
            }
            ViewBag.Conductor = _context.Conductores.ToList();

            return View(vehiculo);
        }

        // POST: Vehiculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Matricula,Marca,Modelo,DNI_Conductor")] Vehiculo vehiculo)
        {
            object Error;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Error = new ErrorViewModel
                    {
                        Error = "Error al momento de modificar la información en el Sistema.",
                        Message = ex.Message
                    };

                    return View("~/Views/Shared/Error.cshtml", Error);
                }
                return RedirectToAction(nameof(Index));
            }
            Error = new ErrorViewModel
            {
                Error = "Error al momento de ingresar la información al Sistema.",
                Message = "Verificar la información ingresada"
            };

            return View("~/Views/Shared/Error.cshtml", Error);
        }

        // GET: Vehiculo/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            object Error;
            if (id == null)
            {
                Error = new ErrorViewModel
                {
                    Error = "Error al momento de localizar la información en el Sistema.",
                    Message = "No se encuentra el registro."
                };

                return View("~/Views/Shared/Error.cshtml", Error);
            }

            var vehiculo = await _context.Vehiculos
                .Include(v => v.Conductor)
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (vehiculo == null)
            {
                Error = new ErrorViewModel
                {
                    Error = "Error al momento de localizar la información en el Sistema.",
                    Message = "No se encuentra el registro."
                };

                return View("~/Views/Shared/Error.cshtml", Error);
            }

            return View(vehiculo);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoExists(string id)
        {
            return _context.Vehiculos.Any(e => e.Matricula == id);
        }
    }
}
