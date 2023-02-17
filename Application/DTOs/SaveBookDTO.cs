using Microsoft.AspNetCore.Http;

namespace Application.DTOs
{
    public class SaveBookDTO<TKey>
    {
        public TKey Id { get; set; }    
        public string Title { get; set; }
        public IFormFile Cover { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}