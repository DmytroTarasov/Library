namespace Application.Books
{
    public class BookDTO<TKey>
    {
        public TKey Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Rating { get; set; }
        public int ReviewsNumber { get; set; }
    }
}