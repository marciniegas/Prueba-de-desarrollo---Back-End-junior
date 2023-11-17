using System.Text.Json.Serialization;
namespace Bovinos.Models
{
    public class Race
    {
        public int Id { get; private set; }
        public string Nombre { get; set; }

        [JsonIgnore]
        public virtual List<Animal> Animales { get; set; } = new List<Animal>();
    }
}
