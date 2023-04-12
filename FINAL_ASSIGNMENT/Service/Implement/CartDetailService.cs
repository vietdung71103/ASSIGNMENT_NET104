using FINAL_ASSIGNMENT.Service.Context;
using FINAL_ASSIGNMENT.Service.Implement;
using FINAL_ASSIGNMENT.Models;
using FINAL_ASSIGNMENT.Service.Interface;
namespace FINAL_ASSIGNMENT.Service.Implement
{
    public class CartDetailService :ICartDetailService
    {
        WebContext _dbContext;
        public CartDetailService()
        {
            _dbContext = new WebContext();
        }

        public bool AddCartDetail(CartDetail obj)
        {
            try
            {
                _dbContext.CartDetails.Add(obj);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteCartDetail(Guid Id)
        {

            try
            {
                var get = _dbContext.CartDetails.Find(Id);
                _dbContext.CartDetails.Remove(get);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteCartDetailToBill(Guid UserId, Guid ProductId)
        {
            try
            {
                var get = _dbContext.CartDetails.Where(c=>c.IdSP==ProductId && c.UserId == UserId).FirstOrDefault();
                _dbContext.CartDetails.Remove(get);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public CartDetail GetCartDetailByID(Guid Id)
        {
            return _dbContext.CartDetails.FirstOrDefault(c => c.Id == Id);
        }

        //public List<CartDetail> GetCartDetailByName(string Name)
        //{

        //}

        public List<CartDetail> GetListCartDetail()
        {
            return _dbContext.CartDetails.ToList();
        }

        public bool UpdateCartDetail(CartDetail obj, Guid IdSP,Guid IdUser)
        {
            try
            {
                
                var get = _dbContext.CartDetails.ToList();
                var getUp = get.FirstOrDefault(c => c.IdSP == IdSP && c.UserId == IdUser);
                getUp.Quantity = obj.Quantity;
                _dbContext.CartDetails.Update(getUp);
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
