using System.Text.Json;
using CitasApp.Models;
using CitasApp.Interfaces;

namespace CitasApp.Infrastructure.Repositories
{
    public class JsonCitaRepository : ICitaRepository
    {
        private readonly string _path;
        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true,
            
            NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
        };

        public JsonCitaRepository()
        {
            _path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "data",
                "citas.json");
        }

        public List<Cita> ObtenerTodos()
        {
            if (!File.Exists(_path)) return new List<Cita>();
            var json = File.ReadAllText(_path);
            var citasJson = JsonSerializer.Deserialize<List<CitaJson>>(json, _options) ?? new List<CitaJson>();
            return citasJson.Select(c => new Cita
            {
                Id = c.Id,
                PacienteId = c.PacienteId,
                MedicoId = c.MedicoId,
                Fecha = DateOnly.Parse(c.Fecha),
                Hora = TimeOnly.Parse(c.Hora),
                Motivo = c.Motivo,
                Estado = c.Estado
            }).ToList();
        }

        public List<Cita> ObtenerPorPaciente(int pacienteId) =>
            ObtenerTodos().Where(c => c.PacienteId == pacienteId).ToList();

        // ────────────────────────────────────────────────────────────────
        // LOS 3 MÉTODOS NUEVOS OBLIGATORIOS POR LA INTERFAZ
        // ────────────────────────────────────────────────────────────────

        public Cita? ObtenerPorId(int id)
        {
            return ObtenerTodos().FirstOrDefault(c => c.Id == id);
        }

        public void Agregar(Cita cita)
        {
            var citas = ObtenerTodos();

            // Autoincrementar el ID si viene en 0
            if (cita.Id == 0)
            {
                cita.Id = citas.Any() ? citas.Max(c => c.Id) + 1 : 1;
            }

            citas.Add(cita);
            GuardarTodos(citas);
        }

        public void ConfirmarCita(int id)
        {
            var citas = ObtenerTodos();
            var cita = citas.FirstOrDefault(c => c.Id == id);

            if (cita != null)
            {
                cita.Estado = "Confirmada";
                GuardarTodos(citas);
            }
        }

        // Método auxiliar para guardar los cambios de vuelta al archivo JSON
        private void GuardarTodos(List<Cita> citas)
        {
            var citasJson = citas.Select(c => new CitaJson
            {
                Id = c.Id,
                PacienteId = c.PacienteId,
                MedicoId = c.MedicoId,
                Fecha = c.Fecha.ToString("yyyy-MM-dd"),
                Hora = c.Hora.ToString("HH:mm"),
                Motivo = c.Motivo,
                Estado = c.Estado
            }).ToList();

            var json = JsonSerializer.Serialize(citasJson, _options);
            File.WriteAllText(_path, json);
        }
    }
}