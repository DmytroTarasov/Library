namespace Domain
{
    public class Rating : BaseEntity<int>
    {
        public int Score { get; set; }
        public Book Book { get; set; }
    }
}