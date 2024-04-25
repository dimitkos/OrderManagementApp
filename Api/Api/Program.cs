using Api.GraphQL;
using Core.Interfaces;
using GraphQL.Server.Ui.Voyager;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var AllowSpecificOrigins = "_allowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<OrderManagementContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddFiltering();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors(AllowSpecificOrigins);

app.MapGraphQL();
app.UseGraphQLVoyager("/graphql-voyager", new VoyagerOptions { GraphQLEndPoint = "/graphql" });

//Migrate Database
try
{
    var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<OrderManagementContext>();
    context.Database.Migrate();
}
catch (Exception ex)
{

    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex,"An error occured during migration");
}

app.Run();
