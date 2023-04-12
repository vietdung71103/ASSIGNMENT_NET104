using FINAL_ASSIGNMENT.Models;
using FINAL_ASSIGNMENT.Service.Implement;
using FINAL_ASSIGNMENT.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FINAL_ASSIGNMENT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IProductService _servicePr;
        IUserService _serviceUser;
        IRoleService _serviceRole;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _serviceRole = new RoleService();
            _servicePr = new ProductService();
            _serviceUser = new UserService();
           
        }
       
        public IActionResult Index()
        {
            ViewBag.User = SessionService.GetUserFromSession(HttpContext.Session, "SaveLogin");
            List<Product> list = _servicePr.GetListProducts().Where(c => c.Status == 0 && c.AvailableQuantity > 1).ToList();
            //List<Product> listFind = _servicePr.GetListProducts();
            ViewBag.ListProduct = list;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Details(Guid Id)
        {
            var get = _servicePr.GetProductByID(Id);
            
            return View(get);
        }
        //[HttpGet]
        public IActionResult Register()
        {
            //var roles = _serviceRole.GetListRole();
            //var roleList = roles.Select(c => new SelectListItem
            //{
            //    Text = c.RoleName,
            //    Value = c.RoleId.ToString()

            //});
            //var viewModel = new User
            //{
            //    RoleListItems = roleList
            //};
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            user.Status = 1;
            user.Avatar = "";
            user.RoleId = Guid.Parse("54b764a4-9b78-4fec-9013-7fbc36b4124a");
           
            if (_serviceUser.GetListUser().Any(c=>c.Username == user.Username) == true)
            {
                ModelState.AddModelError("", "Username already exists.");
                return View("Register");
            }
            else
            {
                if (_serviceUser.AddUser(user))
                {

                    return RedirectToAction("Login");
                }
                else
                {
                    return BadRequest();
                }
            }
            
            
            
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var username = user.Username;
            var password = user.Password;
            var checkLogin = _serviceUser.GetListUser().SingleOrDefault(c => c.Username.Equals(username) && c.Password.Equals(password));
            var id = Guid.Parse("d3fc2e5b-64d4-4e65-9f54-aa0566bfe1b7");
            var checkAdmin = _serviceUser.GetListUser().SingleOrDefault(c => c.Username.Equals(username) && c.Password.Equals(password) && c.RoleId == id);
            //var ac = SessionService.GetUserFromSession(HttpContext.Session, "SaveLogin");
            if (checkAdmin != null){
                SessionService.SetObjectToSession(HttpContext.Session, "SaveLogin", checkAdmin);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            if (checkLogin != null)
            {
               
                    //ac = checkLogin;
                    ////HttpContext.Session.SetString(checkLogin);
                    SessionService.SetObjectToSession(HttpContext.Session,"SaveLogin",  checkLogin);
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.LoginFail = "Username or Password incorrect";
                return View("Login");
            }
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public IActionResult Profile()
        {
            var user = _serviceUser.GetListUser().FirstOrDefault();
            ViewBag.Role = _serviceRole.GetListRole().FirstOrDefault(c=>c.RoleId == user.RoleId);
            return View();
        }
        public IActionResult EditUser(Guid Id)
        {
            var get = _serviceUser.GetUserByID(Id);
            return View(get);
        }
        [HttpPost]
        public IActionResult EditUser(User user)
        {
            if(_serviceUser.UpdateUser(user))
            {
                return RedirectToAction("Profile");
            }
            else
            {
                return ViewBag.Fail = "Thay đổi thông tin thất bại";
            }
        }
        public IActionResult Edit(Guid Id)
        {
            return View(_servicePr.GetProductByID(Id));
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if(_servicePr.UpdateProduct(obj))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult SaveOld(Guid ID, Product obj)
        {
            var get = _servicePr.GetProductByID(ID);
            var product = SessionService.GetObjectFromSession(HttpContext.Session, "ShowOld");
            if (product.Count == 0)
            {
                product.Add(get);
                SessionService.SetObjectToSession(HttpContext.Session, "ShowOld", product);
            }
            else
            {
                if (SessionService.CheckObjectInList(ID, product))
                {

                    var a = product.SingleOrDefault(c => c.Id == ID);
                    product.Remove(a);
                    product.Add(get);
                    SessionService.SetObjectToSession(HttpContext.Session, "ShowOld", product);
                }
                else
                {
                    product.Add(get);
                    SessionService.SetObjectToSession(HttpContext.Session, "ShowOld", product);
                }
            }
            _servicePr.UpdateProduct(obj);
            return RedirectToAction("Index");
        }
        public IActionResult RollBack(Guid Id)
        {
            List<Product> prs = SessionService.GetObjectFromSession(HttpContext.Session, "ShowOld");
            Product a = prs.FirstOrDefault(c => c.Id == Id);
            if (prs.Count == 0)
            {
                return BadRequest();
            }
            else
            {
                Edit(a);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult ShowOld()
        {
            var product = SessionService.GetObjectFromSession(HttpContext.Session, "ShowOld");
            return View(product);
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}