namespace WebApplication3.Models.ViewModals
{
    public class EditStudent
    {
        public int Id { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ActiveCourseId { get; set; }
        public List<CourseOptionVM> Courses { get; set; }
    }
}
