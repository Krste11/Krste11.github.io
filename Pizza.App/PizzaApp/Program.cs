using PizzaApp.Helpers.DIContainer;
using PizzaApp.Helpers.Extensions;
using PizzaApp.Mappers.MapperConfig;
using PizzaApp.Shared.Settings;

var builder = WebApplication.CreateBuilder(args);
var appSettings = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettings);
AppSettings appSettingsObject = appSettings.Get<AppSettings>();
var connectionString = appSettingsObject.ConnectionString;

builder.Configuration.AddEnvironmentVariables();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly)
                .AddPostgreSqlDbContext(appSettings)
                .AddAuthentication()
                .AddJwt(appSettings)
                .AddIdentity()
                .AddSwager();

DIHelper.InjectRepositories(builder.Services);
DIHelper.InjectServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CORSPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();