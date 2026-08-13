namespace Mc2it.Agicap.PurchaseJournal;

/// <summary>
/// Manages the purchase journal.
/// </summary>
/// <param name="client">The Agicap API client.</param>
public class PurchaseJournalApi(Client client) {

	/// <summary>
	/// Gets a new API client for the accounting purchases of the entity with the specified identifier.
	/// </summary>
	/// <param name="entityId">The entity identifier.</param>
	/// <returns>The API client for the accounting purchases of the specified entity.</returns>
	public AccountingPurchaseApi AccountingPurchases(int entityId) => new(client, entityId);
}
