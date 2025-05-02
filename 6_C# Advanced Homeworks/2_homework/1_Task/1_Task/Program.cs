using _1_Task.Entities.Modals;
using _1_Task.Entities.Services;


var userById = UserService.SearchById(3);
Console.WriteLine("Found by Id:");
Console.WriteLine("Id=" + userById.Id + ", Name=" + userById.Name + ", Age=" + userById.Age);

var usersByName = UserService.SearchByName("Bob");
for (int i = 0; i < usersByName.Count; i++)
{
    Console.WriteLine("Found by Name:");
    Console.WriteLine("Id=" + usersByName[i].Id + ", Name=" + usersByName[i].Name + ", Age=" + usersByName[i].Age);
}

var usersByAge = UserService.SearchByAge(17);
for (int i = 0; i < usersByAge.Count; i++)
{
    Console.WriteLine("Found by Age:");
    Console.WriteLine("Id=" + usersByAge[i].Id + ", Name=" + usersByAge[i].Name + ", Age=" + usersByAge[i].Age);
}