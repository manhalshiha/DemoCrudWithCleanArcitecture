using Infrastructure.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureService(builder.Configuration);
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("WebUI", policyBuilder =>
//    {
//        policyBuilder.WithOrigins("https://localhost:7299");
//        policyBuilder.AllowAnyHeader();
//        policyBuilder.AllowAnyMethod();
//        policyBuilder.AllowCredentials();
//    });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("WebUI");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
