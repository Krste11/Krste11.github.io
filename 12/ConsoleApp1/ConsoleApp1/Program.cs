using ConsoleApp1.Servicis;

string connectionString = "Server=.;Database=SEDC;Trusted_Connection=True;TrustServerCertificate=True;";

StudentService studentService = new StudentService(connectionString);

Console.WriteLine("Press enter if you want to fetch all students from the db");
Console.ReadLine();

var students = studentService.GetAllStudents();

//students.ForEach(
//    student =>  Console.WriteLine($"Student{student.FirstName} {student.LastName} | {student.Gender} | {student.NationalIdNumber} | {student.StudentCardNumber}"
//    ));

students.ForEach(student =>
{
    Console.WriteLine($"{student.Id,5} {student.FirstName,-15} {student.LastName,-15} {student.Gender,7} " +
                      $"{(student.DateOfBirth?.ToString("yyyy-MM-dd") ?? "N/A"),12} " +
                      $"{(student.EnrolledDate?.ToString("yyyy-MM-dd") ?? "N/A"),12} " +
                      $"{(student.NationalIdNumber?.ToString() ?? "N/A"),10} " +
                      $"{student.StudentCardNumber,-10}");
});

Console.WriteLine("Enter Id to fetch student by id: ");
string studentId = Console.ReadLine();
var studentById = studentService.GetStudentById(studentId);

Console.WriteLine($"Student: {studentById.FirstName} {studentById.LastName} {studentById.Gender}");