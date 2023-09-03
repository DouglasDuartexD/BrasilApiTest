using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar a conexão com o banco de dados
builder.Configuration.AddJsonFile("appsettings.json");
builder.Logging.AddConsole();
var connectionString = builder.Configuration.GetConnectionString("BrasilApiDbConn");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<ClimaService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("BrasilApi", client =>
{
    client.BaseAddress = new Uri("https://brasilapi.com.br/api/cptec/v1/");
});

var app = builder.Build();

// Configurar o pipeline de solicitação HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
