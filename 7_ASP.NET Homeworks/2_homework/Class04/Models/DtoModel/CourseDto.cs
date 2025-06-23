namespace Class04.Models.DtoModel
{
    public class CoruseDto
    {
        public string CourseName { get; set; }
        public int NumberOfClasses { get; set; }

        public CoruseDto(string courseName, int numberOfClasses)
        {
            CourseName = courseName;
            NumberOfClasses = numberOfClasses;
        }
    }
}
