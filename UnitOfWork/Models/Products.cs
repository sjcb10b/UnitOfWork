using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using UnitOfWork.Data.Base;

namespace UnitOfWork.Models
{
    public class Products : IEntityBase
    {
        
        
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public int Qty { get; set; }
        public string? ImageA { get; set; }

        [NotMapped]
        public IFormFile? photo { get; set; }

        public string? ImageB { get; set; }
        [DisplayName("Yes/No Display Options(Products)")]
        public int? YesNo { get; set; } = 1;

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string? Option1 { get; set; }
        public string? Option2 { get; set; }
        public string? Option3 { get; set; }
        public string? Option4 { get; set; }
        public string? Option5 { get; set; }
        public string? Option6 { get; set; }
    }
}
