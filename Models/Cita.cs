namespace Citas_app.Models
{
    public class Cita
    {

        public int Id { get; set; }

        public string PacienteId { get; set; }

        public int MedicoId { get; set; }

        public int Fecha { get; set; }

        public int Hora { get; set; }

        public int Motivo { get; set; }

        public int Estado { get; set; } 



    }
}
