namespace Mc2it.Agicap.Organizations;

/// <summary>
/// Manages the organizations.
/// </summary>
/// <param name="client">The Agicap API client.</param>
public class OrganizationApi(Client client) {

	/// <summary>
	/// The relative URI of the API endpoint.
	/// </summary>
	private readonly string requestUri = "organizations/v1";

	/// <summary>
	/// Gets a new API client for the entities of the organization with the specified identifier.
	/// </summary>
	/// <param name="organizationId">The organization identifier.</param>
	/// <returns>The API client for the entities of the specified organization.</returns>
	public EntityApi Entities(Guid organizationId) => new(client, organizationId);

	/// <summary>
	/// Fetches the organization list.
	/// </summary>
	/// <param name="pageNumber">The page number.</param>
	/// <param name="pageSize">The number of elements per page.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The organization list.</returns>
	public PaginatedList<Organization> ReadAll(int? pageNumber = null, int? pageSize = null, CancellationToken cancellationToken = default) =>
		ReadAllAsync(pageNumber, pageSize, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Fetches the organization list.
	/// </summary>
	/// <param name="pageNumber">The page number.</param>
	/// <param name="pageSize">The number of elements per page.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The organization list.</returns>
	public async Task<PaginatedList<Organization>> ReadAllAsync(int? pageNumber = null, int? pageSize = null, CancellationToken cancellationToken = default) {
		var queryString = new Dictionary<string, object?> {
			["pageNumber"] = pageNumber,
			["pageSize"] = pageSize
		};

		return await client.GetAsync<PaginatedList<Organization>>(requestUri, queryString, cancellationToken);
	}
}
