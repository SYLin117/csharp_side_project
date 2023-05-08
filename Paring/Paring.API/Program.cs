using Microsoft.EntityFrameworkCore;
using Paring.Core.Contracts.Repositories;
using Paring.Core.Contracts.Services;
using Paring.Infra.Data;
using Paring.Infra.Repositories;
using Paring.Infra.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// custom service
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DbConnection");
// Inject our ConnectionString into DbContext
// Console.WriteLine($"connectionString: {connectionString}");
builder.Services.AddDbContext<ParingDbContext>(
    options => options.UseSqlServer(connectionString)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();