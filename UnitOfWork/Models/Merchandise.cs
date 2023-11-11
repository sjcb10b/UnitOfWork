namespace UnitOfWork.Models
{
    public class Merchandise
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public int Qty { get; set; }
        public string? ImageA { get; set; }
    }
}
