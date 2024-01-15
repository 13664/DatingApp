using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddCors();



var app = builder.Build();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
