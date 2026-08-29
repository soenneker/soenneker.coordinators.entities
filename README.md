[![](https://img.shields.io/nuget/v/soenneker.coordinators.entities.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.coordinators.entities/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.coordinators.entities/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.coordinators.entities/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.coordinators.entities.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.coordinators.entities/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.coordinators.entities/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.coordinators.entities/actions/workflows/codeql.yml)

# Soenneker.Coordinators.Entities

Coordinates entity retrieval and mutation requests through the configured repositories.

## Install

```bash
dotnet add package Soenneker.Coordinators.Entities
```

## Quick start

```csharp
using Soenneker.Coordinators.Entities.Abstract;

IEntitiesCoordinator<TRequest, TResponse> entitiesCoordinator = /* resolve from DI */;
var result = await entitiesCoordinator.Get("value", default);
```

Retrieves an entity by its identifier.

## What you get

- `IEntitiesCoordinator<TRequest, TResponse>` — Coordinates entity retrieval and mutation requests through the configured repositories.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IEntitiesCoordinator<TRequest, TResponse>.Get(id, cancellationToken)` | Retrieves an entity by its identifier. | A task whose result is the response returned by get. |
| `IEntitiesCoordinator<TRequest, TResponse>.GetAll(options, cancellationToken)` | Retrieves a list of entities based on the specified request options. | A task whose result is the requested paged Result. |
| `IEntitiesCoordinator<TRequest, TResponse>.Create(request, cancellationToken)` | Creates a new entity based on the provided request. | A task whose result is the response returned by create. |
| `IEntitiesCoordinator<TRequest, TResponse>.Update(id, request, cancellationToken)` | Updates an existing entity with the given identifier using the provided request data. | A task whose result is the response returned by update. |
| `IEntitiesCoordinator<TRequest, TResponse>.Delete(id, cancellationToken)` | Deletes the entity with the specified identifier. | Completes when the requested deletion has finished. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
