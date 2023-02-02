using UnitOfWork.Data.Base;

namespace UnitOfWork.Models
{
    public class Products : IEntityBase
    {
        
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public string? ImageA { get; set; }
        public string? ImageB { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string slug => Title.Replace(' ', '-').ToLower();

    }
}
