using FuncionariosEmpresa.Api;
using FuncionariosEmpresa.Api.Dados;
using FuncionariosEmpresa.Core.Dtos;
using FuncionariosEmpresa.Core.Profiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var conString = builder.Configuration.GetConnectionString("ConexaoPadrao");

builder.Services.AddDbContext<FuncionariosContext>(
    opts => opts.UseSqlServer(conString));


builder.Services.AddAutoMapper(typeof(FuncionariosProfile));
builder.Services.AddAutoMapper(typeof(AtualizaFuncionarioDto));
builder.Services.AddAutoMapper(typeof(ExibeFuncionarioDto));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


// Add services to the container. 

builder.Services.AddControllers();
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

app.UseCors("AllowBlazorApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
