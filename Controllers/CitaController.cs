using Microsoft.AspNetCore.Mvc;
using Citas_app.Models;
using System.Collections.Generic;
using System.Linq;

namespace Citas_app.Controllers
{
    public class CitaController : Controller
    {
        
        private static List<Cita> citas = new List<Cita>
        {
            
            new Cita { Id = 1, PacienteId = "1", MedicoId = 1, Fecha = 20260615, Hora = 1030, Motivo = 1, Estado = 1 },
            new Cita { Id = 2, PacienteId = "1", MedicoId = 2, Fecha = 20260620, Hora = 1200, Motivo = 2, Estado = 1 },
            new Cita { Id = 3, PacienteId = "2", MedicoId = 1, Fecha = 20260618, Hora = 1645, Motivo = 3, Estado = 2 }
        };

        public IActionResult Index()
        {
            return View(citas);
        }

        
        public IActionResult PorPaciente(string pacienteId)
        {
            var citasDelPaciente = citas.Where(c => c.PacienteId == pacienteId).ToList();

            return View(citasDelPaciente);
        }
    }
}