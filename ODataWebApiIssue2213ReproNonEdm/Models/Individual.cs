using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataWebApiIssue2213ReproNonEdm.Models
{
    public class Individual : People
    {
        public string  MotherName { get; set; }
    }
}
