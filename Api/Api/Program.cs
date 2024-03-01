using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#warning add more elegant way to retrieve  the connection string
builder.Services.AddDbContextFactory<OrderManagementContext>(options =>
{
    options.UseInMemoryDatabase("InMemoryDb");
});

var app = builder.Build();


app.Run();
