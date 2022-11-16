using GraphQL_Demo.Schema.Mutations;
using GraphQL_Demo.Schema.Queries;
using GraphQL_Demo.Schema.Subscriptions;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();

builder.Services
    .AddGraphQLServer()
    .AddQueryType(q=> q.Name("Query"))
    .AddType<RestaurantQuery>()
    .AddType<UserQuery>()
    .AddType<ExampleQuery>()
    .AddMutationType(m=> m.Name("Mutation"))
    .AddType<RestaurantMutation>()
    .AddType<UserMutation>()
    .AddSubscriptionType<Subscription>()
    .AddFiltering();

builder.Services.AddInMemorySubscriptions();
    

builder.Services.AddPooledDbContextFactory<Context>(opts =>
{
    var connString = builder.Configuration.GetConnectionString("MyConnectionString");
    opts.UseSqlServer(connString, options =>
    {
        options.MigrationsAssembly(typeof(Context).Assembly.FullName!.Split(',')[0]);
    });
});

var app = builder.Build();

app.UseWebSockets();

app.MapGraphQL();

app.Run();
