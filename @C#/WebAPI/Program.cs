using WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using WebAPI.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CRIA A CONEXAO COM O BANCO DE DADOS QUE FOI SETADA LÁ NO APPSETINGS.DEVE
builder.Services.AddDbContext<UsuarioContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")
    );
}
);

// PARA HABILITAR A INJEÇÃO DE DEPENDENCIA 
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

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
