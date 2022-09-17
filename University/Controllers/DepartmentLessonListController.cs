using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
    //[Authorize(Roles = "Dean")]
    public class DepartmentLessonListController : Controller
    {
        private readonly ApplicationDbContext db;

        public DepartmentLessonListController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {

            return View(db.DepartmentLessons.Include(dl=>dl.Department).Include(dl => dl.Lesson).ToList());
        }
    }
}
