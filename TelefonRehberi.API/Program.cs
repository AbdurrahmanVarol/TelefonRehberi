using Microsoft.EntityFrameworkCore;
using TelefonRehberi.Business.Abstract;
using TelefonRehberi.Business.Concrete;
using TelefonRehberi.DataAccess.Abstract;
using TelefonRehberi.DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TelefonRehberiContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPersonService, PersonManager>();
builder.Services.AddScoped<IInfoService, InfoManager>();

builder.Services.AddScoped<IPersonDal, EfPersonDal>();
builder.Services.AddScoped<IInfoDal, EfInfoDal>();

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
