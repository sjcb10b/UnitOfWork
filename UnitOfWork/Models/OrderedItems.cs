using System.ComponentModel.DataAnnotations;
using UnitOfWork.Data.Base;

namespace UnitOfWork.Models
{
    public class OrderedItems : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public Products products_o { get; set; }
        public int Amount_o { get; set; }
        public int Qty_o { get; set; }
        public string ShoppingCartId_o { get; set; }
        public string? options1_o { get; set; }
        public string? options2_o { get; set; }
        public string? options3_o { get; set; }
        public string? options4_o { get; set; }
        public string? options5_o { get; set; }
        public string? options6_o { get; set; }
    }
}
