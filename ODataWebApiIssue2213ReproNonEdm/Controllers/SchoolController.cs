using ODataWebApiIssue2213ReproNonEdm.Data;
using ODataWebApiIssue2213ReproNonEdm.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ODataWebApiIssue2213ReproNonEdm.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : ControllerBase
    {
        private InMemoryDbContext _db;

        public SchoolController(InMemoryDbContext db)
        {
            _db = db;
        }

        [EnableQuery]
        public IQueryable<School> Get()
        {
            return _db.Schools;
        }
    }
}
