using System.Globalization;
using System.Reflection.Emit;

namespace _1_Task.Entities.Modals
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public User(int id, string name, int age)
            :base(id)
        {
            Name = name;
            Age = age;
        }
    }
}
