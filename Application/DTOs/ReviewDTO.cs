namespace Application.DTOs
{
    public class ReviewDTO<TKey>
    {
        public TKey Id { get; set; }  
        public string Message { get; set; }
        public string Reviewer { get; set; }      
    }
}