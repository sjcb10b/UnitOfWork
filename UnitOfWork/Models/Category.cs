using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using UnitOfWork.Data.Base;

namespace UnitOfWork.Models
{
    public class Category : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1. to 100 only!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? ImageCategoryA { get; set; }
        public string slug => Name.Replace(' ', '-').ToLower();
     }
}
