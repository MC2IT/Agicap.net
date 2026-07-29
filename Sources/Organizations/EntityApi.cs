namespace Mc2it.Agicap.Organizations;

/// <summary>
/// Manages the entities of the organization with the specified identifier.
/// </summary>
/// <param name="client">The Agicap API client.</param>
/// <param name="organizationId">The organization identifier.</param>
public class EntityApi(Client client, Guid organizationId) {

	/// <summary>
	/// The relative URI of the API endpoint.
	/// </summary>
	private readonly string requestUri = $"organizations/v1/{organizationId}/entities";

	/// <summary>
	/// Fetches the entity list.
	/// </summary>
	/// <param name="pageNumber">The page number.</param>
	/// <param name="pageSize">The number of elements per page.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The entity list.</returns>
	public PaginatedList<Entity> GetAll(int? pageNumber = null, int? pageSize = null, CancellationToken cancellationToken = default) =>
		GetAllAsync(pageNumber, pageSize, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Fetches the entity list.
	/// </summary>
	/// <param name="pageNumber">The page number.</param>
	/// <param name="pageSize">The number of elements per page.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The entity list.</returns>
	public async Task<PaginatedList<Entity>> GetAllAsync(int? pageNumber = null, int? pageSize = null, CancellationToken cancellationToken = default) {
		var queryString = new Dictionary<string, object?> { ["pageNumber"] = pageNumber, ["pageSize"] = pageSize };
		return await client.GetAsync<PaginatedList<Entity>>(requestUri, queryString, cancellationToken);
	}
}
