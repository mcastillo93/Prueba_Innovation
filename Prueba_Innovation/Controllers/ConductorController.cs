using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Prueba_Innovation.Models;
using Prueba_Innovation.ViewModels;

namespace Prueba_Innovation.Controllers
{
    public class ConductorController : Controller
    {
        private readonly InnovationContext _context;

        public ConductorController(InnovationContext context)
        {
            _context = context;
        }

        // GET: Conductors
        public async Task<IActionResult> Index()
        {
            var List = await _context.Conductores
                .Select(x => new ConductorViewModel
                {
                    DNI = x.DNI,
                    Nombre = x.Nombre,
                    Apellidos = x.Apellidos,
                    Puntos = x.Puntos
                }).ToListAsync();
            return View(List);
        }

        // GET: Conductors/Details/5
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

            var conductor = await _context.Conductores
                .FirstOrDefaultAsync(m => m.DNI == id);
            if (conductor == null)
            {
                Error = new ErrorViewModel
                {
                    Error = "Error al ontener la información en el Sistema.",
                    Message = "Verificar la información ingresada"
                };
                return View("~/Views/Shared/Error.cshtml", Error);
            }

            return View(conductor);
        }

        // GET: Conductors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conductors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DNI,Nombre,Apellidos,Puntos")] ConductorViewModel conductor)
        {
            object Error;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(conductor.ToEntity());
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    var sqlException = ex.InnerException as SqlException;
                    if (sqlException.Number == 2601 || sqlException.Number == 2627)
                    {
                        Error = new ErrorViewModel { 
                            Error = "Error al momento de ingresar la informacion al Sistema.",
                            Message = "Ya se encuentra un conductor registrado con la DNI " + conductor.DNI
                        };
                        return View("~/Views/Shared/Error.cshtml", Error);
                        
                    }
                }
               
            }
            Error = new ErrorViewModel
            {
                Error = "Error al momento de ingresar la información al Sistema.",
                Message = "Verificar la información ingresada"
            };

            return View("~/Views/Shared/Error.cshtml", Error);
        }

        // GET: Conductors/Edit/5
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

            var conductor = await _context.Conductores.FindAsync(id);
            if (conductor == null)
            {
                Error = new ErrorViewModel
                {
                    Error = "Error al momento de localizar la información en el Sistema.",
                    Message = "No se encuentra el registro."
                };

                return View("~/Views/Shared/Error.cshtml", Error);
            }
            return View(conductor);
        }

        // POST: Conductors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DNI,Nombre,Apellidos,Puntos")] Conductor conductor)
        {
            object Error;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conductor);
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
                
            }
            Error = new ErrorViewModel
            {
                Error = "Error al momento de ingresar la información al Sistema.",
                Message = "Verificar la información ingresada"
            };

            return View("~/Views/Shared/Error.cshtml", Error);
        }

        // GET: Conductors/Delete/5
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

            var conductor = await _context.Conductores
                .FirstOrDefaultAsync(m => m.DNI == id);
            if (conductor == null)
            {
                Error = new ErrorViewModel
                {
                    Error = "Error al momento de localizar la información en el Sistema.",
                    Message = "No se encuentra el registro."
                };

                return View("~/Views/Shared/Error.cshtml", Error);
            }

            return View(conductor);
        }

        // POST: Conductors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var conductor = await _context.Conductores.FindAsync(id);
            _context.Conductores.Remove(conductor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
