
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ReversedWord.Repository;
using ReversedWord.Service;
using System.Transactions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IReversedSentenceRepository, ReversedSentenceRepository>();
builder.Services.AddScoped<IReversedSentenceService, ReversedSentenceService>();

var app = builder.Build();

//builder.Services.AddDbContext<ReversedWord.Repository.ApplicationContext>();



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

