# Entrevista ASP Net Core

## Api Rest (15')

1. Efectuar las modificaciones necesarias en WebApi1.Controllers.ClientesController.cs para verfificar las pruebas disponibles en ./WebApi1.Test

   * DeberiaExistirRecursoClientes
   * DeberiaObtenerClientes
   * DeberiaObtenerUnCliente
   * NoDeberiaObtenerClientes
   * NoDeberiaObtenerUnCliente

```bash
dotnet test ./WebApi1.Test
```

2. Configurar la resolución de WebApi1.Models.IClientesService como WebApi1.Models.ClientesService en el pipeline de servicios de la api WebApi1

## Imagen de la app (10')

1. Publicar la versión release de la webapi1 mediante
  
```bash
dotnet publish -c Release ./WebApi1 -o app
```

2. Crear el archivo Dockerfile para poder crear la imagen webapi1:1.0 con los resultados de la publicación en ./app. Tomar como imagen base mcr.microsoft.com/dotnet/core/aspnet.

```bash
docker build -t webapi1:1.0 .
```

3. Ejecutar la app en un contenedor mediante

```bash
docker run --rm -p 8080:80 webapi1:1.0
```

## Creación del servicio (10')

1. Crear el archivo docker-compose.yml para crear el servicio service-1 que ejecute 2 replicas de la app.  

2. Ejecutar el servicio mediante...

```bash
docker swarm init
docker stack deploy --compose-file docker-compose.yml service-1
```
