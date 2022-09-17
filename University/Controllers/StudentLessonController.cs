using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
        //[Authorize(Roles ="Student")]
    public class StudentLessonController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;

        public StudentLessonController(ApplicationDbContext db,UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            ViewBag.Lessons = db.Lessons.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(StudentLesson studentLesson)
        {
            var userId = userManager.GetUserId(HttpContext.User);
            ApplicationUser user = await userManager.FindByIdAsync(userId);
            studentLesson.ApplicationUser = user;
            studentLesson.ApplicationUserId = userId;
            studentLesson.Lesson = db.Lessons.FirstOrDefault(l=>l.Id == studentLesson.LessonId);
            if(db.StudentLessons.Any(sl=>sl.LessonId==studentLesson.LessonId && sl.ApplicationUserId==studentLesson.ApplicationUserId))
                {
                ViewData["Message"] = "The Lesson already been registered";
            }
            else
            {
                db.StudentLessons.Add(studentLesson);
                db.SaveChanges();
            }

          
            return RedirectToAction("Index");
        }
    }
}
