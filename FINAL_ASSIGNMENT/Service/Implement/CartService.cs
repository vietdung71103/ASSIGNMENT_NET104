using FINAL_ASSIGNMENT.Service.Context;
using FINAL_ASSIGNMENT.Service.Implement;
using FINAL_ASSIGNMENT.Models;
using FINAL_ASSIGNMENT.Service.Interface;
namespace FINAL_ASSIGNMENT.Service.Implement
{
    public class CartService:ICartService
    {
        WebContext _dbContext;
        List<Cart> _getListCart;
        public CartService()
        {
            _dbContext = new WebContext();
            _getListCart = new List<Cart>();
        }

        public bool AddCart(Cart obj)
        {
            try
            {
                _dbContext.Carts.Add(obj);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteCart(Guid Id)
        {
            try
            {
                var get = _dbContext.Carts.Find(Id);
                _dbContext.Carts.Remove(get);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public List<Cart> GetListCart()
        {
            return _getListCart = _dbContext.Carts.ToList();
        }

        public bool UpdateCart(Cart obj)
        {
            try
            {
                var cart = _dbContext.Carts.Find(obj.UserId);
                cart.Description = obj.Description;
                _dbContext.Carts.Update(cart);
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
