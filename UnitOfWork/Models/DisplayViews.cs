namespace UnitOfWork.Models
{
    public class DisplayViews
    {
        internal readonly object filteredCategory;

        public List<Products>  Products { get; set; }
        public List<Category> categories { get; set; }

        public Products Productview { get; set; }


    }
}
