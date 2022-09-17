namespace University.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public List<StudentLesson> StudentLessons { get; set; }
    }
}
