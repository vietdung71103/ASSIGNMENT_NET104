namespace FINAL_ASSIGNMENT.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int AvailableQuantity { get; set; }
        public int Status { get; set; }
        //public Guid IdCategory { get; set; }
        public string Description { get; set; }
        public string Supplier { get; set; }
        public string UrlImage { get; set; }
        //public Guid IdSupplier { get; set; }
        public virtual List<BillDetail> BillDetail { get; set; }
        public virtual List<CartDetail> CartDetail { get; set; }
        //public virtual Category? Category { get; set; }
        //public virtual Supplier? Supplier { get; set; }
    }
}
