using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MusicPlatform.Business.Services;
using MusicPlatform.DataLayer;
using MusicPlatform.DataLayer.Repositories;
using MusicPlatformAPI.Filters;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Authentication & Authorization
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,

        ValidIssuer = "MusicPlatformAPI-Backend",
        ValidAudience = "MusicPlatformAPI-Client",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecurityKey"]))
    };
});
builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ArtistNotFoundExceptionFilter());
    options.Filters.Add(new SongNotFoundExceptionFilter());
    options.Filters.Add(new AlbumNotFoundExceptionFilter());
    options.Filters.Add(new SingleNotFoundExceptionFilter());
    options.Filters.Add(new PlaylistNotFoundExceptionFilter());
    options.Filters.Add(new EpNotFoundExceptionFilter());
});

builder.Services.AddDbContext<MusicDbContext>();
builder.Services.AddScoped<UnitOfWork>();

builder.Services.AddScoped<AuthorizationService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<ArtistService>();
builder.Services.AddScoped<SongService>();
builder.Services.AddScoped<AlbumService>();
builder.Services.AddScoped<SingleService>();

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ArtistRepository>();
builder.Services.AddScoped<SongRepository>();
builder.Services.AddScoped<SingleRepository>();
builder.Services.AddScoped<AlbumRepository>();
builder.Services.AddScoped<PlaylistRepository>();
builder.Services.AddScoped<EPRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Example: 'Bearer {token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
