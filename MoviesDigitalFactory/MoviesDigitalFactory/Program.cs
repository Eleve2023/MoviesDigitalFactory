using MoviesDigitalFactory.Components;
using System.Net.Http;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddServerComponents()
    .AddWebAssemblyComponents();
builder.Services.AddHttpClient("", client => { 
    client.BaseAddress = new Uri("https://api.themoviedb.org/");
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI2NzUxMTU1Y2QxZDQ1NjczMGJlOTg1OTViY2RlZTQ4NSIsInN1YiI6IjY1MTJkMDY0ZTFmYWVkMDEzYTBjOGYxYyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.eWjXyaDpeLGJPrWFfB_ZnAwjz2NldXIsPxKk4D-6tVM");
    client.Timeout = TimeSpan.FromSeconds(130);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapRazorComponents<App>()
    .AddServerRenderMode()
    .AddWebAssemblyRenderMode();

app.Run();
