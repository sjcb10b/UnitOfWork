using System.ComponentModel.DataAnnotations;

namespace UnitOfWork.Models
{
    public class ArtLicencingModel
    {
        [Key]
        public int LId { get; set; }
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public string? Description { get; set; }
        public string? Brand { get; set; }
        public string? Images { get; set; }
        public string? OriginalPublisherID { get; set; }
        public double? Cost { get; set; } = 0;
        public double? RetailPrice { get; set; } = 0;
        public double? SalesPrice { get; set; } = 0;

        public string? Warranty { get; set; }
        public string? ProductType { get; set; }
        public string? FrameColor { get; set; }

        public string? Style { get; set; }
        public string? Category { get; set; }
        public string? PhotoOrientation { get; set; }
        public string? Color { get; set; }
        public string? Tags { get; set; }
        public string? SEOTitle { get; set; }
        public string? SEoKeywords { get; set; }
        public string? MetaDescription { get; set; }
      
      
    

    }
}
