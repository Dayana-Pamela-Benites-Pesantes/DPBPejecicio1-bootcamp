using Bootcamp.Queries.DocumentType;
using Bootcamp.Queries.Person;
using Bootcamp.Repository;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.Configure<ApiBehaviorOptions>(option =>
{
    option.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddTransient<IDocumentTypeQueries, DocumentTypeQueries>();
builder.Services.AddTransient<IPersonQueries, PersonQueries>();
builder.Services.AddTransient<IPersonRepository, PersonRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
