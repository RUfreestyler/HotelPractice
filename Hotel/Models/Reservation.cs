using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Дата заезда")]
        public DateTime CheckInDate { get; set; }

        [Required]
        [Display(Name = "Дата выезда")]
        public DateTime CheckOutDate { get; set; }

        [Required]
        [Display(Name = "Номер комнаты")]
        public Apartment LiveApartment { get; set; }

        [Required]
        [Display(Name = "Дата заявки")]
        public DateTime DateOfRequest { get; set; }
    }
}
