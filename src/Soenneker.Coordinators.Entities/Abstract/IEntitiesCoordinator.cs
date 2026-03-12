using Soenneker.Coordinators.Base.Abstract;
using Soenneker.Dtos.RequestDataOptions;
using Soenneker.Dtos.Results.Paged;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Coordinators.Entities.Abstract;

/// <summary>
/// Defines common entity operations such as Get, List, Create, Update, and Delete for a specific request and response type.
/// </summary>
/// <typeparam name="TRequest">The type of the request object used for creating or updating entities.</typeparam>
/// <typeparam name="TResponse">The type of the response object returned by the operations.</typeparam>
public interface IEntitiesCoordinator<in TRequest, TResponse> : IBaseCoordinator
{
    /// <summary>
    /// Retrieves an entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the entity.</returns>
    [Pure]
    ValueTask<TResponse> Get(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of entities based on the specified request options.
    /// </summary>
    /// <param name="options">The request options for filtering, paging, and sorting.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of entities.</returns>
    [Pure]
    ValueTask<PagedResult<TResponse>> GetAll(RequestDataOptions options, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new entity based on the provided request.
    /// </summary>
    /// <param name="request">The request data for the entity to be created.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the identifier and name of the created entity.</returns>
    ValueTask<TResponse> Create(TRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing entity with the given identifier using the provided request data.
    /// </summary>
    /// <param name="id">The identifier of the entity to update.</param>
    /// <param name="request">The updated data for the entity.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated entity.</returns>
    ValueTask<TResponse> Update(string id, TRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the entity with the specified identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity to delete.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    ValueTask Delete(string id, CancellationToken cancellationToken = default);
}