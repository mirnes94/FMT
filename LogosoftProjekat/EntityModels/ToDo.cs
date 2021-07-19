using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LogosoftProjekat.EntityModels
{
    public class ToDo
    {
        [Key]
        public int TodoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }

        [ForeignKey("CreatedById")]
        public Identity CreatedBy { get; set; }
        public int CreatedById { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        
    }
}
