namespace Domain.Models
{
    public class CardUser : BaseEntity
    {    
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
