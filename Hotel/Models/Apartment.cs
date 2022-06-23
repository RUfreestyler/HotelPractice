using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Apartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public bool IsEmpty { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public decimal PricePerDay { get; set; }     
    }
}
