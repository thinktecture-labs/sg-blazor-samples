using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using SharedLibrary;


Console.WriteLine("Program.main entry");

await Task.Delay(1);
Console.WriteLine("After first async call");

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress), });

builder.Services.AddSharedStuff();

Console.WriteLine("Building host");
var host = builder.Build();

// tell JS to display the wait-text and wait a bit
var jsRuntime = host.Services.GetRequiredService<IJSRuntime>();

await jsRuntime.InvokeVoidAsync("window.waitForStartup");
await Task.Delay(TimeSpan.FromSeconds(3));

Console.WriteLine("Starting host");
await host.RunAsync();
