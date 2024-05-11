using System.ComponentModel.DataAnnotations;

namespace Code9.API.Models
{
    public class AddCinemaRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public int NumOfAuditoriums { get; set; }
    }
}
