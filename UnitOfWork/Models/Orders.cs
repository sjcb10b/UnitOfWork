using System.ComponentModel.DataAnnotations;
using UnitOfWork.Data.Base;

namespace UnitOfWork.Models
{
    public class Orders : IEntityBase
    {

        [Key]
        public int Id { get; set; }
        public string? FirstName_o { get; set; }
        public string? LastName_o { get; set; }
        public string? Company_o { get; set; }
        public string? Street_o { get; set; }
        public string? City_o { get; set; }
        public string? State_o { get; set; }
        public string? ZipCode_o { get; set; }
        public string? Phone_o { get; set; }
        public string? ccc_name_o { get; set; }
        public string? ccc_number_o { get; set; }
        public string? expiration_o { get; set; }
        public string? cvv_o { get; set; }
        public string ShoppingCartIdCustomer_o { get; set; }

    }




}
