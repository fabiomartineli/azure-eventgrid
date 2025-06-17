using Api.Database;
using Api.Services.EventGridPublisher;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddLogging();
builder.Services.AddSingleton<IEventGridPublisher, EventGridPublisher>(x => new(builder.Configuration.GetValue<string>("EventGrid:AccessKey"), builder.Configuration.GetValue<string>("EventGrid:Endpoint")));
builder.Services.AddSingleton<IDatabaseClient, DatabaseClient>(x => new(builder.Configuration.GetValue<string>("Mongodb:Connectionstring")));
builder.Services.AddScoped<IDatabaseContext, DatabaseContext>(x => new(x.GetRequiredService<IDatabaseClient>(), builder.Configuration.GetValue<string>("Mongodb:Database")));

var app = builder.Build();
app.MapOpenApi();
app.UseAuthorization();
app.MapControllers();
app.Run();
