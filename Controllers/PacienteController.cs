using Microsoft.AspNetCore.Mvc;
using Citas_app.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Citas_app.Controllers
{
    public class PacienteController : Controller
    {
        // Método privado para leer el archivo JSON
        private List<Paciente> ObtenerPacientes()
        {
            var ruta = Path.Combine(Directory.GetCurrentDirectory(), "data", "pacientes.json");
            if (!System.IO.File.Exists(ruta)) return new List<Paciente>();

            var json = System.IO.File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<Paciente>>(json) ?? new List<Paciente>();
        }

        public IActionResult Index()
        {
            return View(ObtenerPacientes());
        }

        public IActionResult Detalle(int id)
        {
            var paciente = ObtenerPacientes().FirstOrDefault(p => p.Id == id);
            if (paciente == null) return NotFound();
            return View(paciente);
        }
    }
}