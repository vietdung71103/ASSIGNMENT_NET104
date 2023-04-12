using FINAL_ASSIGNMENT.Service.Context;
using FINAL_ASSIGNMENT.Service.Implement;
using FINAL_ASSIGNMENT.Models;
using FINAL_ASSIGNMENT.Service.Interface;
namespace FINAL_ASSIGNMENT.Service.Implement
{
    public class BillService:IBillService
    {
        WebContext _dbContext;
        public BillService()
        {
            _dbContext = new WebContext();
        }

        public bool AddBill(Bill obj)
        {
            try
            {
                _dbContext.Bills.Add(obj);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteBill(Guid Id)
        {
            try
            {
                var get = _dbContext.Bills.Find(Id);
                _dbContext.Bills.Remove(get);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public Bill GetBillByID(Guid Id)
        {
            return _dbContext.Bills.FirstOrDefault(c => c.Id == Id);
        }

        //public List<Bill> GetBillByName(string Name)
        //{

        //}

        public List<Bill> GetListBill()
        {
            return _dbContext.Bills.ToList();
        }
        
        public bool UpdateBill(Bill obj)
        {
            try
            {
                var bill = _dbContext.Bills.Find(obj.Id);
                bill.Status = obj.Status;
                _dbContext.Bills.Update(bill);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
    }
}
