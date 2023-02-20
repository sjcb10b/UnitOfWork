using System.ComponentModel.DataAnnotations;
using UnitOfWork.Data.Base;

namespace UnitOfWork.Models
{
    public class OrdersCart : IEntityBase
    {

        [Key]
        public int Id { get; set; }
  
        public string? FirstName { get; set; }
   

        public string? LastName { get; set; }

        public string? Company { get; set; }
  

        public string? Street { get; set;}
   

        public string? City { get; set; }
     

        public string? State { get; set; }
        

        public string? ZipCode { get; set; }
       
        
        public string? Phone { get; set; }

        public string? ccc_name { get; set; }
        public string? ccc_number { get; set; }
        public string? expiration { get; set;}
        public string? cvv { get; set; }



    }
}
