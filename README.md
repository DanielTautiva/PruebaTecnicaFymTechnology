# PRUEBA TECNICA FYM TECHNOLOGY


## Tecnologías Utilizadas

- ASP.NET Core v7.0
- C# 

## Configuración del Proyecto
- [.NET Core SDK](https://dotnet.microsoft.com/download)

config appsettings.json 
La conexion esta con "ConnectionSQL"

### Clonar el Repositorio

```bash
git clone https://github.com/DanielTautiva/PruebaTecnicaFymTechnology

### SQL SERVER scripts 
CREATE DATABASE FymTechnology;
GO

### Generate migration desde la consola de administracion de paquetes NuGet comando:
update-database

### Documentacion Swagger v1.0 

Auth Methods

POST
/api/Auth/register

POST
/api/Auth/login

User Methods

GET
/api/User/list

GET
/api/User/{id}

PATCH
/api/User/{id}

DELETE
/api/User/{id}
