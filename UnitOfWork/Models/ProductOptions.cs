using System.ComponentModel.DataAnnotations;
using UnitOfWork.Data.Base;

namespace UnitOfWork.Models
{
    public class ProductOptions : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string? option11 { get; set; }
        public string? option22 { get; set; }
        public string? option33 { get; set; }
        public string? option44 { get; set; }
        public string? option55 { get; set; }
        public string? option66 { get; set; }

    }
}
