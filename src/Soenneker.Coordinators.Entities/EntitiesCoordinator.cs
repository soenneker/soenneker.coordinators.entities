using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.Coordinators.Base;
using Soenneker.Coordinators.Entities.Abstract;
using System;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Dtos.RequestDataOptions;
using Soenneker.Dtos.Results.Paged;

namespace Soenneker.Coordinators.Entities;

/// <inheritdoc cref="IEntitiesCoordinator{TRequest, TResponse}"/>
public class EntitiesCoordinator<TRequest, TResponse> : BaseCoordinator, IEntitiesCoordinator<TRequest, TResponse>
{
    public EntitiesCoordinator(IConfiguration configuration, ILogger<EntitiesCoordinator<TRequest, TResponse>> logger) : base(configuration, logger)
    {
    }

    public virtual ValueTask<TResponse> Get(string id, CancellationToken cancellationToken = default)
    {
        throw new NotSupportedException();
    }

    public virtual ValueTask<PagedResult<TResponse>> GetAll(RequestDataOptions options, CancellationToken cancellationToken = default)
    {
        throw new NotSupportedException();
    }

    public virtual ValueTask<TResponse> Create(TRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotSupportedException();
    }

    public virtual ValueTask<TResponse> Update(string id, TRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotSupportedException();
    }

    public virtual ValueTask Delete(string id, CancellationToken cancellationToken = default)
    {
        throw new NotSupportedException();
    }
}