using System.Reflection.Metadata;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using API_Filmes_SENAI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<Filme_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

.AddJwtBearer("JwtBearer", options =>
  {
      options.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuer = true,

          ValidateAudience = true,

          ValidateLifetime = true,

          //forma de criptografia e valida chave de autenticacao
          IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filme-chaver-autenticacao-webapi-dev")),

          //valida o tempo de expiracao do token
          ClockSkew = TimeSpan.FromMinutes(5),

          //valida de onde esta vindo
          ValidIssuer = "api_filmes_senai",

          ValidAudience = "api_filmes_senai",

      };
  });
var app = builder.Build();

//adicionar o mapeamento dos controllers
app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();


app.Run();

