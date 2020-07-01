using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataWebApiIssue2213ReproEdm.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StreetAddress ShippingAddress { get; set; }
    }
}
