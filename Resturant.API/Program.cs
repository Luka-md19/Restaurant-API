using Microsoft.EntityFrameworkCore;
using Resturant.API.Configurations;
using Resturant.API.Contract;
using Resturant.API.Data;
using Resturant.API.Middleware;
using Resturant.API.Repository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ResturantDbConnectionString");
builder.Services.AddDbContext<ResturantDbContext>(options => {
    options.UseSqlServer(connectionString);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
        b => b.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod());
});
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .ReadFrom.Configuration(ctx.Configuration));
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IMenuCategories, MenuCategories>();
builder.Services.AddScoped<IMenuItems, MenuItems>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<ISpecialOffersRepository, SpecialOffersRepository>();
builder.Services.AddScoped<IItemDescriptionRepository, ItemDescriptionRepository>();
builder.Services.AddScoped<IAccountConfigurations, AccountConfigurationsRepository>();
builder.Services.AddScoped<IRestaurantDataRepository, RestaurantDataRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();


app.Run();
