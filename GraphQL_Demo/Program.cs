using GraphQL_Demo;
using GraphQL_Demo.Schema.Mutations;
using GraphQL_Demo.Schema.Queries;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();

builder.Services
    .AddGraphQLServer()
    .AddQueryType(q=> q.Name("Query"))
    .AddType<Query>()
    .AddType<UserQuery>()
    .AddMutationType(m=> m.Name("Mutation"))
    .AddType<Mutation>()
    .AddType<UserMutation>();

builder.Services.AddPooledDbContextFactory<Context>(opts =>
{
    var connString = builder.Configuration.GetConnectionString("MyConnectionString");
    opts.UseSqlServer(connString, options =>
    {
        options.MigrationsAssembly(typeof(Context).Assembly.FullName.Split(',')[0]);
    });
});





var app = builder.Build();

app.MapGraphQL();

app.Run();
