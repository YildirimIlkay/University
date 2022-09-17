using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
    //[Authorize(Roles = "Dean")]
    public class LessonController : Controller
    {
        private readonly ApplicationDbContext db;

        public LessonController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Lesson lesson)
        {
            
            db.Lessons.Add(lesson);
            db.SaveChanges();
            return View();
        }
    }
}
