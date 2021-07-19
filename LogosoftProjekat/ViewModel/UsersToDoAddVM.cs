using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogosoftProjekat.ViewModel
{
    public class UsersToDoAddVM
    {

        [Required(ErrorMessage = "Mandatory**")]
        public int UserId { get; set; }
        public List<SelectListItem> Users { get; set; }
        [Required(ErrorMessage = "Mandatory**")]
        public int ToDoId { get; set; }
        public List<SelectListItem> ToDos { get; set; }
    }
}
