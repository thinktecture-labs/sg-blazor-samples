using BlazorWasmHost;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using SharedLibrary;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress), });

builder.Services.AddSharedStuff();

var host = builder.Build();

// tell JS to display the wait-text and wait a bit
var jsRuntime = host.Services.GetRequiredService<IJSRuntime>();
await jsRuntime.InvokeVoidAsync("window.waitForStartup");
await Task.Delay(TimeSpan.FromSeconds(3));

await host.RunAsync();
