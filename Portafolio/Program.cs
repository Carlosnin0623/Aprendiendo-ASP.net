using Portafolio.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepositorioProyectos, RepositorioProyectos>();

// Tipos de servicios  //


builder.Services.AddTransient<ServicioTransitorio>();

/* Servicio transitorio = AddTransient
   Cada vez que el servicio se solicita, se crea una nueva instancia.
   Se usa para servicios livianos, sin estado, 
   que no necesitan compartir datos entre llamadas. 
 */


builder.Services.AddScoped<ServicioDelimitado>();
/* 
   Servicio delimitado = AddScoped

  * Se crea una instancia por cada request HTTP.
 
  * Dentro de la misma petición, todos los controladores y 
   componentes que lo usen reciben la misma instancia.

   * Al terminar el request, se destruye.
  */


builder.Services.AddSingleton<ServicioUnico>();

/*  Servicio Unico AddSingleton 
 
 *Se crea una sola instancia en toda la aplicación.
 
 * Esa misma instancia se reutiliza durante toda la vida de la app 
  (hasta que se reinicie el servidor).

  * Cuidado: si guarda estado mutable, ese estado es compartido por
   todos los usuarios y requests.
 
 */

/* Servicio Gmail */

builder.Services.AddTransient<IServicioEmail, ServicioEmailGmail>();





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
