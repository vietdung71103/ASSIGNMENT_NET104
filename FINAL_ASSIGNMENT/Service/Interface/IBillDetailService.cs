using FINAL_ASSIGNMENT.Models;

namespace FINAL_ASSIGNMENT.Service.Interface
{
    public interface IBillDetailService
    {
        public bool AddBillDetail(BillDetail obj);
        public bool UpdateBillDetail(BillDetail obj);
        public bool DeleteBillDetail(Guid Id);
        public List<BillDetail> GetListBillDetail();
        //public BillDetails GetBillDetailByID(Guid Id);
        public List<BillDetail> GetBillDetailByName(string Name);
    }
}
