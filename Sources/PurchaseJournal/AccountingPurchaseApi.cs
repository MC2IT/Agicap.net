namespace Mc2it.Agicap.PurchaseJournal;

/// <summary>
/// Manages the accounting purchases of the purchase journal.
/// </summary>
/// <param name="client">The Agicap API client.</param>
/// <param name="entityId">The entity identifier.</param>
public class AccountingPurchaseApi(Client client, int entityId) {

	/// <summary>
	/// The relative URI of the API endpoint.
	/// </summary>
	private readonly string requestUri = $"purchase-journal/v1/entities/{entityId}/accounting-purchases";
}
