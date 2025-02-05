using Microsoft.OpenApi.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Agregamos Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Medical Amber API", Version = "v1" });
});

var app = builder.Build();

// Configuración de Swagger en modo desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Medical Amber API v1");
    });
}

app.UseHttpsRedirection();

// Leemos el archivo JSON
var jsonPath = Path.Combine(AppContext.BaseDirectory, "./Context/farmacoslist.json");

string jsonContent = File.ReadAllText(jsonPath);

List<Farmaco>? farmacos = JsonSerializer.Deserialize<List<Farmaco>>(jsonContent)
                          ?? new List<Farmaco>();

// Endpoint para obtener todos los fármacos
app.MapGet("/farmacos", () =>
{
    return farmacos;
})
.WithName("GetAllFarmacos");

// Endpoint para obtener un fármaco por "numero" (path param)
app.MapGet("/farmacos/{numero}", (string numero) =>
{
    var resultado = farmacos.FirstOrDefault(f => f.Numero == numero);
    return resultado is not null ? Results.Ok(resultado) : Results.NotFound();
})
.WithName("GetFarmacoByNumero");

// Endpoint para filtrar por "farmaco" (query param, por ejemplo)
app.MapGet("/farmacos/search", (string? nombre) =>
{
    if (string.IsNullOrWhiteSpace(nombre))
        return Results.Ok(farmacos);

    // Filtramos por nombre del fármaco (ignorando mayúsculas/minúsculas)
    var resultado = farmacos
        .Where(f => f.FarmacoNombre != null && 
                    f.FarmacoNombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
        .ToList();

    return Results.Ok(resultado);
})
.WithName("SearchFarmacoByNombre");

// Endpoint para filtrar por varias propiedades (por ejemplo "titular")
app.MapGet("/farmacos/porTitular", (string? titular) =>
{
    if (string.IsNullOrWhiteSpace(titular))
        return Results.Ok(farmacos);

    var resultado = farmacos
        .Where(f => f.Titular != null && 
                    f.Titular.Contains(titular, StringComparison.OrdinalIgnoreCase))
        .ToList();

    return Results.Ok(resultado);
})
.WithName("SearchFarmacoByTitular");

app.Run();

