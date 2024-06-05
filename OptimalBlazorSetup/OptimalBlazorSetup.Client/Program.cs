using Grpc.Net.Client.Web;
using Grpc.Net.Client;
using MagicOnion.Client;
using MagicOnion.Serialization.MemoryPack;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OptimalBlazorSetup.Client.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<GrpcChannel>(x => GrpcChannel.ForAddress(builder.HostEnvironment.BaseAddress, new GrpcChannelOptions
{
    HttpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler())
}));

//Register services to be able to used on client side
builder.Services.AddScoped<IWeatherForecastService>(o => MagicOnionClient.Create<IWeatherForecastService>(o.GetRequiredService<GrpcChannel>(), MemoryPackMagicOnionSerializerProvider.Instance));

await builder.Build().RunAsync();
