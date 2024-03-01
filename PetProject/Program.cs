using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PetProject;
using PetProject.Components;


var builder = WebApplication.CreateBuilder(args);

var defaultConnection = builder.Configuration["Connections:ConnectionString"];

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllers();

builder.Services.AddMediatR(c => 
    c.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = " API",
        Description="API for the  Server",
    });

});

builder.Services.AddDbContext<AppDbContext>(o 
    => o.UseNpgsql(defaultConnection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}");

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
});

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();