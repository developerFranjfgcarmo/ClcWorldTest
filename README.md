# ClcWorldTest

## Backend con WebApi
### **Estructura:**
ClcWorld.WebApi
**Attributes** __
HandleErrorAttribute. Captura todas las excepciones generadas durante la ejecución de la aplicación. __
ValidateModelStateWebApiAttribute. Permite sobreescribir todas las respuesta cuando se producen errores de validación. __
**Controller** __
Los controladores están organizador por carpetas y contienen: los ViewModels, validaciones (FluentValidation) y los controladores. __
**Handlers** __
ResponseWrappingHandler. Se encarga de procesar todoas las peticiones y devolver los errores de validación. __
**Helpers** __
UnityHelpers. Configuración del Ioc. __
**Mapping.** __

### Paquete Nuget:
- **FluentValidation**. Lo utilizo para validaciones de servidor. Para automatizar las validaciones, se ha creado un Handler que procesa todas las peticiones y realiza las validaciones.
- **AutoMapper**. Para el mapeo de dto a viewmodel y viceversa.
- **Log4net**. Para log de trazas y excepciones. La configuración del log4net está en el web.config. Se han creado tres appender:
- **Unity**. Como inyector de dependencias. Se configura a través del helper ClcWorld.WebApi.Helpers.UnityHelpers.
- **Entity Framework**. Utilizo este ORM para el acceso a datos, configurando los mapeos con fluent api.
- **Dapper. MicroOrm**. Utilizo este paquete porque me permite mas control sobre las consultas que se generan, además de ser más rápido que Entity Framework en el acceso a Datos. Lo he utilizado para los listado de coches y de consecionarios.
- **Microsoft.AspNet.WebApi.Extensions.Compression.Server.** Para comprimir las respuestas.

## Frontend con Angular
