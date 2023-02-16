namespace Domain
{
    public class Review : BaseEntity<int>
    {
        public string Message { get; set; }
        public Book Book { get; set; }
        public string Reviewer { get; set; }
    }
}