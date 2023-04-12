using FINAL_ASSIGNMENT.Models;
using FINAL_ASSIGNMENT.Service.Context;
using FINAL_ASSIGNMENT.Service.Implement;
using FINAL_ASSIGNMENT.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FINAL_ASSIGNMENT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductAdminController : Controller
	{
		WebContext _db;
		IProductService _pr;
        public ProductAdminController()
		{
			_db = new WebContext();
			_pr = new ProductService();
		}
		public IActionResult Index()
		{
			ViewBag.ListProduct = _db.Products.ToList();
			return View();
		}
		public IActionResult Create()
		{
			return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if(_pr.AddProduct(obj))
            {
				return RedirectToAction("Index", "ProductAdmin");

			}
			else
			{
                return BadRequest();

            }
        }
        public IActionResult Edit(Guid Id)
		{

            return View(_pr.GetProductByID(Id));
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
            {
            if (_pr.UpdateProduct(obj))
            {
                return RedirectToAction("Index", "ProductAdmin");

            }
            else
            {
                return BadRequest();

            }
        }
        public IActionResult Detail(Guid ID)
		{
            var get = _pr.GetProductByID(ID);
            return View(get);
        }
		public IActionResult Delete(Guid ID)
        {
            var get = _db.Products.ToList().FirstOrDefault(c => c.Id == ID);
			_db.Remove(get);
			_db.SaveChanges();
			return View("Index");
        }

    }
}
