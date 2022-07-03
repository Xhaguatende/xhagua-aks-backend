using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Xhagua.Aks.Backend.Api.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
}).AddJsonOptions(options =>
{
    var enumConverter = new JsonStringEnumConverter();
    options.JsonSerializerOptions.Converters.Add(enumConverter);
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

//builder.Services.AddDbContext<XhaguaContext>(options =>
//    options.UseInMemoryDatabase(databaseName: "Mock DB"));

builder.Services.AddDbContext<XhaguaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();