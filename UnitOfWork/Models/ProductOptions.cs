using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UnitOfWork.Data.Base;

namespace UnitOfWork.Models
{
    public class ProductOptions : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Option 1")]
        public string? option11 { get; set; }
        [DisplayName("Option 2")]
        public string? option22 { get; set; }
        [DisplayName("Option 3")]
        public string? option33 { get; set; }
        [DisplayName("Option 4")]
        public string? option44 { get; set; }
        [DisplayName("Option 5")]
        public string? option55 { get; set; }
        [DisplayName("Option 6")]
        public string? option66 { get; set; }

    }
}
