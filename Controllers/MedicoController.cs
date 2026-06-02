using Microsoft.AspNetCore.Mvc;
using Citas_app.Models;
using System.Collections.Generic;
using System.Linq;

namespace Citas_app.Controllers
{
    public class MedicoController : Controller
    {
        // Datos simulados adaptados a tus tipos de datos actuales
        private static List<Medico> medicos = new List<Medico>
        {
            new Medico { Id = 1, Nombre = "Roberto", Apellido = 1, Especialidad = 1, NumeroLicencia = 8492 },
            new Medico { Id = 2, Nombre = "Elena", Apellido = 2, Especialidad = 2, NumeroLicencia = 1034 }
        };

        public IActionResult Index()
        {
            return View(medicos);
        }

        public IActionResult Detalle(int id)
        {
            var medico = medicos.FirstOrDefault(m => m.Id == id);

            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }
    }
}