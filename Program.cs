using BookStore.Data;
using BookStore.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddDbContext<BookStoreContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("defaults"));
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting(); // Add this line to enable routing

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
