using BlazorExamples;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddFluxor(o =>
{
	o.ScanAssemblies(typeof(Program).Assembly);
	o.UseReduxDevTools(ro =>
	{
		ro.Name = "SG Blazor Samples";
	});
});

builder.Services.AddMudServices();
builder.Services.AddScoped(sp => new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress), });

var host = builder.Build();

// tell JS to display the wait-text and wait a bit
var jsRuntime = host.Services.GetRequiredService<IJSRuntime>();
await jsRuntime.InvokeVoidAsync("window.waitForStartup");
await Task.Delay(TimeSpan.FromSeconds(3));

await host.RunAsync();
