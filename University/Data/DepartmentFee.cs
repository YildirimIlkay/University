namespace University.Data
{
    public class DepartmentFee
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
