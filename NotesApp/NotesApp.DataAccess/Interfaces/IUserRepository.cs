﻿using NotesApp.Domain.Models;

namespace NotesApp.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUsername(string username);
        User LoginUser(string username, string hashedPassword);
    }
}
