using FINAL_ASSIGNMENT.Models;

namespace FINAL_ASSIGNMENT.Service.Interface
{
    public interface IProductService
    {
        public bool AddProduct(Product obj);
        public bool UpdateProduct(Product obj);
        public bool DeleteProduct(Guid Id);
        public bool Quantity(Guid Id,Guid IdSp);
        public List<Product> GetListProducts();

        public Product GetProductByID(Guid Id);
        public List<Product> GetProductByName(string Name);
    }
}
