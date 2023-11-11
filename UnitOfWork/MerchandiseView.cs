namespace UnitOfWork
{
    public class MerchandiseView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public int Qty { get; set; }
        public IFormFile? photo { get; set; }
    }
}
