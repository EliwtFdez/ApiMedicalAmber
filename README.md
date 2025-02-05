Este repositorio contiene un ejemplo de cómo leer un archivo JSON de forma centralizada mediante un método de extensión llamado `AddReader`, el cual inyecta la lista de fármacos como un servicio en el contenedor de inyección de dependencias.

## Requisitos previos

- [.NET 6 o superior](https://dotnet.microsoft.com/download)
- Conocimientos básicos sobre inyección de dependencias en .NET
- Conocimientos básicos de Minimal APIs (o ASP.NET Core)

## Estructura del proyecto

El proyecto está organizado de la siguiente manera:

```
MedicalAmberApi/
├── Context/
│   └── farmacoslist.json
├── FarmacosServiceCollectionExtensions.cs
├── Farmaco.cs
├── Program.cs
└── README.md
```

Cómo ejecutar este proyecto
Clona o descarga este repositorio.

Asegúrate de tener instalado .NET 6 o superior.

Desde tu consola favorita, navega hasta la carpeta del proyecto y ejecuta:

bash
```
dotnet run
```
Abre tu navegador y navega a https://localhost:<puerto> (o según la configuración que se muestre en la consola).

Si estás en modo desarrollo, podrás ver la interfaz de Swagger en https://localhost:<puerto>/swagger.



4. Abre tu navegador y navega a `https://localhost:<puerto>` (o según la configuración que se muestre en la consola).  
5. Si estás en modo desarrollo, podrás ver la interfaz de Swagger en `https://localhost:<puerto>/swagger`.  

## Endpoints disponibles

- **GET** `/farmacos`  
  Retorna la lista completa de fármacos.

- **GET** `/farmacos/{numero}`  
  Retorna el fármaco cuyo número coincida con `{numero}`.  
  - Respuestas:
    - `200 OK`: Si el fármaco existe.
    - `404 Not Found`: Si no existe ningún fármaco con ese número.

- **GET** `/farmacos/search?nombre=...`  
  Filtra los fármacos cuyo `FarmacoNombre` contenga la cadena buscada.  
  - Parámetro opcional: `nombre` (string).  
  - Si no se especifica, retorna la lista completa.

- **GET** `/farmacos/porTitular?titular=...`  
  Filtra los fármacos cuyo `Titular` contenga la cadena buscada.  
  - Parámetro opcional: `titular` (string).  
  - Si no se especifica, retorna la lista completa.

## Personalización

- Si tu archivo JSON se encuentra en una ubicación diferente o tiene otro nombre, actualiza la ruta en el método `AddReader("farmacoslist.json")`.  
- Si cambias la estructura de tu objeto JSON, recuerda actualizar la clase `Farmaco` y sus atributos.  
- Puedes modificar la estrategia de registro (`AddSingleton`, `AddScoped`, etc.) en el método `AddReader` dependiendo de tus necesidades de ciclo de vida de la dependencia.

## Contribuir

1. Haz un *fork* del repositorio.  
2. Crea una rama para tu *feature* o *fix* (`git checkout -b feature/nueva-funcionalidad`).  
3. Realiza tus cambios y haz *commit* (`git commit -m 'Añadir nueva funcionalidad'`).  
4. Sube tus cambios a tu repositorio (`git push origin feature/nueva-funcionalidad`).  
5. Crea un *Pull Request* en este repositorio describiendo tus cambios.

## Licencia

Este ejemplo no contiene ninguna licencia explícita. Agrega o modifica este apartado según la licencia deseada (por ejemplo, MIT, Apache 2.0, etc.).

---  

¡Y con esto ya puedes documentar fácilmente cómo utilizar el método `AddReader` y cómo integrarlo en tu proyecto!
