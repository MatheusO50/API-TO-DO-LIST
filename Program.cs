using To_Do_List.Repository;
using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using To_Do_List.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DbDataContext>(opt =>
{
   opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultStringConnection")); 
});
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
