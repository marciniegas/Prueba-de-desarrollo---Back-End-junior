﻿namespace Bovinos.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public decimal Precio { get; set; }
        public string Estado { get; set; }
        public string Comentarios { get; set; }

        // Relación con Raza
        public int RazaId { get; set; }
        public virtual Race Raza { get; set; }
    }
}
