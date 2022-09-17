using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
    //[Authorize(Roles = "StudentAffairs")]
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext db;

        public DepartmentController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return View();
        }
    }
}
