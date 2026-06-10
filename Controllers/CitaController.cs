using Microsoft.AspNetCore.Mvc;
using CitasApp.Interfaces;
using System.Linq;

namespace CitasApp.Controllers
{
    public class CitaController : Controller
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMedicoRepository _medicoRepository;

        public CitaController(ICitaRepository citaRepo, IPacienteRepository pacienteRepo, IMedicoRepository medicoRepo)
        {
            _citaRepository = citaRepo;
            _pacienteRepository = pacienteRepo;
            _medicoRepository = medicoRepo;
        }

        public IActionResult Index()
        {
            var citas = _citaRepository.ObtenerTodos();

            // Diccionarios con llaves estandarizadas en texto (string)
            var nombresPacientes = _pacienteRepository.ObtenerTodos()
                .ToDictionary(p => p.Id.ToString(), p => $"{p.Nombre} {p.Apellido}");

            var nombresMedicos = _medicoRepository.ObtenerTodos()
                .ToDictionary(m => m.Id.ToString(), m => $"Dr(a). {m.Nombre} {m.Apellido}");

            ViewBag.NombresPacientes = nombresPacientes;
            ViewBag.NombresMedicos = nombresMedicos;

            return View(citas);
        }
    }
}