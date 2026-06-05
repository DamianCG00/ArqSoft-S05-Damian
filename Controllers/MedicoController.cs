using Microsoft.AspNetCore.Mvc;
using Citas_app.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Citas_app.Controllers
{
    public class MedicoController : Controller
    {
        private List<Medico> ObtenerMedicos()
        {
            var ruta = Path.Combine(Directory.GetCurrentDirectory(), "data", "medicos.json");
            if (!System.IO.File.Exists(ruta)) return new List<Medico>();

            var json = System.IO.File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<Medico>>(json) ?? new List<Medico>();
        }

        public IActionResult Index()
        {
            return View(ObtenerMedicos());
        }

        public IActionResult Detalle(int id)
        {
            var medico = ObtenerMedicos().FirstOrDefault(m => m.Id == id);
            if (medico == null) return NotFound();
            return View(medico);
        }
    }
}