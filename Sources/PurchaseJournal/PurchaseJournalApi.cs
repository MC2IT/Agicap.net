namespace Mc2it.Agicap.PurchaseJournal;

/// <summary>
/// Provides access to the "PurchaseJournal" API.
/// </summary>
/// <param name="client">The Agicap API client.</param>
public class PurchaseJournalApi(Client client) {

	/// <summary>
	/// Gets a new API client for the accounting purchases of the entity with the specified identifier.
	/// </summary>
	/// <param name="entityId">The entity identifier.</param>
	/// <returns>The API client for the accounting purchases of the specified entity.</returns>
	/// <exception cref="NotImplementedException">This API is not implemented.</exception>
	public AccountingPurchaseApi AccountingPurchases(int entityId) => new(client, entityId);
}
