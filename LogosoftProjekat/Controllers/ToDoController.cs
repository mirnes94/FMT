using LogosoftProjekat.EF;
using LogosoftProjekat.EntityModels;
using LogosoftProjekat.Helper;
using LogosoftProjekat.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LogosoftProjekat.ViewModel.ToDoPrikaziVM;

namespace LogosoftProjekat.Controllers
{
    public class ToDoController : Controller
    {
        private readonly MojContext _db;

        public ToDoController(MojContext db)
        {
            _db = db;
        }

        public IActionResult SearchToDo(string? searchString,DateTime? from,DateTime? to, int? isComplete)
        {
           
            bool complete;
            if(isComplete==0)
            {
                complete = false;
            }
            else
            {
                complete = true;
            }
            ToDoPrikaziVM todo = new ToDoPrikaziVM(); 
            todo.UserId = HttpContext.GetLoggedUser().UserId;

            if (searchString != null)
            {
                if (from != null && to != null)
                {
                    if (isComplete != null)
                    {
                        todo.rows = _db.ToDo.Where(x => (x.Title.ToLower().Contains(searchString.ToLower())
                         || x.Description.ToLower().Contains(searchString.ToLower()) || searchString == null)
                        && (x.CreatedOn >= from && x.CreatedOn <= to) && x.IsComplete == complete)
                        .Select(x => new Rows
                         {
                            TodoId = x.TodoId,
                            Title = x.Title,
                            Description = x.Description,
                            Size = x.Description.Length,
                            TempDescription = x.Description.Substring(0, 30),
                            IsComplete = x.IsComplete,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn

                        }).ToList();
                    }
                    else
                    {
                        todo.rows = _db.ToDo.Where(x => (x.Title.ToLower().Contains(searchString.ToLower())
                        || x.Description.ToLower().Contains(searchString.ToLower()) || searchString == null)
                        && (x.CreatedOn >= from && x.CreatedOn <= to))
                        .Select(x => new Rows
                        {
                            TodoId = x.TodoId,
                            Title = x.Title,
                            Description = x.Description,
                            Size = x.Description.Length,
                            TempDescription = x.Description.Substring(0, 30),
                            IsComplete = x.IsComplete,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedOn = x.ModifiedOn

                        }).ToList();
                    }

                }
                else
                {
                    todo.rows = _db.ToDo.Where(x => (x.Title.ToLower().Contains(searchString.ToLower())
                    || x.Description.ToLower().Contains(searchString.ToLower()) || searchString == null) && x.IsComplete==complete)
                    .Select(x => new Rows
                     {
                        TodoId = x.TodoId,
                        Title = x.Title,
                        Description = x.Description,
                        Size = x.Description.Length,
                        TempDescription = x.Description.Substring(0, 30),
                        IsComplete = x.IsComplete,
                        CreatedBy = x.CreatedBy,
                        CreatedOn = x.CreatedOn,
                        ModifiedOn = x.ModifiedOn

                    }).ToList();
                }
            }
            else if (from != null && to != null)
            {
                if (isComplete != null)
                {
                    todo.rows = _db.ToDo.Where(x => (x.CreatedOn >= from && x.CreatedOn <= to) && x.IsComplete == complete)
                     .Select(x => new Rows
                     {
                         TodoId = x.TodoId,
                         Title = x.Title,
                         Description = x.Description,
                         Size = x.Description.Length,
                         TempDescription = x.Description.Substring(0, 30),
                         IsComplete = x.IsComplete,
                         CreatedBy = x.CreatedBy,
                         CreatedOn = x.CreatedOn,
                         ModifiedOn = x.ModifiedOn

                     }).ToList();
                }
                else
                {
                    todo.rows = _db.ToDo.Where(x => x.CreatedOn >= from && x.CreatedOn <= to )
                    .Select(x => new Rows
                    {
                        TodoId = x.TodoId,
                        Title = x.Title,
                        Description = x.Description,
                        Size = x.Description.Length,
                        TempDescription = x.Description.Substring(0, 30),
                        IsComplete = x.IsComplete,
                        CreatedBy = x.CreatedBy,
                        CreatedOn = x.CreatedOn,
                        ModifiedOn = x.ModifiedOn

                    }).ToList();
                }
               
            }else if (isComplete != null)
            {
                todo.rows = _db.ToDo.Where(x => x.IsComplete == complete)
                .Select(x => new Rows
                {
                    TodoId = x.TodoId,
                    Title = x.Title,
                    Description = x.Description,
                    Size = x.Description.Length,
                    TempDescription = x.Description.Substring(0, 30),
                    IsComplete = x.IsComplete,
                    CreatedBy = x.CreatedBy,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn

                }).ToList();
            }
            else
            {
                todo.rows = _db.ToDo.
                  Select(x => new Rows
                  {
                      TodoId = x.TodoId,
                      Title = x.Title,
                      Description = x.Description,
                      Size = x.Description.Length,
                      TempDescription = x.Description.Substring(0, 30),
                      IsComplete = x.IsComplete,
                      CreatedBy = x.CreatedBy,
                      CreatedOn = x.CreatedOn,
                      ModifiedOn = x.ModifiedOn

                  }).ToList();
            }
            
           
           

            return View("Index",todo);

        }
        public IActionResult Index()
        {
            ToDoPrikaziVM todo = new ToDoPrikaziVM();
            todo.UserId = HttpContext.GetLoggedUser().UserId;
            todo.rows= _db.ToDo.Select(x => new Rows
            {
                TodoId= x.TodoId,
                Title = x.Title,
                Description = x.Description,
                Size = x.Description.Length,
                TempDescription = x.Description.Substring(0, 30),
                IsComplete = x.IsComplete,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                ModifiedOn=x.ModifiedOn

            }).ToList();
           

            return View(todo);
        }
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(ToDoCreateEditVM input)
        {
            ToDo toDo;
            if (input.TodoId != 0)
            {
                toDo = _db.ToDo.Find(input.TodoId);
                toDo.IsComplete = input.IsComplete;
                toDo.ModifiedOn = DateTime.Now;

            }
            else
            {
                toDo = new ToDo();
                toDo.IsComplete = false;
                toDo.CreatedOn = DateTime.Now;
                toDo.ModifiedOn = DateTime.Now;
                _db.ToDo.Add(toDo);
               
            }

            Identity loggedUser = HttpContext.GetLoggedUser();      
            toDo.CreatedBy = loggedUser;
            toDo.CreatedById = loggedUser.UserId;
           
          
            toDo.Description = input.Description;
            toDo.Title = input.Title;
          
           
            _db.SaveChanges();


            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            ToDo toDo = _db.ToDo.Find(id);

            _db.ToDo.Remove(toDo);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {

            var todo = _db.ToDo.Find(id);

            ToDoCreateEditVM model = new ToDoCreateEditVM
            {
                TodoId=todo.TodoId,
                Description=todo.Description,
                Title=todo.Title,
                IsComplete=todo.IsComplete,
                ModifiedOn=DateTime.Now
            };

            return View("Edit",model);
        }
        public IActionResult Details(int id)
        {
            ToDo toDo = _db.ToDo.Find(id);
            ToDoDetailsVM model = new ToDoDetailsVM();
            model.UserId = HttpContext.GetLoggedUser().UserId;
            model.TodoId = toDo.TodoId;
            model.Title = toDo.Title;
            model.Description = toDo.Description;
            model.Size = toDo.Description.Length;
            model.TempDescription = toDo.Description.Substring(0, 30);
            model.IsComplete = toDo.IsComplete;

            model.CreatedBy = toDo.CreatedBy;
            model.CreatedOn = toDo.CreatedOn;
            model.ModifiedOn = toDo.ModifiedOn;
            return View(model);
        }
        

    }
}
