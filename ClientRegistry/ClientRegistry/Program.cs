using Client.DBO.Context;
using ClientRegistry.API.Interface;
using ClientRegistry.API.Models;
using ClientRegistry.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false);

builder.Services.AddDbContext<PrjContext>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IGetCustomersService, CustomerService>();
builder.Services.AddScoped<IInformantionsCustomersService, CustomerService>();
builder.Services.AddScoped<FieldValidation>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting(); // Configure routing before other middleware

if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI only in development environment
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Use authentication before authorization
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
