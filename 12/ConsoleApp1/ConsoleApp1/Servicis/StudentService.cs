using ConsoleApp1.Entitis;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1.Servicis
{
    public class StudentService
    {
        private readonly string _conString;
        public StudentService(string conString)
        {
            _conString = conString;
        }
        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();

            using (SqlConnection conection = new SqlConnection(_conString))
            {
                conection.Open();

                string query = "SELECT ID,FirstName,LastName,DateOfBirth, EnrolledDate,Gender,NationalIdNumber, StudentCardNumber from Student";

                using (SqlCommand command = new SqlCommand(query, conection))
                using (SqlDataReader reader = command.ExecuteReader()) 
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.IsDBNull(1) ? null : reader.GetString(1),
                            LastName = reader.IsDBNull(2) ? null : reader.GetString(2),
                            DateOfBirth = reader.IsDBNull(3) ? null : reader.GetDateTime(3),
                            EnrolledDate = reader.IsDBNull(4) ? null : reader.GetDateTime(4),
                            Gender = reader.IsDBNull(5) ? null : reader.GetString(5)[0],
                            NationalIdNumber = reader.IsDBNull(6) ? null : reader.GetInt64(6),
                            StudentCardNumber = reader.IsDBNull(7) ? null : reader.GetString(7)
                        });
                    }
                }
            }
            return students;
        }
        public Student GetStudentById(string id)
        {
            Student? student = null;
            using (SqlConnection connection = new SqlConnection(_conString))
            {
                connection.Open();

                string query = $"SELECT * from Student WHERE ID = {id}";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            student = new Student()
                            {
                                Id = reader.GetFieldValue<int>(0),
                                FirstName = reader.IsDBNull(1) ? null : reader.GetFieldValue<string>(1),
                                LastName = reader.IsDBNull(2) ? null : reader.GetFieldValue<string>(2),
                                DateOfBirth = reader.IsDBNull(3) ? null : reader.GetFieldValue<DateTime>(3),
                                EnrolledDate = reader.IsDBNull(4) ? null : reader.GetFieldValue<DateTime>(4),
                                Gender = reader.IsDBNull(5) ? null : reader.GetFieldValue<string>(5)[0],
                                NationalIdNumber = reader.IsDBNull(6) ? null : reader.GetFieldValue<long>(6),
                                StudentCardNumber = reader.IsDBNull(7) ? null : reader.GetFieldValue<string>(7),
                            };
                        }
                    }
                }
            }
            return student;
        }
        public void InsertStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(_conString))
            {
                connection.Open();
                
                string query = $"INSER INTO Student (@ID,@FirstName,@LastName,@DateOfBirth, @EnrolledDate,@Gender,@NationalIdNumber, StudentCardNumber) VALUES(ID,FirstName,LastName,DateOfBirth, EnrolledDate,Gender,NationalIdNumber, StudentCardNumber";
            } 
        }
    }
}
