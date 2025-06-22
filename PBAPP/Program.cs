using PBAPP.Herramientas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddSession(); 
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ManejoSesion>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=InicioSesion}/{action=IniciarSesion}");
app.UseAuthorization();

app.MapRazorPages();
app.UseSession();

app.Run();
