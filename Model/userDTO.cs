using System.ComponentModel.DataAnnotations;

namespace cinema.Model
{
    public class userDTO
    {
        [Key]
        public int id { get; set; }

        public String email { get; set; }

        public String Password { get; set; }
        public string Discriminator { get; set; }
    }
}
