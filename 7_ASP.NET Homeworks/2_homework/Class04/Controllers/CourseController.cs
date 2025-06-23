using Class04.Models.DtoModel;
using Class04.Models.ViewModels;
using Class04.Services;
using Microsoft.AspNetCore.Mvc;

namespace Class04.Controllers
{
    [Route("courses")]
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;

        public CourseController()
        {
            _courseService = new CourseService();
        }

        [HttpGet("all")]
        public IActionResult GetAllCourses()
        {
            List<CoruseDto> courses = _courseService.GetAllCourses();

            return View(courses);
        }

        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            CreateCourseVM course = _courseService.GetCourseById(id);

            if (course == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(course);
        }

        [HttpGet("createCourse")]
        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost("createCourse")]
        public IActionResult CreateCourse(CreateCourseVM courseVM)
        {
            _courseService.CreateCourse(courseVM);
            return RedirectToAction("GetAllCourses");
        }
    }
}
