using System.ComponentModel.DataAnnotations;

namespace UnitOfWork.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Products products { get; set; }
        public int Amount { get; set; }
        public int Qty { get; set; }
        public string ShoppingCartId { get; set; }
        public string? options1 { get; set; }
        public string? options2 { get; set; }
        public string? options3 { get; set; }
        public string? options4 { get; set; }
        public string? options5 { get; set; }
        public string? options6 { get; set; }

    }
}
