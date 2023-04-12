using FINAL_ASSIGNMENT.Service.Context;
using FINAL_ASSIGNMENT.Service.Implement;
using FINAL_ASSIGNMENT.Models;
using FINAL_ASSIGNMENT.Service.Interface;

namespace FINAL_ASSIGNMENT.Service.Implement
{
    public class BillDetailService:IBillDetailService
    {
        WebContext _dbContext;
        public BillDetailService()
        {
            _dbContext = new WebContext();
        }

        public bool AddBillDetail(BillDetail obj)
        {
            try
            {
                _dbContext.BillDetails.Add(obj);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public List<BillDetail> GetAllBillForUser(Guid IdBill)
        {
            return _dbContext.BillDetails.Where(c=>c.IdHD == IdBill).ToList();
        }
        public bool DeleteBillDetail(Guid Id)
        {
            try
            {
                var get = _dbContext.BillDetails.Find(Id);
                _dbContext.BillDetails.Remove(get);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }


        }

        public BillDetail GetBillDetailByID(Guid Id)
        {
            return _dbContext.BillDetails.FirstOrDefault(c => c.Id == Id);
        }

        public List<BillDetail> GetBillDetailByName(string Name)
        {
            throw new NotImplementedException();
        }

        //public List<BillDetails> GetBillDetailByName(string Name)
        //{

        //}

        public List<BillDetail> GetListBillDetail()
        {
            return _dbContext.BillDetails.ToList();
        }

        public bool UpdateBillDetail(BillDetail obj)
        {
            try
            {
                var billdt = _dbContext.BillDetails.Find(obj.Id);
                billdt.Quantity = obj.Quantity;
                _dbContext.BillDetails.Update(billdt);
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
