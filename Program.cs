using url_shortener.Profiles;
using url_shortener.Repositories;
using url_shortener.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add mapping profiles
builder.Services.AddAutoMapper(typeof(ShortUrlMappingProfile));

// Register the services
builder.Services.AddSingleton<IShortUrlRepository, ShortUrlRepository>();
builder.Services.AddSingleton<ShortUrlService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
