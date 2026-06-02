using Microsoft.AspNetCore.Mvc;
using Citas_app.Models;
using System.Collections.Generic;
using System.Linq;

namespace Citas_app.Controllers
{
    public class CitaController : Controller
    {
        // Datos simulados adaptados a tus tipos de datos actuales
        private static List<Cita> citas = new List<Cita>
        {
            // Fecha y Hora son int en tu modelo, así que usamos un formato numérico simple como 20260615
            new Cita { Id = 1, PacienteId = "1", MedicoId = 1, Fecha = 20260615, Hora = 1030, Motivo = 1, Estado = 1 },
            new Cita { Id = 2, PacienteId = "1", MedicoId = 2, Fecha = 20260620, Hora = 1200, Motivo = 2, Estado = 1 },
            new Cita { Id = 3, PacienteId = "2", MedicoId = 1, Fecha = 20260618, Hora = 1645, Motivo = 3, Estado = 2 }
        };

        public IActionResult Index()
        {
            return View(citas);
        }

        // Se ajusta el parámetro a string porque PacienteId en Cita.cs es un string
        public IActionResult PorPaciente(string pacienteId)
        {
            var citasDelPaciente = citas.Where(c => c.PacienteId == pacienteId).ToList();

            return View(citasDelPaciente);
        }
    }
}