using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitOfWork.Models
{
    public class Items
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public int Qty { get; set; }
        public string? ImageA { get; set; }
        [NotMapped]
        public IFormFile? photo { get; set; }
        public string? ImageB { get; set; }
        [NotMapped]
        public IFormFile? photob { get; set; }

       
    }
}
