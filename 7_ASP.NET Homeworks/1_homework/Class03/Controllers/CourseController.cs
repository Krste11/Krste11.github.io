using Class03.Models.DtoModels;
using Class03.Services;
using Microsoft.AspNetCore.Mvc;

namespace Class03.Controllers
{
    [Route("courses")]
    public class CourseController : Controller
    {
        private CourseService _courseService;

        public CourseController()
        {
            _courseService = new CourseService();
        }

        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            CourseByIdDto course = _courseService.GetCourseById(id);

            if (course == null)
            {
                return Content("Course not found");
            }

            return Json(course);
        }

        [HttpGet("all")]
        public IActionResult GetAllCourses()
        {
            List<ListAllCoursesDto> courses = _courseService.GetAllCourses();

            return Json(courses);
        }
    }
}
