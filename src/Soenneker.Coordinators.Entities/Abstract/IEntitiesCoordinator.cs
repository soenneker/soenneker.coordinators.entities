using Soenneker.Coordinators.Base.Abstract;
using Soenneker.Dtos.RequestDataOptions;
using Soenneker.Dtos.Results.Paged;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Coordinators.Entities.Abstract;

/// <summary>
/// Coordinates entity retrieval and mutation requests through the configured repositories.
/// </summary>
public interface IEntitiesCoordinator<in TRequest, TResponse> : IBaseCoordinator
{
    /// <summary>
    /// Retrieves an entity by its identifier.
    /// </summary>
    /// <param name="id">Identifier of the entity to retrieve.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task whose result is the entity response.</returns>
    [Pure]
    ValueTask<TResponse> Get(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of entities based on the specified request options.
    /// </summary>
    /// <param name="options">The request options for filtering, paging, and sorting.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task whose result is the requested page.</returns>
    [Pure]
    ValueTask<PagedResult<TResponse>> GetAll(RequestDataOptions options, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new entity based on the provided request.
    /// </summary>
    /// <param name="request">The request data for the entity to be created.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task whose result is the created entity response.</returns>
    ValueTask<TResponse> Create(TRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing entity with the given identifier using the provided request data.
    /// </summary>
    /// <param name="id">Identifier of the entity to update.</param>
    /// <param name="request">The replacement or update data.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task whose result is the updated entity response.</returns>
    ValueTask<TResponse> Update(string id, TRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the entity with the specified identifier.
    /// </summary>
    /// <param name="id">Identifier of the entity to delete.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that completes when deletion finishes.</returns>
    ValueTask Delete(string id, CancellationToken cancellationToken = default);
}
