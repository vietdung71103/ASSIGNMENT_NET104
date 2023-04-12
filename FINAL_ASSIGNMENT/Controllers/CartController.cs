using FINAL_ASSIGNMENT.Models;
using FINAL_ASSIGNMENT.Service.Context;
using FINAL_ASSIGNMENT.Service.Implement;
using FINAL_ASSIGNMENT.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace FINAL_ASSIGNMENT.Controllers
{
    public class CartController : Controller
    {
        IProductService _product;
        ICartDetailService _cartDt;
        ICartService _cart;
        WebContext _db;
        
        public CartController()
        {
            _product = new ProductService();
            _cartDt = new CartDetailService();
            _cart = new CartService();
            _db = new WebContext();
            
        }
        public IActionResult Index(Guid UserId)
        {

            //var cart = _context.Cart.Include(c => c.CartDetails).
            //    ThenInclude(cd => cd.Product).FirstOrDefault(c => c.IdUser == idUser);
            /* Guid cart = _cart.GetListCart().FirstOrDefault(c=>c.UserId == UserId).UserId*/
            List<CartDetail> list = _cartDt.GetListCartDetail().Where(c => c.UserId == UserId).ToList();
                ViewBag.ListCartDetail = list;
                ViewBag.ListProduct = _product.GetListProducts();
                return View();
        }

        public IActionResult AddToCart(Guid IDProduct,Guid UserId)
        {
            TempData["AlertMessage"] = "Đã thêm sản phẩm vào giỏ hàng";
            TempData["AlertType"] = "alert-success"; // or "alert-danger" for example
            var check = _product.GetListProducts().Where(c => c.Id == IDProduct).FirstOrDefault().AvailableQuantity;
            if(check==1)
            {
                TempData["AlertQuantity"] = "Sản phẩm đã hết hàng, sản phẩm cuối cùng để trưng bày không thể bán !";
                TempData["AlertType"] = "alert-warning";
            }
            Cart cart = _cart.GetListCart().FirstOrDefault(c => c.UserId == UserId);
            if(cart == null)
            {
                cart = new Cart()
                {
                    UserId = UserId,
                    Description = "Test"
                };
                _cart.AddCart(cart);
            }
            //var ac = SessionService.GetUserFromSession(HttpContext.Session, "SaveLogin");
            List<CartDetail> listCart =  _cartDt.GetListCartDetail();
            CartDetail obj = new CartDetail()
            {
                Id = Guid.NewGuid(),
                IdSP = IDProduct,
                UserId = cart.UserId,
                Quantity = 1
            };
            if (_cartDt.GetListCartDetail().Any(c => c.IdSP == IDProduct && c.UserId == UserId))
            {
                obj.Quantity = listCart.FirstOrDefault(c => c.IdSP == IDProduct && c.UserId == UserId).Quantity+1;
                var result = _cartDt.UpdateCartDetail(obj, obj.IdSP,obj.UserId);
                if (result)
                {
                   return RedirectToAction("Index",new{ UserId= UserId });
                }
            }
            else
            {
                var addCart = _cartDt.AddCartDetail(obj);
                if (addCart)
                {
                    return RedirectToAction("Index", new { UserId = UserId });
                }
            }
            return RedirectToAction("Index", "Home");
        }
        //public IActionResult Detail(Guid IdProduct,Guid UserId)
        //{
        //   ViewBag.Detail = 
        //}
        public IActionResult Delete(Guid Id,Guid UserId)
        {
            TempData["AlertMessageDelete"] = "Đã xoá sản phẩm trong giỏ hàng";
            TempData["AlertType"] = "alert-success"; // or "alert-danger" for example
            if (_cartDt.DeleteCartDetail(Id))
            {
                return RedirectToAction("Index", new { UserId = UserId });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
