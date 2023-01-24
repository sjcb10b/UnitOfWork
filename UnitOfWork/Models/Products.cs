using UnitOfWork.Data.Base;

namespace UnitOfWork.Models
{
    public class Products : IEntityBase
    {
        
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
