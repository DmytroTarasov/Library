namespace Application.DTOs
{
    public class RatingDTO<TKey>
    {
        public TKey Id { get; set; }
        public int Score { get; set; }
    }
}