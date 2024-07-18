using System.ComponentModel.DataAnnotations;

namespace cinema.Model
{
    public class ReservationDTO
    {
        [Key]
        public int idRéservation { get; set; }

      
        public Client ?clientres { get; set; } 
        public int clientID { get; set; } 

        public Planification? planification { get; set; } 
        public int planificationID { get; set; }

        

    }
}
