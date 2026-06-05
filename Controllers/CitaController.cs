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
        // 1. Método para LEER el JSON
        private List<T> LeerDatos<T>(string nombreArchivo)
        {
            var ruta = Path.Combine(Directory.GetCurrentDirectory(), "data", nombreArchivo);
            if (!System.IO.File.Exists(ruta)) return new List<T>();
            var json = System.IO.File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        // 2. Método para GUARDAR en el JSON
        private void GuardarDatos<T>(string nombreArchivo, List<T> datos)
        {
            var ruta = Path.Combine(Directory.GetCurrentDirectory(), "data", nombreArchivo);
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(datos, opciones);
            System.IO.File.WriteAllText(ruta, json);
        }

        // 3. Método auxiliar para traducir IDs a Nombres en la tabla
        private void CargarNombresEnViewBag()
        {
            var pacientes = LeerDatos<Paciente>("pacientes.json");
            var medicos = LeerDatos<Medico>("medicos.json");

            ViewBag.NombresPacientes = pacientes.ToDictionary(p => p.Id.ToString(), p => p.Nombre + " " + p.Apellido);
            ViewBag.NombresMedicos = medicos.ToDictionary(m => m.Id, m => m.Nombre + " " + m.Apellido);
        }

        // --- VISTAS Y ACCIONES ---

        // Mostrar la tabla principal de citas
        public IActionResult Index()
        {
            CargarNombresEnViewBag();
            var citas = LeerDatos<Cita>("citas.json");
            return View(citas);
        }

        // Mostrar citas filtradas por un paciente
        public IActionResult PorPaciente(int pacienteId)
        {
            CargarNombresEnViewBag();
            var citasDelPaciente = LeerDatos<Cita>("citas.json").Where(c => c.PacienteId == pacienteId.ToString()).ToList();
            return View(citasDelPaciente);
        }

        // Mostrar el formulario en blanco para una nueva cita
        public IActionResult Crear()
        {
            ViewBag.Pacientes = LeerDatos<Paciente>("pacientes.json");
            ViewBag.Medicos = LeerDatos<Medico>("medicos.json");
            return View();
        }

        // Recibir los datos del formulario y escribirlos en el archivo
        [HttpPost]
        public IActionResult Crear(Cita nuevaCita)
        {
            var citas = LeerDatos<Cita>("citas.json");

            // Generar un nuevo ID automáticamente
            int nuevoId = citas.Any() ? citas.Max(c => c.Id) + 1 : 1;
            nuevaCita.Id = nuevoId;

            // Estado por defecto
            nuevaCita.Estado = "Pendiente";

            // Guardar y redirigir
            citas.Add(nuevaCita);
            GuardarDatos("citas.json", citas);

            return RedirectToAction("Index");
        }
    }
}