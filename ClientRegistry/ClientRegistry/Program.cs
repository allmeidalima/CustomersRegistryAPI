using Client.DBO.Context;
using ClientRegistry.API.Interface;
using ClientRegistry.API.Models;
using ClientRegistry.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var conect = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PrjContext>(options =>
{
    options.UseSqlServer(conect, sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
    });
});

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IGetCustomersService, CustomerService>();
builder.Services.Decorate<ICustomerService, FieldValidation>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

using (IServiceScope scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    scope.ServiceProvider.GetService<PrjContext>().Database.Migrate();
}

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
