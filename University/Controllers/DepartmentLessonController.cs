using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
    public class DepartmentLessonController : Controller
    {
        private readonly ApplicationDbContext db;

        public DepartmentLessonController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            ViewBag.Lessons =db.Lessons.ToList();
            ViewBag.Departments=db.Departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Index(DepartmentLesson departmentLesson)
        {
            if (db.DepartmentLessons.Where(dl => dl.DepartmentId == departmentLesson.DepartmentId && dl.LessonId == departmentLesson.LessonId).Count() > 0)
                return View("Error_DepartmentLesson");

            db.DepartmentLessons.Add(departmentLesson);
            db.SaveChanges();
            ViewBag.Lessons = db.Lessons.ToList();
            ViewBag.Departments = db.Departments.ToList();
            //return View();
            return RedirectToAction("Index", "DepartmentLesson");

        }
        public IActionResult Error_DepartmentLesson()
        {
            return View();
        }
    }
}
