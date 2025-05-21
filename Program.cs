using Microsoft.EntityFrameworkCore;
using TaskManager.Components;
using TaskManager.Service;

//dotnet add package Microsoft.EntityFrameworkCore --> for EF Core support
//dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --> for PostgreSQL support

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); 

builder.Services.AddScoped<BoardService>();
builder.Services.AddSingleton<BoardState>();
builder.Services.AddScoped<TaskListService>();
builder.Services.AddScoped<TaskPriorityService>();
builder.Services.AddScoped<TaskService>();

builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStatusCodePagesWithReExecute("/Error/{0}");

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
