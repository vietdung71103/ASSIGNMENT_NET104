using FINAL_ASSIGNMENT.Models;

namespace FINAL_ASSIGNMENT.Service.Interface
{
    public interface IBillService
    {
        public bool AddBill(Bill obj);
        public bool UpdateBill(Bill obj);
        public bool DeleteBill(Guid Id);
        public List<Bill> GetListBill();
        public Bill GetBillByID(Guid Id);
        //public List<Bill> GetBillByName(string Name);
    }
}
