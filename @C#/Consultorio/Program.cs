using Consultorio.Data;
using Consultorio.Repository;
using Consultorio.Repository.Interfaces;
using Consultorio.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// NewTonsoftJson = Para poder usar o Include nos relacionamentos e funcionar sem erro
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

// CONFIGURAÇÃO PARA O AUTO MAP QUE UTILIZAMOS NA DTO
builder.Services.AddAutoMapper(typeof(Program));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CRIA O CORS PARA LIBERAR A APLICAÇÃO PARA UTILIZAÇÃO EM OUTROS LOCAIS EXEMPLO NO FRONT
builder.Services.AddCors();

// METODO PEGAR ALGUMA KEY DO APPSENTINGS
// var configuracao = builder.Configuration["KeyDeConexao"];


// LIGAÇÃO COM BANCO DE DADOS
builder.Services.AddDbContext<ConsultorioContext>(options =>
{
    // FAZENDO A LIGAÇÃO COM POSTGRES ATRAVÉS DO PACOTE NPGSQL FRAMEWORK
    // USAMOS A CONEXÃO DEFAULT QUE BOTAMOS LÁ NO APPSETTINGS.DEVELOPMENT
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"),

    // BUSCANDO AS CONFIGURAÇÕES DO ASSEMBLY NA CONTEXT
    assembly => assembly.MigrationsAssembly(typeof(ConsultorioContext).Assembly.FullName)



    );
});


// FAZENDO A INJEÇÃO DE DEPENDENCIA DA INTERFACE EMAIL PARA A NOSSA SERVICE DE EMAIL
builder.Services.AddScoped<IEmailService, EmailService>();

// INJEÇÃO DE DEPENDENCIA PARA AS REPOSITORY BASE
builder.Services.AddScoped<IBaseRepository, BaseRepository>();

// INJEÇAÕ DE DEPENDENCIA PARA PACIENTE
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();

// INJEÇAÕ DE DEPENDENCIA PARA PROFISSIONAIS
builder.Services.AddScoped<IProfissionalRepository, ProfissionalRepository>();


var app = builder.Build();

// Middleware
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// AGORA UTILIZAMOS O CORS PARA LIBERAR NOSSO BACK PARA QUALQUER LUGAR
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.MapControllers();

app.Run();
