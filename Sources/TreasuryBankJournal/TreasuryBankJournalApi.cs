namespace Mc2it.Agicap.TreasuryBankJournal;

/// <summary>
/// Manages the treasury bank journal.
/// </summary>
/// <param name="client">The Agicap API client.</param>
public class TreasuryBankJournalApi(Client client) {

	/// <summary>
	/// Gets a new API client for the exports of the entity with the specified identifier.
	/// </summary>
	/// <param name="entityId">The entity identifier.</param>
	/// <returns>The API client for the exports of the specified entity.</returns>
	public ExportsApi Exports(int entityId) => new(client, entityId);
}
