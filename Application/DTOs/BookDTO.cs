namespace Application.DTOs
{
    public class BookDTO<TKey>
    {
        public TKey Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Rating { get; set; }
        public decimal ReviewsNumber { get; set; }
    }
}