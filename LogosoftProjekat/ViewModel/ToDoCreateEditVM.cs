using LogosoftProjekat.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogosoftProjekat.ViewModel
{
    public class ToDoCreateEditVM
    {
      
        public int TodoId { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }

        public bool IsComplete { get; set; }
        public DateTime ModifiedOn { get; set; }



    }
}
