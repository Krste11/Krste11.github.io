using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.DataAccess;
using MovieApp.DataAccess.Implementations;
using MovieApp.Domain.Models;
using MovieApp.Services.Implementations;
using MovieApp.Services.Interfaces;

namespace MovieApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MovieAppDbContext>(x => 
            x.UseSqlServer(connectionString));
        }

        public static void InjectRepositorys(IServiceCollection services)
        {
            services.AddTransient<IRepository<Movie>, MovieRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IMovieService, MovieService>();
        }
    }
}
