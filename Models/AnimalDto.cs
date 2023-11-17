namespace Bovinos.Models
{
    public class AnimalDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public decimal Precio { get; set; }
        public string Estado { get; set; }
        public string Comentarios { get; set; }
        public int RazaId { get; set; }
        public string RazaNombre { get; set; }
    }
}
