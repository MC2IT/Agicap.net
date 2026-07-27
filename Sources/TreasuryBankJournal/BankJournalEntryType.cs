namespace Mc2it.Agicap.TreasuryBankJournal;

using System.Text.Json.Serialization;

/// <summary>
///	Defines the type of a bank journal entry.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<BankJournalEntryType>))]
public enum BankJournalEntryType {

	/// <summary>
	/// A bank journal entry.
	/// </summary>
	BANK,

	/// <summary>
	/// A cash-in-transit entry.
	/// </summary>
	CASH_IN_TRANSIT
}
