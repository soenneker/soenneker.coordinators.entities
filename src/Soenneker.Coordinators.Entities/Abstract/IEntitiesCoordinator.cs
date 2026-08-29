using Soenneker.Coordinators.Base.Abstract;
using Soenneker.Dtos.RequestDataOptions;
using Soenneker.Dtos.Results.Paged;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Coordinators.Entities.Abstract;

public interface IEntitiesCoordinator<in TRequest, TResponse> : IBaseCoordinator
{
    /// <summary>
    /// Retrieves an entity by its identifier.
    /// </summary>
    /// <param name="id">Identifier of the entities coordinator instance or registration to target.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task whose result is the response returned by get.</returns>
    [Pure]
    ValueTask<TResponse> Get(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of entities based on the specified request options.
    /// </summary>
    /// <param name="options">The request options for filtering, paging, and sorting.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task whose result is the requested paged Result.</returns>
    [Pure]
    ValueTask<PagedResult<TResponse>> GetAll(RequestDataOptions options, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new entity based on the provided request.
    /// </summary>
    /// <param name="request">The request data for the entity to be created.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task whose result is the response returned by create.</returns>
    ValueTask<TResponse> Create(TRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing entity with the given identifier using the provided request data.
    /// </summary>
    /// <param name="id">Identifier of the entities coordinator instance or registration to target.</param>
    /// <param name="request">request that defines the request to send.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task whose result is the response returned by update.</returns>
    ValueTask<TResponse> Update(string id, TRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the entity with the specified identifier.
    /// </summary>
    /// <param name="id">Identifier of the entities coordinator instance or registration to target.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that completes after the targeted files have been deleted.</returns>
    ValueTask Delete(string id, CancellationToken cancellationToken = default);
}
