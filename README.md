[![](https://img.shields.io/nuget/v/soenneker.coordinators.entities.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.coordinators.entities/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.coordinators.entities/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.coordinators.entities/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.coordinators.entities.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.coordinators.entities/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.coordinators.entities/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.coordinators.entities/actions/workflows/codeql.yml)

# Soenneker.Coordinators.Entities

Defines a generic CRUD coordinator contract and an abstract base class for application-specific entity coordinators.

## Install

```bash
dotnet add package Soenneker.Coordinators.Entities
```

## Implement a coordinator

```csharp
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.Coordinators.Entities;
using Soenneker.Coordinators.Entities.Abstract;

public sealed class CustomerCoordinator : EntitiesCoordinator<CustomerRequest, CustomerResponse>
{
    private readonly ICustomerRepository _repository;

    public CustomerCoordinator(
        IConfiguration configuration,
        ILogger<CustomerCoordinator> logger,
        ICustomerRepository repository)
        : base(configuration, logger)
    {
        _repository = repository;
    }

    public override ValueTask<CustomerResponse> Get(string id, CancellationToken cancellationToken = default)
    {
        return _repository.Get(id, cancellationToken);
    }
}
```

The base methods are virtual and throw `NotSupportedException`. Override every operation your coordinator supports; leaving a method unchanged explicitly makes that operation unsupported.

## Registration

This package does not register open or closed generic services. Register each application implementation explicitly:

```csharp
services.AddScoped<
    IEntitiesCoordinator<CustomerRequest, CustomerResponse>,
    CustomerCoordinator>();
```

## Contract

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `Get(id, cancellationToken)` | Retrieves one entity | `TResponse` |
| `GetAll(options, cancellationToken)` | Retrieves a filtered, sorted, or paged collection as interpreted by the implementation | `PagedResult<TResponse>` |
| `Create(request, cancellationToken)` | Creates an entity | `TResponse` |
| `Update(id, request, cancellationToken)` | Updates an entity | `TResponse` |
| `Delete(id, cancellationToken)` | Deletes an entity | Completion only |

## Practical notes

- The base class supplies protected `Config` and `Logger` properties through `Soenneker.Coordinators.Base`; it has no repository dependency or persistence behavior.
- `RequestDataOptions` is only part of the contract. Filtering, sorting, paging, and validation are the implementation's responsibility.
- Cancellation tokens must be forwarded by overrides to their underlying database, HTTP, or queue operations.
- Decide and document each implementation's not-found, conflict, validation, and concurrency behavior; the generic contract does not prescribe them.
