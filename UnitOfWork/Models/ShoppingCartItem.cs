using System.ComponentModel.DataAnnotations;

namespace UnitOfWork.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Products products { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
