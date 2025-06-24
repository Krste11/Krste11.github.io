using Class05.Database;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.Domain;
using WebApplication3.Models.ViewModals;

namespace WebApplication3.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        [HttpGet("all")]
        public IActionResult GetAllStudents()
        {
            List<StudentVM> students = InMemoryDb.Students.Select(x => new StudentVM
            {
                Id = x.Id,
                FullName = $"{x.FirstName} {x.LastName}",
                Age = DateTime.Now.Year - x.DateOfBirth.Year,
                ActiveCourseName = x.ActiveCourse?.Name
            }).ToList();

            return View(students);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            CreateStudentVM createStudentVM = new();
            createStudentVM.Courses = InMemoryDb.Courses.Select(x => new CourseOptionVM
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return View(createStudentVM);
        }

        [HttpGet("edit")]
        public IActionResult Edit(int id)
        {
            Student student = InMemoryDb.Students.SingleOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            EditStudent editStudent = new EditStudent
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                ActiveCourseId = student.ActiveCourse?.Id,
                Courses = InMemoryDb.Courses.Select(x => new CourseOptionVM
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };

            return View(editStudent);
        }

        [HttpPost("edit")]
        public IActionResult Edit(EditStudent editStudent)
        {
            Student student = InMemoryDb.Students.SingleOrDefault(x => x.Id == editStudent.Id);
            if (student == null)
            {
                return NotFound();
            }

            student.FirstName = editStudent.FirstName;
            student.LastName = editStudent.LastName;
            student.DateOfBirth = editStudent.DateOfBirth;
            student.ActiveCourse = InMemoryDb.Courses.FirstOrDefault(x => x.Id == editStudent.ActiveCourseId);

            return RedirectToAction("GetAllStudents");
        }


        [HttpPost("create")]
        public IActionResult Create(CreateStudentVM createStudentVM)
        {
            Student student = new Student
            {
                Id = InMemoryDb.Students.Count + 1,
                FirstName = createStudentVM.FirstName,
                LastName = createStudentVM.LastName,
                DateOfBirth = createStudentVM.DateOfBirth,
                ActiveCourse = InMemoryDb.Courses.FirstOrDefault(x => x.Id == createStudentVM.ActiveCourseId)
            };

            InMemoryDb.Students.Add(student);
            return RedirectToAction("GetAllStudents");
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            Student student = InMemoryDb.Students.SingleOrDefault(x => x.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            StudentVM studentVM = new StudentVM
            {
                Id = student.Id,
                FullName = $"{student.FirstName} {student.LastName}",
                Age = DateTime.Now.Year - student.DateOfBirth.Year,
                ActiveCourseName = student.ActiveCourse.Name,
            };

            return View(studentVM);
        }
    }
}
