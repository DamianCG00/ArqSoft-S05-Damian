using System.Text.Json;
using CitasApp.Models;
using CitasApp.Interfaces;
using CitasApp.Repositories;

namespace CitasApp.Repositories
{
    public class JsonPacienteRepository : IPacienteRepository
    {
        private readonly string _path;
        private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        public JsonPacienteRepository()
        {
            _path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "data",
                "pacientes.json");
        }

        public List<Paciente> ObtenerTodos()
        {
            if (!File.Exists(_path)) return new();
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Paciente>>(json, _options) ?? new();
        }

        public Paciente? ObtenerPorId(int id) =>
            ObtenerTodos().FirstOrDefault(p => p.Id == id);
    }
}