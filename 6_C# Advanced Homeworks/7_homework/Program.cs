using Qinshift.AdoNet.Entities;
using Qinshift.AdoNet.Services;

string connectionString = "Server=ANGEL;Database=SEDC_ACADEMY_HOMEWORK;Trusted_Connection=True;TrustServerCertificate=True;";
StudentService studentService = new StudentService(connectionString);

while (true)
{
    Console.WriteLine("\n========= Student Management Menu =========");
    Console.WriteLine("1. Show all students");
    Console.WriteLine("2. Show student by ID");
    Console.WriteLine("3. Insert a new student");
    Console.WriteLine("4. Delete student by ID");
    Console.WriteLine("5. Update student first name");
    Console.WriteLine("6. Exit");
    Console.Write("Choose an option: ");

    string option = Console.ReadLine() ?? "";

    switch (option)
    {
        case "1":
            var students = studentService.GetAllStudents();
            Console.WriteLine("\nAll Students:");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id} - {student.FirstName} {student.LastName} | StudentCard: {student.StudentCardNumber}");
            }
            break;

        case "2":
            Console.Write("Enter student ID: ");
            if (int.TryParse(Console.ReadLine(), out int idToShow))
            {
                var student = studentService.GetStudentById(idToShow.ToString());
                if (student != null)
                {
                    Console.WriteLine($"ID: {student.Id} - {student.FirstName} {student.LastName} | Gender: {student.Gender}");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            break;

        case "3":
            Console.WriteLine("Enter details for new student:");
            Console.Write("First Name: ");
            string? firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string? lastName = Console.ReadLine();

            Console.Write("Date of Birth (yyyy-MM-dd) or leave empty: ");
            string? dobInput = Console.ReadLine();
            DateTime? dob = string.IsNullOrWhiteSpace(dobInput) ? null : DateTime.Parse(dobInput);

            Console.Write("Enrolled Date (yyyy-MM-dd) or leave empty: ");
            string? enrolledInput = Console.ReadLine();
            DateTime? enrolledDate = string.IsNullOrWhiteSpace(enrolledInput) ? null : DateTime.Parse(enrolledInput);

            Console.Write("Gender (M/F) or leave empty: ");
            string? genderInput = Console.ReadLine();
            char? gender = string.IsNullOrWhiteSpace(genderInput) ? null : genderInput[0];

            Console.Write("National ID Number or leave empty: ");
            string? nidInput = Console.ReadLine();
            long? nationalId = string.IsNullOrWhiteSpace(nidInput) ? null : long.Parse(nidInput);

            Console.Write("Student Card Number or leave empty: ");
            string? cardNumber = Console.ReadLine();

            Student newStudent = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dob,
                EnrolledDate = enrolledDate,
                Gender = gender,
                NationalIdNumber = nationalId,
                StudentCardNumber = cardNumber
            };

            studentService.InsertStudent(newStudent);
            Console.WriteLine("New student inserted successfully!");
            break;

        case "4":
            Console.Write("Enter ID of student to delete: ");
            if (int.TryParse(Console.ReadLine(), out int idToDelete))
            {
                studentService.DeleteStudentById(idToDelete);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            break;

        case "5":
            Console.Write("Enter ID of student to update first name: ");
            if (int.TryParse(Console.ReadLine(), out int idToUpdate))
            {
                Console.Write("Enter new first name: ");
                string? newFirstName = Console.ReadLine();

                studentService.UpdateStudentFirstName(idToUpdate, newFirstName ?? "");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            break;

        case "6":
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}
