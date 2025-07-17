# Q10.Web

Repositorio: [https://github.com/DidierAvila/Q10.Web](https://github.com/DidierAvila/Q10.Web)

## Descripción

**Q10.Web** es una solución modular basada en .NET 8 que implementa una arquitectura limpia (Clean Architecture) para la gestión de estudiantes, materias e inscripciones. El proyecto está organizado en capas separadas para dominio, aplicación, infraestructura, presentación web y pruebas, facilitando la mantenibilidad, escalabilidad y testeo.

## Estructura del Proyecto

```
Q10.Web/
│
├── Q10.Domain/           # Entidades del dominio, DTOs y validadores
│   ├── Entities/
│   ├── Dtos/
│   └── Validator/
│
├── Q10.Application/      # Lógica de aplicación, comandos, queries y handlers
│   ├── Students/
│   ├── Subjects/
│   └── SubjectRegistrations/
│
├── Q10.Infrastructure/   # Acceso a datos, DbContext, migraciones y repositorios
│   ├── DbContexts/
│   ├── Migrations/
│   └── Repositories/
│
├── Q10.Web/              # Proyecto ASP.NET Core MVC (presentación)
│   ├── Controllers/
│   ├── Models/
│   ├── Views/
│   └── wwwroot/
│
├── Test/                 # Proyecto de pruebas unitarias (xUnit)
│   ├── Student/
│   ├── Subjects/
│   └── UnitTest1.cs
│
└── Q10.Web.sln           # Solución principal
```

## Principales Tecnologías

- **.NET 8**
- **ASP.NET Core MVC**
- **Entity Framework Core**
- **FluentValidation** (validación de entidades)
- **xUnit** (pruebas unitarias)
- **MediatR** (CQRS y mediación de comandos/queries)

## Características

- Gestión de estudiantes, materias e inscripciones.
- Arquitectura limpia: separación clara de responsabilidades.
- Validaciones robustas con FluentValidation.
- Pruebas unitarias para lógica de dominio y validaciones.
- Migraciones de base de datos con Entity Framework Core.

## Aplicación de Patrones y Principios SOLID

El proyecto Q10.Web aplica los principios SOLID y patrones de diseño para garantizar un código mantenible, escalable y fácil de probar:

### Principios SOLID
- **S (Single Responsibility Principle):** Cada clase y capa tiene una única responsabilidad. Por ejemplo, los controladores solo gestionan la lógica de presentación, los handlers de aplicación gestionan la lógica de negocio y los repositorios el acceso a datos.
- **O (Open/Closed Principle):** Las clases están abiertas a extensión pero cerradas a modificación. Se logra mediante el uso de interfaces y la inyección de dependencias.
- **L (Liskov Substitution Principle):** Las implementaciones pueden ser reemplazadas por sus abstracciones sin afectar el funcionamiento del sistema. Por ejemplo, los repositorios implementan interfaces genéricas.
- **I (Interface Segregation Principle):** Se crean interfaces específicas para cada contexto, evitando interfaces grandes y poco cohesionadas.
- **D (Dependency Inversion Principle):** Las capas superiores dependen de abstracciones, no de implementaciones concretas. Se utiliza inyección de dependencias en toda la solución.

### Patrones de Diseño Aplicados
- **Clean Architecture:** Separación en capas (Dominio, Aplicación, Infraestructura, Presentación) para desacoplar reglas de negocio de detalles de infraestructura.
- **Repository Pattern:** Los repositorios abstraen el acceso a datos, permitiendo cambiar la fuente de datos sin afectar la lógica de negocio.
- **CQRS (Command Query Responsibility Segregation):** Separación de operaciones de consulta y comando usando MediatR.
- **Dependency Injection:** Todas las dependencias se inyectan a través de los constructores, facilitando el testeo y la extensión.
- **Validation Pattern:** Uso de FluentValidation para centralizar y desacoplar las reglas de validación del dominio.

## Primeros Pasos

### Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (o modificar el provider en `Q10.Infrastructure`)
- Visual Studio 2022+ o VS Code

### Configuración

1. **Clona el repositorio:**
   ```bash
   git clone https://github.com/DidierAvila/Q10.Web.git
   cd Q10.Web
   ```

2. **Restaura los paquetes NuGet:**
   ```bash
   dotnet restore
   ```

3. **Configura la cadena de conexión** en `Q10.Web/appsettings.json` y/o `Q10.Infrastructure/DbContexts/Q10DbContext.cs`.

4. **Aplica las migraciones:**
   ```bash
   dotnet ef database update --project Q10.Infrastructure --startup-project Q10.Web
   ```

5. **Ejecuta la aplicación:**
   ```bash
   dotnet run --project Q10.Web
   ```

### Ejecutar Pruebas

```bash
dotnet test
```

## Estructura de Carpetas

- **Q10.Domain**: Entidades principales (`Student`, `Subject`, `SubjectRegistration`), DTOs y validadores (`SubjectValidator`).
- **Q10.Application**: Lógica de negocio, comandos y queries para estudiantes, materias e inscripciones.
- **Q10.Infrastructure**: Implementación de repositorios, DbContext y migraciones.
- **Q10.Web**: Controladores MVC, vistas Razor y recursos estáticos.
- **Test**: Pruebas unitarias con xUnit y FluentValidation.TestHelper.

## Ejemplo de Validación

Las entidades usan FluentValidation para reglas de negocio. Ejemplo para `Subject`:

```csharp
public class SubjectValidator : AbstractValidator<Subject>
{
    public SubjectValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre es obligatorio")
            .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres");
        // ... otras reglas
    }
}
```

## Inspiración

Este proyecto se inspira en los principios de [Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture/blob/main/README.md) para lograr una solución desacoplada, testeable y fácil de mantener.

## Contribuciones

¡Las contribuciones son bienvenidas! Por favor, abre un issue o pull request para sugerencias o mejoras. 