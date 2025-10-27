using ManejoPresupuesto.Servicios;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
/* Servicio Transitorio para la interfaz tipo Cuentas */
builder.Services.AddTransient<IRepositorioTiposCuentas, RepositorioTiposCuentas>();

/* Servicio para obtener usuario id Temportal */
builder.Services.AddTransient<IServicioUsuarios, ServicioUsuarios>();

/* Servicio para Tabla Cuenta */
builder.Services.AddTransient<IRepositorioCuentas, RepositorioCuentas>();

/* Repositorio Categorias */
builder.Services.AddTransient<IRepositorioCategorias, RepositorioCategorias>();

/* Configurando Mapeador */

builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
