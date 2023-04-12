namespace FINAL_ASSIGNMENT.Models
{
    public class Cart
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CartDetail> CartDetail { get; set; }
    }
}
