using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddControllers();
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

app.MapControllers();

app.UseAuthorization();
// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;

//     var context = services.GetRequiredService<DatabaseContext>();

//     context.Database.Migrate();
// }
// using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
// {
//     var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
//     SeedData.Initialize(context);
// }
app.Run();
