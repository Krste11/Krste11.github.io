using Avenga.NoteApp.DataAccess;
using Avenga.NoteApp.DataAccess.Implementations;
using Avenga.NoteApp.Domain.Models;
using Avenga.NoteApp.Services.Implementations;
using Avenga.NoteApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Avenga.NoteApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services)
        {
            services.AddDbContext<NotesAppDbContext>(x =>
            x.UseSqlServer("Server=.;Database=NotesDb;Trusted_Connection=True;TrustServerCertificate=True"));
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Note>, NoteRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<INoteService, NoteService>();
        }
    }
}
