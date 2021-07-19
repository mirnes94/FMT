using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosoftProjekat.ViewModel
{
    public class CurrentSessionIndexVM
    {
        public List<Row> Rows { get; set; }
        public string CurrentToken { get; set; }

        public class Row
        {
            public DateTime LoggedTime { get; set; }
            public string Token { get; set; }
            public string IpAddress { get; set; }
        }
    }
}
