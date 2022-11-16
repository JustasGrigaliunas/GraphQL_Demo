using AutoMapper;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.RegisterServices();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddPooledDbContextFactory<Context>(opts =>
{
    var connString = builder.Configuration.GetConnectionString("MyConnectionString");
    opts.UseSqlServer(connString, options =>
    {
        options.MigrationsAssembly(typeof(Context).Assembly.FullName!.Split(',')[0]);
    });
});
var app = builder.Build();

var automapper = app.Services.GetRequiredService<IMapper>();

automapper.ConfigurationProvider.AssertConfigurationIsValid();
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
