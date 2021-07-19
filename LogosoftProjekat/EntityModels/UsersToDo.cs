using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LogosoftProjekat.EntityModels
{
    public class UsersToDo
    {
        [Key]
        public int UserToDoId { get; set; }

        [ForeignKey("UserId")]
        public Identity User { get; set; }
        public int UserId { get; set; }

        [ForeignKey("ToDoId")]
        public ToDo ToDo { get; set; }
        public int ToDoId { get; set; }

        
    }
}
