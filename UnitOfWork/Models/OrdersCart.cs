using System.ComponentModel.DataAnnotations;

namespace UnitOfWork.Models
{
    public class OrdersCart
    {

        [Key]
        public int OrderId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }

        public string? Company { get; set; }
        [Required]

        public string Street { get; set;}
        [Required]

        public string City { get; set; }
        [Required]

        public string State { get; set; }
        [Required]

        public string ZipCode { get; set; }
        [Required]

        public string Country { get; set; }
        [Required]

        [DisplayFormat(DataFormatString = "{0:###-###-####}")]

        public string Phone { get; set; }


    }
}
