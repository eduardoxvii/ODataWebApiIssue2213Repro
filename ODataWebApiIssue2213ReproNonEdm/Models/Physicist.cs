using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ODataWebApiIssue2213ReproNonEdm.Models
{
    public abstract class Physicist
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
