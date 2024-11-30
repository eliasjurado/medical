using Medical.Resource;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddBootstrapBlazor(op =>
{
    op.DefaultCultureInfo = Constants.LANGUAGE_SPANISH_PERU;
    op.IgnoreLocalizerMissing = true;
});

builder.Services.AddTableDemoDataService();

await builder.Build().RunAsync();
