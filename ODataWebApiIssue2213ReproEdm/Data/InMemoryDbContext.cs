using ODataWebApiIssue2213ReproEdm.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataWebApiIssue2213ReproEdm.Data
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options)
        {

        }

        public DbSet<StreetAddress> StreetAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<School> Schools { get; set; }
    }
}
