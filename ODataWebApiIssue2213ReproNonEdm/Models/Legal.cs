using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataWebApiIssue2213ReproNonEdm.Models
{
    public class Legal : People
    {
        public string Municipalregistry { get; set; }
    }
}
