using ODataWebApiIssue2213ReproNonEdm.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataWebApiIssue2213ReproNonEdm.Data
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options)
        {

        }

        public DbSet<StreetAddress> StreetAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
