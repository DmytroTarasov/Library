namespace Application.DTOs
{
    public class BookDetailsDTO<TKey> : BaseBookDTO<TKey>
    {
        public decimal Rating { get; set; }
        public ICollection<ReviewDTO<TKey>> Reviews { get; set; }
    }
}