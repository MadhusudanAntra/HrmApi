using Hrm.ApplicationCore.Contract.Repository;
using Hrm.ApplicationCore.Contract.Service;
using Hrm.Infrastructure.Data;
using Hrm.Infrastructure.Repository;
using Hrm.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<HrmDbContext>(options => {

    options.UseSqlServer(builder.Configuration.GetConnectionString("HrmApiDb"));
    
});

builder.Services.AddScoped<ICandidateServiceAsync, CandidateServiceAsync>();



builder.Services.AddScoped<ICandidateRepositoryAsync, CandidateRepositoryAsync>();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting(); //middleware allows to use routing
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });  //this will map the request to the particular controller

app.Run();

