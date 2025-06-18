using Class03.Database;
using Class03.Models.DtoModels;
using Class03.Models.Entities;

namespace Class03.Services
{
    public class CourseService
    {
        public CourseByIdDto GetCourseById(int id)
        {
            Course course = InMemoryDb.Courses.SingleOrDefault(x => x.Id == id);

            if (course == null)
            {
                return null;
            }

            CourseByIdDto courseByIdDto = new CourseByIdDto
            {
                Id = course.Id,
                Name = course.Name,
                NumberOfClasses = course.NumberOfClasses,
            };

            return courseByIdDto;
        }

        public List<ListAllCoursesDto> GetAllCourses()
        {
            return InMemoryDb.Courses.Select(course =>
            new ListAllCoursesDto
            {
                NameOfCourse = course.Name
            }).ToList();
        }
    }
}
