namespace Domain
{
    public class Rating : BaseEntity<Guid>
    {
        public decimal Score { get; set; }
        public Book Book { get; set; }
    }
}