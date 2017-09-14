# ClcWorldTest

## Backend con WebApi
### **Estructura:**  
#### ClcWorld.WebApi  
**Attributes**  
HandleErrorAttribute. Captura todas las excepciones generadas durante la ejecución de la aplicación.  
ValidateModelStateWebApiAttribute. Permite sobreescribir todas las respuesta cuando se producen errores de validación.  
**Controller**  
Los controladores están organizador por carpetas y contienen: los ViewModels, validaciones (FluentValidation) y los controladores.  
**Handlers**  
ResponseWrappingHandler. Se encarga de procesar todoas las peticiones y devolver los errores de validación.  
**Helpers**  
UnityHelpers. Configuración del Ioc.  
**Mapping.**  
#### ClcWorld.Config
Permite leer el archivo de web.config, la cargar las variables de la aplicación.
#### ClcWorld.Utils
Contiene utilidades para poder utilizarse entre las diferente capas, como MappingExtension, que permite mapear de entity a dto y viceversa.
#### ClcWorld.Dtos
Este proyecto sólo contiene clases, que son las utilizadas para viajar desde la capa de servicios a la WebApi y de aquí al cliente de Angular.
#### ClcWorld.Entities
Este proyecto contiene el modelo de datos, se ha utilizado entity framework code first con fluent Api. 
Todas las entidades modificadas, se almacenan en la tabla Audits. En esta tabla se almacena, la acción realizada (añadir, borrar, modificar), la entidad y la primary key del registro afectado.
#### ClcWorld.Service
Contiene la lógica de negocio de la aplicaicón.
### Paquete Nuget:
- **FluentValidation**. Lo utilizo para validaciones de servidor. Para automatizar las validaciones, se ha creado un Handler que procesa todas las peticiones y realiza las validaciones.
- **AutoMapper**. Para el mapeo de dto a viewmodel y viceversa.
- **Log4net**. Para log de trazas y excepciones. La configuración del log4net está en el web.config. Se han creado tres appender:
- **Unity**. Como inyector de dependencias. Se configura a través del helper ClcWorld.WebApi.Helpers.UnityHelpers.
- **Entity Framework**. Utilizo este ORM para el acceso a datos, configurando los mapeos con fluent api.
- **Dapper. MicroOrm**. Utilizo este paquete porque me permite mas control sobre las consultas que se generan, además de ser más rápido que Entity Framework en el acceso a Datos. Lo he utilizado para los listado de coches y de consecionarios.
- **Microsoft.AspNet.WebApi.Extensions.Compression.Server.** Para comprimir las respuestas.

## Frontend con Angular
### **Estructura:** 
#### App  
Los controladores y servicios se agrupan por cada funcionalidad de la aplicación:  
+-- App  
|   +-- Car  
    |   +-- Controller  
    |   +-- Modal  
    |   +-- Services  
    |   +-- carList.html  
|   +-- Content  
|   +-- fonts  
|   +-- Script  
+-- ClcWorldConfig.js  # configuración de la aplicación, se almacena la dirección de la api.  
+-- ClcWorldApp.js  # Inicio de la aplicación y configuración de los servicios y directivas.    
+-- index.html  # Página de inicio  

### **Librerias:** 
Angular  
angular-ui-router  
ui-bootstrap.min.  
angular-animate.min  

