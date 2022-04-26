using iknow_project.Models;
using iknow_project.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.Configure<ShoppingDatabaseSettings>(
    builder.Configuration.GetSection("ShoppingDatabase"));

builder.Services.AddSingleton<ShoppingService>();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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


