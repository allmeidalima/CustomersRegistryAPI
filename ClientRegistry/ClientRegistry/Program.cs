using Client.DBO.Context;
using ClientRegistry.API.Interface;
using ClientRegistry.API.Models;
using ClientRegistry.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var conect = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PrjContext>(options =>
                options.UseSqlServer(conect));

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IGetCustomersService, CustomerService>();
builder.Services.Decorate<ICustomerService, FieldValidation>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();


app.UseRouting();

if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
