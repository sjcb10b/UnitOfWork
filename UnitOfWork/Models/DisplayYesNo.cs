using System.ComponentModel.DataAnnotations;

namespace UnitOfWork.Models
{
    public class DisplayYesNo
    {

        [Key]
        public int Iyn { get; set; }
        public int optionsyesno { get; set; }
        public string  yesno { get; set; }



    }
}
