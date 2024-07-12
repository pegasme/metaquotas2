using MetaQuotes.IpSearch.Managers;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();
builder.Services.AddLogging();

var dataFilePath = builder.Configuration.GetValue<string>("FilePath");

if (string.IsNullOrWhiteSpace(dataFilePath))
    throw new Exception($"File path is empty");

builder.Services.AddSingleton<IDataRepository>(sp =>
{
    var loggingService = sp.GetRequiredService<ILogger<DataRepository>>();
    return new DataRepository(dataFilePath, loggingService);
});

builder.Services.AddSingleton<IIpManager, IpManager>();
builder.Services.AddSingleton<ICityManager, CityManager>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Logger.LogInformation("Start application");
app.Run();
