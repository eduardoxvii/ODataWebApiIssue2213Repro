using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataWebApiIssue2213ReproEdm.Models
{
    public class School : Place
    {
        public Order Order { get; set; }
    }
}
