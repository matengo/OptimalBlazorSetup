using MagicOnion.Serialization.MemoryPack;
using OptimalBlazorSetup.Client.Interfaces;
using OptimalBlazorSetup.Client.Pages;
using OptimalBlazorSetup.Components;
using OptimalBlazorSetup.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddGrpc();
builder.Services.AddMagicOnion(x => x.MessageSerializer = MemoryPackMagicOnionSerializerProvider.Instance);

//Register services to be able to used on server side
builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(OptimalBlazorSetup.Client._Imports).Assembly);
    //Add authorization if needed
    //.RequireAuthorization();

app.UseGrpcWeb();
app.MapMagicOnionService()
    .EnableGrpcWeb();
    //Add authorization if needed
    //.RequireAuthorization();

app.Run();
