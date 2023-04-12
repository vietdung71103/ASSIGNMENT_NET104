using FINAL_ASSIGNMENT.Models;
using FINAL_ASSIGNMENT.Service.Context;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace FINAL_ASSIGNMENT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleAdminController : Controller
    {
        WebContext _db;
        public RoleAdminController()
        {
            _db = new WebContext();
        }
        public IActionResult Index()
        {
            ViewBag.RoleList = _db.Roles.ToList();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Role role)
        {
            _db.Roles.Add(role);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Detail(Guid ID)
        {
                var get = _db.Roles.ToList().FirstOrDefault(c => c.RoleId == ID);
                return View(get);
        }
        public IActionResult Edit(Guid ID)
        {
            var get = _db.Roles.ToList().FirstOrDefault(c => c.RoleId == ID);
            return View(get);
        }
        [HttpPost]
        public IActionResult Edit(Role role)
        {
            _db.Roles.Update(role);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid ID)
        {
            var get = _db.Roles.ToList().FirstOrDefault(c => c.RoleId == ID);
            _db.Roles.Remove(get);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
