using Adform.Academy.Infrastructure.Extensions;
using Adform.Academy.Kudos.Api.MappingProfiles;
using Adform.Academy.Kudos.Application.Extensions;
using static Adform.Academy.Kudos.Api.Middleware.ExceptionHandlingMiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddAutoMapper(typeof(EmployeeMappingProfile));
builder.Services.AddAutoMapper(typeof(KudosMappingProfile));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(o =>
{
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "Adform.Academy.Kudos.Api.xml");
    o.IncludeXmlComments(filePath);
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

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
