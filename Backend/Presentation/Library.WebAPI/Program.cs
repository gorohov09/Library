using Library.Application.Interfaces;
using Library.Application.Services;
using Library.DAL.Context;
using Library.DAL.Interfaces;
using Library.DAL.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<LibraryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Repository
services.AddScoped<IBookRepository, BookRepository>();
services.AddScoped<IAccountRepository, AccountRepository>();
services.AddScoped<IReaderRepository, ReaderRepository>();
services.AddScoped<ILibrarianRepository, LibrarianRepository>();
services.AddScoped<IOrderRepository, OrderRepository>();
services.AddScoped<IRecordRepository, RecordRepository>();

//Services
services.AddScoped<IBookService, BookService>();
services.AddScoped<IAccountService, AccountService>();
services.AddScoped<IOrderService, OrderService>();
services.AddScoped<IReaderService, ReaderService>();
services.AddScoped<ILibrarianService, LibrarianService>();

// AutoMapper
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
