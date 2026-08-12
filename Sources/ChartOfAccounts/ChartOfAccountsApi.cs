namespace Mc2it.Agicap.ChartOfAccounts;

/// <summary>
/// Manages the chart of accounts.
/// </summary>
/// <param name="client">The Agicap API client.</param>
public class ChartOfAccountsApi(Client client) {

	/// <summary>
	/// Gets a new API client for the accounting accounts of the entity with the specified identifier.
	/// </summary>
	/// <param name="entityId">The entity identifier.</param>
	/// <returns>The API client for the accounting accounts of the specified entity.</returns>
	public AccountingAccountApi AccountingAccounts(int entityId) => new(client, entityId);

	/// <summary>
	/// Gets a new API client for the analytical plan of the entity with the specified identifier.
	/// </summary>
	/// <param name="entityId">The entity identifier.</param>
	/// <returns>The API client for the analytical plan of the specified entity.</returns>
	/// <exception cref="NotImplementedException">This API is not implemented.</exception>
	public object AnalyticalPlan(int entityId) => throw new NotImplementedException();

	/// <summary>
	/// Gets a new API client for the third-parties of the entity with the specified identifier.
	/// </summary>
	/// <param name="entityId">The entity identifier.</param>
	/// <returns>The API client for the third-parties of the specified entity.</returns>
	public ThirdPartyApi ThirdParties(int entityId) => new(client, entityId);
}
