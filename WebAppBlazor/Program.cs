using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAppBlazor;
using WebAppBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<HttpHelper>();
builder.Services.AddTransient(x => new HttpClient { BaseAddress = new Uri("https://localhost:7123") });

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();