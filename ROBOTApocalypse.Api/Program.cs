using Microsoft.EntityFrameworkCore;
using ROBOTApocalypse.IServices;
using ROBOTApocalypse.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ROBOTApocalypse.DB.ROBOTApocalypseDBContext>
               (option => option.UseSqlServer(builder.Configuration.GetConnectionString("ROBOTApocalypse").ToString(),opts => opts.MigrationsAssembly("ROBOTApocalypse.DB"))
               .EnableSensitiveDataLogging());

builder.Services.AddTransient<IROBOTApocalypseService, ROBOTApocalypseService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
