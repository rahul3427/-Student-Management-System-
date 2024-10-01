using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user obj)
        {
            if (ModelState.IsValid) 
            {
                using (StudentsinfoEntities1 db = new StudentsinfoEntities1())
                {

                    var check = db.users.Where(a => a.Username.Equals(obj.Username) && a.Password.Equals(obj.Password)).FirstOrDefault();
                    if (check != null)
                    {
                        Session["UserID"] = obj.id.ToString();
                        Session["UserName"] = obj.Username.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else ModelState.AddModelError("","The username or password is incorrect!");           
                }   
            }
            return View();
        }

    }
}