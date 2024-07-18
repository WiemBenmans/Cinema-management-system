using System.ComponentModel.DataAnnotations;

namespace cinema.Model
{
    public class salleDTO
    {
        [Key]
        public int id { get; set; }

        public String ? statut { get; set; }

        public int nombrePlaces { get; set; }
        public ICollection<positionDTO>? Positions { get; set; }
    }
}
