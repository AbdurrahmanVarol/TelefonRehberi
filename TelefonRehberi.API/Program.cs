using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using TelefonRehberi.Business.Abstract;
using TelefonRehberi.Business.Concrate;
using TelefonRehberi.DataAccess.Abstract;
using TelefonRehberi.DataAccess.Concrate.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TelefonRehberiContext>(options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;initial catalog=TelefonRehberiDb;Integrated Security=true"));
builder.Services.AddScoped<IPersonService, PersonManager>();
builder.Services.AddScoped<IPersonDal,EfPersonDal>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseRouting();

app.Run();
