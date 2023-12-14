using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Movies.Models;
using Movies.Repository;
using Movies.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionstring = builder.Configuration.GetConnectionString(
    name: "DefaultConnection");
builder.Services.AddDbContext<ApplicationDBContext>(
    options=>options.UseSqlServer(connectionstring));
builder.Services.AddTransient<IGenreService,GenreService>();
builder.Services.AddTransient<IMovieService,MovieService>();

builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();

builder.Services.AddControllers();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=> 
{
    options.SwaggerDoc(name: "v1", info: new OpenApiInfo
    {
        Version = "v1",
        Title = "MahmoudApi",
        Description="my first api",
        Contact= new OpenApiContact 
        {
            Name="Mahmoud",
            Email="me974931@gmail.com",
            Url=new Uri(uriString: "https://www.google.com")
        }
    });
   




    //options.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "Bearer"
    //            },
    //            Name = "Bearer",
    //            In = ParameterLocation.Header
    //        },
    //        new List<string>()
    //    }
    //});
});



       
       
    


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c=>c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
    
    );

app.UseAuthorization();

app.MapControllers();

app.Run();
