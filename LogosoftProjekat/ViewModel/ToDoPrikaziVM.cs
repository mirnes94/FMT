using LogosoftProjekat.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosoftProjekat.ViewModel
{
    public class ToDoPrikaziVM
    {
        public int UserId { get; set; }

        public List<Rows> rows { get; set; }

        public class Rows
        {
            public int TodoId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int Size { get; set; }
            public string TempDescription { get; set; }
            public bool IsComplete { get; set; }
            public Identity CreatedBy { get; set; }
            public DateTime CreatedOn { get; set; }
            public DateTime ModifiedOn { get; set; }
        }
       
    }
}
