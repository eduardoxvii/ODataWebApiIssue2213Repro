using Microsoft.AspNet.OData;
using ODataWebApiIssue2213ReproEdm.Data;
using ODataWebApiIssue2213ReproEdm.Models;
using System.Linq;

namespace ODataWebApiIssue2213ReproEdm.Controllers
{
    public class SchoolController : ODataController
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
