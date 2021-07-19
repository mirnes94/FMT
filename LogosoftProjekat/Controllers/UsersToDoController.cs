using LogosoftProjekat.EF;
using LogosoftProjekat.EntityModels;
using LogosoftProjekat.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosoftProjekat.Controllers
{
    public class UsersToDoController : Controller
    {
        private readonly MojContext _db;

        public UsersToDoController(MojContext db)
        {
            _db = db;
        }

        public IActionResult Index(int userId)
        {
            UsersToDoAddVM model = new UsersToDoAddVM();
            model.UserId = userId;
            model.Users = _db.Identity.Where(x => x.UserId != userId)
                .Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem {
                    Value = x.UserId.ToString(),
                    Text = x.FirstName + " " + x.LastName

                }).ToList();
            model.ToDos = _db.ToDo.Where(x=>x.CreatedById!=userId)
                .Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = x.TodoId.ToString(),
                Text=x.Title+" "+x.Description
            }).ToList();
            return View(model);
        }
        public IActionResult Add(UsersToDoAddVM input)
        {

            UsersToDo userToDo = new UsersToDo();

            if (!ModelState.IsValid)
            {
                
                input.Users = _db.Identity.Where(x => x.UserId != input.UserId)
                .Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = x.UserId.ToString(),
                    Text = x.FirstName + " " + x.LastName

                }).ToList();
                input.ToDos = _db.ToDo.Where(x => x.CreatedById != input.UserId)
                    .Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                    {
                        Value = x.TodoId.ToString(),
                        Text = x.Title + " " + x.Description
                    }).ToList();
                return RedirectToAction("Index?userId"+input.UserId);
            }
            userToDo.UserId = input.UserId;
            userToDo.ToDoId = input.ToDoId;
            _db.UsersToDo.Add(userToDo);
            _db.SaveChanges();
            return RedirectToAction("Index","ToDo");
        }
     
    }
}
