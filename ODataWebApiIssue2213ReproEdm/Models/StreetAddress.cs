using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataWebApiIssue2213ReproEdm.Models
{
    public class StreetAddress
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    }
}
