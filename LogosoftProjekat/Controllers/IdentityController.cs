using LogosoftProjekat.EF;
using LogosoftProjekat.EntityModels;
using LogosoftProjekat.Helper;
using LogosoftProjekat.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosoftProjekat.Controllers
{
    public class IdentityController : Controller
    {
        private readonly MojContext _db;

        public IdentityController(MojContext db)
        {
            _db = db;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(IdentityLoginVM input)
        {

          Identity user = _db.Identity
                .SingleOrDefault(x => x.UserName == input.UserName && x.Password == input.Password);

            if (user == null)
            {
                ViewBag.Error = "User name or password is not valid";
                return View("Login", input);
            }
            else
            {
                HttpContext.SetLoggedUser(user);
                return RedirectToAction("Index","ToDo");
            }

         
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(IdentityRegisterVM input)
        {

            Identity user = new Identity();

            if (!ModelState.IsValid)
            {
                return View("Register", input);

            }
            else 
            {
                user.FirstName = input.FirstName;
                user.LastName = input.LastName;
                user.UserName = input.UserName;
                user.Password = input.Password;
                user.CreatedOn = DateTime.Now;

                Identity tempUser = _db.Identity.Where(x=>x.UserName==input.UserName).FirstOrDefault();
                if (tempUser != null)
                {
                   
                    ViewBag.Error = "The same username is not possible";
                    return View("Register",input);
                }
                else
                {
                    _db.Identity.Add(user);
                    _db.SaveChanges();

                }
            }

           
            

            return RedirectToAction("Login");

        }
    }
}
