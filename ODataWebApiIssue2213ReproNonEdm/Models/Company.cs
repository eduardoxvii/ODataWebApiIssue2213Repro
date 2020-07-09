using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataWebApiIssue2213ReproNonEdm.Models
{
    public class Company : Place
    {
        public string ManagerNage { get; set; }
    }
}
