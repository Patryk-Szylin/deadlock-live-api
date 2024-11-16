using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<LiveMatchTrackerService>();
builder.Services.AddSingleton<LiveMatchEventStreamerService>();
builder.Services.AddHostedService<LiveMatchStreamWorker>();
builder.Services.AddSingleton<LiveStreamManager>();


builder.Services.AddControllers();
// Add Redis connection
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var configuration = builder.Configuration.GetConnectionString("Redis") ?? "localhost:6379";
    return ConnectionMultiplexer.Connect(configuration);
});

builder.Services.AddSingleton<LiveMatchEventProducerService>(sp =>
{
    var bootstrapServers = builder.Configuration.GetValue<string>("Kafka:BootstrapServers") ?? "localhost:9092";
    return new LiveMatchEventProducerService(bootstrapServers);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
