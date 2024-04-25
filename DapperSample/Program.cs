var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
        new SqliteConnectionFactory(config["Database:ConnectionString"]));
builder.Services.AddTransient<IDbOperationRepository, DbOperationRepository>();


var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/CallDatabase", () =>
{
    return "";
});

app.Run();
