using FINAL_ASSIGNMENT.Models;
using FINAL_ASSIGNMENT.Service.Implement;
using FINAL_ASSIGNMENT.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FINAL_ASSIGNMENT.Controllers
{
    public class BillController : Controller
    {
        IProductService _pr;
        IUserService _user;
        IBillDetailService _billdt;
        IBillService _bill;
        ICartService _cart;
        ICartDetailService _cartdt;
        public BillController()
        {
            _pr = new ProductService();
            _user = new UserService();
            _bill = new BillService();
            _billdt = new BillDetailService();
            _cart = new CartService();
            _cartdt = new CartDetailService();
        }
        public IActionResult Index(Guid UserId)
        {
            ViewBag.ListBill = _bill.GetListBill().Where(c => c.UserId == UserId && c.Status!=1).ToList();
            ViewBag.ListProduct = _pr.GetListProducts();
            return View();
        }
        public IActionResult Detail(Guid IdBill)
        {
            Bill bill = _bill.GetBillByID(IdBill);
            ViewBag.ListBill = bill;

            var listBillDetail = _billdt.GetListBillDetail().Where(c => c.IdHD == bill.Id).ToList();
            ViewBag.ListBillDetail = listBillDetail;

            var pr = _pr.GetListProducts().Where(c => listBillDetail.Any(g => g.IdSP == c.Id)).ToList();
            ViewBag.ListProduct = pr;
            return View();
        }
        public IActionResult MuaHang(Guid UserId)
        {
            //public Guid Id { get; set; }
            //public DateTime CreateDate { get; set; }
            //public Guid UserId { get; set; }
            //public int Status { get; set; }
            List<CartDetail> listCartDT = _cartdt.GetListCartDetail().Where(c => c.UserId == _cart.GetListCart().FirstOrDefault(c => c.UserId == UserId).UserId).ToList();

            if(listCartDT.Count == 0)
            {
                TempData["AlertFailCreate"] = "Chưa có sản phẩm trong giỏ hàng chưa thể tạo hoá đơn";
                TempData["AlertType"] = "alert-warning"; // or "alert-danger" for example
                //return View("Index", "Cart");
                return RedirectToAction("Index", "Cart");
            }
                Bill bill = new Bill()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    UserId = UserId,
                    Status = 3
                };
           
                var creatBill = _bill.AddBill(bill);
                var createBillDetail = false;

                int count = 0;
                if (creatBill)
                {
                    foreach (var x in listCartDT)
                    {
                        //public Guid Id { get; set; }
                        //public Guid IdHD { get; set; }
                        //public Guid IdSP { get; set; }
                        //public int Quantity { get; set; }
                        //public int Price { get; set; }
                        BillDetail _billDetail = new BillDetail()
                        {
                            Id = Guid.NewGuid(),
                            IdHD = bill.Id,
                            IdSP = x.IdSP,
                            Quantity = x.Quantity,
                            Price = _pr.GetListProducts().FirstOrDefault(c => c.Id == x.IdSP).Price * x.Quantity
                        };
                        createBillDetail = _billdt.AddBillDetail(_billDetail);
                        if (!createBillDetail)
                        {
                            count++;
                        }

                    }

                    foreach (var x in listCartDT)
                    {
                        _cartdt.DeleteCartDetailToBill(x.UserId, x.IdSP);
                    //foreach (Product c in _pr.GetListProducts().Where(c => c.Id == x.IdSP))
                    //{
                    //    c.AvailableQuantity = c.AvailableQuantity - x.Quantity;
                    //    var update = _pr.UpdateProduct(c);
                    //}
                }
                    if (count == 0)
                    {
                        return RedirectToAction("Detail", new { IdBill = bill.Id });
                    }
                }
                

                
          
               
            return RedirectToAction("Index", new { UserId = UserId });
        }
        public IActionResult ThanhToan(Guid UserId, Guid IdBill)
        {
            //public int Status { get; set; }
            //List<CartDetail> listCartDT = _cartdt.GetListCartDetail().Where(c => c.UserId == _cart.GetListCart().FirstOrDefault(c => c.UserId == UserId).UserId).ToList();
            //foreach (var x in listCartDT)
            //{
            //    //_cartdt.DeleteCartDetailToBill(x.UserId, x.IdSP);

            //}
            TempData["AlertSuccessBuy"] = "Đã thanh toán thành công";
            TempData["AlertType"] = "alert-success"; // or "alert-danger" for example
            List<BillDetail> listBillDt = _billdt.GetListBillDetail().Where(c => c.IdHD == IdBill).ToList();
            Bill bill = _bill.GetBillByID(IdBill);
            bill.Status = 0;
            var huy = _bill.UpdateBill(bill);
            if (huy)
            {
                foreach (var x in listBillDt)
                {
                    //_cartdt.DeleteCartDetailToBill(x.UserId, x.IdSP);
                    foreach (Product c in _pr.GetListProducts().Where(c => c.Id == x.IdSP))
                    {
                        c.AvailableQuantity = c.AvailableQuantity - x.Quantity;//Thanh toán rồi mới trừ sản phẩm trong số lượng tồn
                        var update = _pr.UpdateProduct(c);
                    }
                }
                return RedirectToAction("Index", "Bill", new { UserId = UserId });
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult HuyHoaDon(Guid IdBill,Guid UserId)
        {
            //List<CartDetail> listCartDT = _cartdt.GetListCartDetail().Where(c => c.UserId == _cart.GetListCart().FirstOrDefault(c => c.UserId == UserId).UserId).ToList();
            TempData["AlertFailBuy"] = "Đã huỷ hoá đơn";
            TempData["AlertType"] = "alert-success"; // or "alert-danger" for example
            Bill bill = _bill.GetBillByID(IdBill);
            bill.Status = 1;
            var huy = _bill.UpdateBill(bill);
            if(huy)
            {
                
                return RedirectToAction("Index","Bill",new { UserId = UserId});
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult BillDaHuy(Guid UserId)
        {
            ViewBag.ListBill = _bill.GetListBill().Where(c => c.UserId == UserId && c.Status == 1).ToList();
            ViewBag.ListProduct = _pr.GetListProducts();
            return View();
        }
    }
}