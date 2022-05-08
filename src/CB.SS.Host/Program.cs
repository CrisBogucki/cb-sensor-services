using CB.SensorService.Src.Application;
using CB.SensorService.Src.Host;
using CB.SensorService.Src.Host.Configuration;
using CB.SS.Host.Configuration;


var builder = WebApplication.CreateBuilder(args);

//builder.Host.AddConfigureSeqMonitoring();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();
builder.Services.AddCfgServices();
builder.Services.AddConfigureServices();

// remove info by server name
builder.WebHost.ConfigureKestrel(x => x.AddServerHeader = false);

var app = builder.Build();

app.AddConfigureExceptionServices();
app.UseEnvironmentByProfile();

Console.WriteLine("cos idzie " +app.Environment.EnvironmentName);
if (app.Environment.EnvironmentName != "prod")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();