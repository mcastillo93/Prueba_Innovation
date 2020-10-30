using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Prueba_Innovation.Models;

namespace Prueba_Innovation.Controllers
{
    public class HomeController : Controller
    {
        private InnovationContext db = new InnovationContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var Lista = db.
           try{
                //var Conductor = new C()
                //{
                //    DNI = "XDAEED",
                //    Nombre = "Miguel Angel",
                //    Apellidos = "Castillo Cerón",
                //    Puntos = "100"
                //};
                //db.Add(Conductor);
                //db.SaveChanges();
                return View();
            }
            catch (Exception ex)
            {
                var sqlException = ex.InnerException as SqlException;
                if (sqlException.Number == 2601 || sqlException.Number == 2627)
                {
                    return View();
                }
            }

           
            return View();
        }

      
        public IActionResult Infracciones()
        {
            return View();
        }

    }
}
