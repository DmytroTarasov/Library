namespace Domain
{
    public class Review : BaseEntity<Guid>
    {
        public string Message { get; set; }
        public Book Book { get; set; }
        public string Reviewer { get; set; }
    }
}