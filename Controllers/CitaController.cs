using Microsoft.AspNetCore.Mvc;
using Citas_app.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Citas_app.Controllers
{
    public class CitaController : Controller
    {
        private List<T> LeerDatos<T>(string nombreArchivo)
        {
            var ruta = Path.Combine(Directory.GetCurrentDirectory(), "data", nombreArchivo);
            if (!System.IO.File.Exists(ruta)) return new List<T>();
            var json = System.IO.File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        private void CargarNombresEnViewBag()
        {
            var pacientes = LeerDatos<Paciente>("pacientes.json");
            var medicos = LeerDatos<Medico>("medicos.json");

            
            ViewBag.NombresPacientes = pacientes.ToDictionary(p => p.Id.ToString(), p => p.Nombre + " " + p.Apellido);

            
            ViewBag.NombresMedicos = medicos.ToDictionary(m => m.Id, m => m.Nombre + " " + m.Apellido);
        }

        public IActionResult Index()
        {
            CargarNombresEnViewBag();
            var citas = LeerDatos<Cita>("citas.json");
            return View(citas);
        }

        public IActionResult PorPaciente(int pacienteId)
        {
            CargarNombresEnViewBag();
            
            var citasDelPaciente = LeerDatos<Cita>("citas.json").Where(c => c.PacienteId == pacienteId.ToString()).ToList();
            return View(citasDelPaciente);
        }
    }
}