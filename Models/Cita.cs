namespace Citas_app.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public string PacienteId { get; set; }
        public int MedicoId { get; set; }

        // Convertimos a string para leer el JSON sin problemas
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }
    }
}