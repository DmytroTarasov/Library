namespace Domain
{
    public class Rating : BaseEntity<int>
    {
        public decimal Score { get; set; }
        public Book Book { get; set; }
    }
}