# OptimalBlazorSetup

## My preference on blazor setup

In serverproject: Components->App.razor I always create a "RenderModeForPage" setting. So that I can specify parts of the app that I want to be fully/only SSR pages. When I implement Open Id Connect, Cookie based Auth I usualy put a Login and Logout part here. But can be used for other stuff as well.

## To work with the different rendermodes easily
Then I always setup MagicOnion (with Memorypack as Serializer), then I can use the same services when the app is executed on client (wasm) or server. 

### See WeatherService

The WeatherService is registered in DI on server, and Client. See Program.cs for server and Program.cs for client.

When injecting IWeatherService somewhere on server/that executes on server like SSR pages, or Prerentering "Wasm pages", or in other services then the calls to weatherservice will be local, when injecting IWeatherService somewhere on client/that executes on client (wasm) then every call to weatherservice is done over the network by Grpc using Memorypack as serializer.
