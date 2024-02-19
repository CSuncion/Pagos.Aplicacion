using Pagos.Api.Middleware;
using Pagos.Aplicacion;
using Pagos.Infraestructura;
using Steeltoe.Extensions.Configuration.ConfigServer;
using Pagos.Api.Middleware; 
using Pagos.Api.Configuraciones;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.AddConfigServer(
    LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
    })
    );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();

var connectionString = builder.Configuration["dbPagos-cnx"];
builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddHealthCheckConfiguration(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthCheckConfiguration();

//Adicionar middleware customizado para tratar las excepciones
app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
