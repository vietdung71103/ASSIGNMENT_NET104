using FINAL_ASSIGNMENT.Models;

namespace FINAL_ASSIGNMENT.Service.Interface
{
	public interface ICartService
	{
        public bool AddCart(Cart obj);
        public bool DeleteCart(Guid Id);
        public List<Cart> GetListCart();
        public bool UpdateCart(Cart obj);
    }
}
