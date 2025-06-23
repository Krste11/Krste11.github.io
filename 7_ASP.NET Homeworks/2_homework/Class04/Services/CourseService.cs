using Class04.Database;
using Class04.Models.DtoModel;
using Class04.Models.Entites;
using Class04.Models.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.Contracts;

namespace Class04.Services
{
    public class CourseService
    {
        public List<CoruseDto> GetAllCourses()
        {
            List<CoruseDto> courses = InMemoryDb.Courses.Select(x => new CoruseDto(x.Name, x.NumberOfClasses)).ToList();

            return courses;
        }

        public CreateCourseVM GetCourseById(int id)
        {
            Course course = InMemoryDb.Courses.SingleOrDefault(x => x.Id == id);

            if (course == null)
            {
                return null;
            }

            return new CreateCourseVM
            {
                Id = course.Id,
                CourseName = course.Name,
                NumberOfClasses = course.NumberOfClasses
            };
        }

        public void CreateCourse(CreateCourseVM courseVM)
        {
            Course course = new Course
            {
                Id = InMemoryDb.Courses.Count + 1,
                Name = courseVM.CourseName,
                NumberOfClasses = courseVM.NumberOfClasses
            };

            InMemoryDb.Courses.Add(course);
        }
    }
}
