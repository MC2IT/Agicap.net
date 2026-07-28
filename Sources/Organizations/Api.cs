namespace Mc2it.Agicap.Organizations;

/// <summary>
/// Provides access to the "Organizations" endpoints.
/// </summary>
/// <param name="client">The Agicap API client.</param>
public class Api(Client client) {

	/// <summary>
	/// Fetches the entities of the organization with the specified identifier.
	/// </summary>
	/// <param name="organizationId">The organization identifier.</param>
	/// <param name="pageNumber">The page number.</param>
	/// <param name="pageSize">The number of elements per page.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The entities of the organization with the specified identifier.</returns>
	public PaginatedList<Entity> GetEntities(Guid organizationId, int? pageNumber = null, int? pageSize = null, CancellationToken cancellationToken = default) =>
		GetEntitiesAsync(organizationId, pageNumber, pageSize, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Fetches the entities of the organization with the specified identifier.
	/// </summary>
	/// <param name="organizationId">The organization identifier.</param>
	/// <param name="pageNumber">The page number.</param>
	/// <param name="pageSize">The number of elements per page.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The entities of the organization with the specified identifier.</returns>
	public async Task<PaginatedList<Entity>> GetEntitiesAsync(Guid organizationId, int? pageNumber = null, int? pageSize = null, CancellationToken cancellationToken = default) {
		var queryString = new Dictionary<string, object?> { ["pageNumber"] = pageNumber, ["pageSize"] = pageSize };
		return await client.GetAsync<PaginatedList<Entity>>($"organizations/v1/{organizationId}/entities", queryString, cancellationToken);
	}

	/// <summary>
	/// Fetches the organization list.
	/// </summary>
	/// <param name="pageNumber">The page number.</param>
	/// <param name="pageSize">The number of elements per page.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The organization list.</returns>
	public PaginatedList<Organization> GetOrganizations(int? pageNumber = null, int? pageSize = null, CancellationToken cancellationToken = default) =>
		GetOrganizationsAsync(pageNumber, pageSize, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Fetches the organization list.
	/// </summary>
	/// <param name="pageNumber">The page number.</param>
	/// <param name="pageSize">The number of elements per page.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The organization list.</returns>
	public async Task<PaginatedList<Organization>> GetOrganizationsAsync(int? pageNumber = null, int? pageSize = null, CancellationToken cancellationToken = default) {
		var queryString = new Dictionary<string, object?> { ["pageNumber"] = pageNumber, ["pageSize"] = pageSize };
		return await client.GetAsync<PaginatedList<Organization>>("organizations/v1", queryString, cancellationToken);
	}
}
