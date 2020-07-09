using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using Newtonsoft.Json;
using System.Security.Claims;
using ODataWebApiIssue2213ReproNonEdm.Models;

namespace ODataWebApiIssue2213ReproNonEdm.Data
{
    public class InMemoryDbContext : DbContext
    {
        public DbSet<StreetAddress> Streetaddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Legal> PeopleLegal { get; set; }
        public DbSet<Individual> PeopleIndividual { get; set; }

        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options)
    : base(options)
        {
        }
       

    }
}