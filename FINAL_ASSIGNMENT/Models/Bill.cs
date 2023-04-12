namespace FINAL_ASSIGNMENT.Models
{
    public class Bill
    {
        public Guid Id { get; set; }
        //public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserId { get; set; }
        public int Status { get; set; }
        public virtual List<BillDetail> BillDetail { get; set; }
        public virtual User User { get; set; }
    }
}
