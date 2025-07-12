var builder = WebApplication.CreateBuilder(args);

// Registrar servicios de Blazor y Razor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Servicios HTTP externos (APIs)
builder.Services.AddHttpClient<ProductService>();

builder.Services.AddHttpClient<WeatherService>(client =>
{
    client.BaseAddress = new Uri("https://api.openweathermap.org/");
});

// Servicios internos (singleton en memoria)
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CartService>();

builder.Services.AddSingleton<AuthService>();
builder.Services.AddScoped<WeatherService>();


var app = builder.Build();

// Configuración estándar de Blazor Server
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
