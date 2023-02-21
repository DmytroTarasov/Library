namespace Application.DTOs
{
    public class BaseBookDTO<TKey>
    {
        public TKey Id { get; set; } 
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }   
    }
}