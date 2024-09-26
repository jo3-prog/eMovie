namespace eMovie.Models
{
    public class Transaction
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Amount { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
