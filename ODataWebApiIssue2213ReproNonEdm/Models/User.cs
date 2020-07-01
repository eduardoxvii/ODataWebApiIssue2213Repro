using System;
using System.ComponentModel.DataAnnotations;

namespace ODataWebApiIssue2213ReproNonEdm.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
