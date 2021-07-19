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
    public class CurrentSessionController : Controller
    {

        private readonly MojContext _db;

        public CurrentSessionController(MojContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            CurrentSessionIndexVM model = new CurrentSessionIndexVM();
            model.Rows = _db.AuthorizationToken.Select(s => new CurrentSessionIndexVM.Row
            {
                IpAddress=s.IpAddress,
                LoggedTime=s.LoggedTime,
                Token=s.Value
            }).ToList();
            model.CurrentToken = HttpContext.GetCurrentToken();
            return View(model);
        }

        public IActionResult Remove(string token)
        {
            AuthorizationToken tempToken = _db.AuthorizationToken.Where(x=>x.Value==token).FirstOrDefault();
            if (tempToken != null)
            {
                _db.AuthorizationToken.Remove(tempToken);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
