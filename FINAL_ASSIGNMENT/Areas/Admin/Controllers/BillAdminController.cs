using FINAL_ASSIGNMENT.Service.Implement;
using FINAL_ASSIGNMENT.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace FINAL_ASSIGNMENT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BillAdminController : Controller
    {
        IBillService _bill;
        IUserService _user;
        public BillAdminController()
        {
            _bill = new BillService();
            _user = new UserService();
        }
        public IActionResult Index()
        {
            ViewBag.ListUser = _user.GetListUser();
            ViewBag.ListBill = _bill.GetListBill();
            return View();
        }
    }
}
