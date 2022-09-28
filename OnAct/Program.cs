using OnAct.Data;
using OnAct.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OnActContext>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
//rep
builder.Services.AddTransient<IActivitiesRepository, ActivitiesRepository>();
builder.Services.AddTransient<IPlacesRepository, PlacesRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World two!");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
