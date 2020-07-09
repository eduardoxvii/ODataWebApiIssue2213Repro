using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataWebApiIssue2213ReproNonEdm.Models
{
    public class School : Place
    {
        public Order Order { get; set; }
        public Place Branch { get; set; }
        //public People Owner { get; set; }
    }
}
