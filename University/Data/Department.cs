﻿namespace University.Data
{
        [Index("Name",IsUnique=true)]
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<DepartmentLesson> DepartmentLessons { get; set; }

        public DepartmentFee DepartmentFee { get; set; }
    }
}
