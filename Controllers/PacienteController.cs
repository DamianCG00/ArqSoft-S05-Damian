using Microsoft.AspNetCore.Mvc;
using Citas_app.Models;
using System.Collections.Generic;
using System.Linq;

namespace Citas_app.Controllers
{
    public class PacienteController : Controller
    {
        // Datos simulados adaptados a tus tipos de datos actuales (int para Apellido, Email, etc.)
        private static List<Paciente> pacientes = new List<Paciente>
        {
            new Paciente { Id = 1, Nombre = "Ana", Apellido = 1, Email = 1, Telefono = 9991234 },
            new Paciente { Id = 2, Nombre = "Carlos", Apellido = 2, Email = 2, Telefono = 9997654 }
        };

        public IActionResult Index()
        {
            return View(pacientes);
        }

        public IActionResult Detalle(int id)
        {
            var paciente = pacientes.FirstOrDefault(p => p.Id == id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }
    }
}