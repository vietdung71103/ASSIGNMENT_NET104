using FINAL_ASSIGNMENT.Models;

namespace FINAL_ASSIGNMENT.Service.Interface
{
    public interface ICartDetailService
    {
        public bool AddCartDetail(CartDetail obj);
        public bool UpdateCartDetail(CartDetail obj, Guid IdSP, Guid IdUser);
        public bool DeleteCartDetail(Guid Id);
        public bool DeleteCartDetailToBill(Guid UserId,Guid ProductId);
        public List<CartDetail> GetListCartDetail();
        public CartDetail GetCartDetailByID(Guid Id);
        //public List<CartDetail> GetCartDetailByName(string Name);
    }
}
