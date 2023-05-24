using MusicPlatform.Business.Services;
using MusicPlatform.DataLayer;
using MusicPlatform.DataLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MusicDbContext>();
builder.Services.AddScoped<UnitOfWork>();

builder.Services.AddScoped<AuthorizationService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<ArtistService>();

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ArtistRepository>();
builder.Services.AddScoped<SongRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
