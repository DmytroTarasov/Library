namespace Application.DTOs
{
    public class BookDTO<TKey> : BaseBookDTO<TKey>
    {
        public decimal Rating { get; set; }
        public decimal ReviewsNumber { get; set; }
    }
}