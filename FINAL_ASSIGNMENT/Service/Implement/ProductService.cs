using FINAL_ASSIGNMENT.Service.Context;
using FINAL_ASSIGNMENT.Service.Implement;
using FINAL_ASSIGNMENT.Models;
using FINAL_ASSIGNMENT.Service.Interface;
namespace FINAL_ASSIGNMENT.Service.Implement
{
    public class ProductService :IProductService
    {
        public WebContext dbContext;
        public ProductService()
        {
            dbContext = new WebContext();
        }
        public bool AddProduct(Product obj)
        {
            try
            {
                dbContext.Products.Add(obj);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }

        public bool DeleteProduct(Guid Id)
        {
            try
            {
                var get = dbContext.Products.Find(Id);// Chỉ dùng cho thuộc tính là khoá chính
                dbContext.Products.Remove(get);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public List<Product> GetListProducts()
        {
            return dbContext.Products.ToList();
        }

        public Product GetProductByID(Guid Id)
        {
            return dbContext.Products.FirstOrDefault(c => c.Id == Id);
        }

        public List<Product> GetProductByName(string Name)
        {
            return GetListProducts().Where(c => c.Name.Contains(Name)).ToList();
        }

        public bool Quantity(Guid Id, Guid IdSp)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(Product obj)
        {
            try
            {
                var product = dbContext.Products.Find(obj.Id);
                product.Name = obj.Name;
                product.Supplier = obj.Supplier;
                product.AvailableQuantity = obj.AvailableQuantity;
                product.Price = obj.Price;
                product.Description = obj.Description;
                product.UrlImage = obj.UrlImage;
                dbContext.Update(product);
                dbContext.SaveChanges();
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
