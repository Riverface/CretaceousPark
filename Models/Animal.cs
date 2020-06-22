using System.ComponentModel.DataAnnotations;

namespace CretaceousPark.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]  
        public string Species { get; set; }
        [Required]
        [Range(0, 200, ErrorMessage = "It's either dead or unborn")]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}