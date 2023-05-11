namespace MotoCross.Models
{
    public class Moto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Order Order { get; set; }
    }
}
