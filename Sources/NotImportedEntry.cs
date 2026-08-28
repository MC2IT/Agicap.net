namespace Mc2it.Agicap;

using System.Text.Json.Serialization;

/// <summary>
/// Identifies a journal entry that was not imported in the client accounting system.
/// </summary>
public class NotImportedEntry: ImportedEntry {

	/// <summary>
	/// The errors preventing the journal entry from being imported.
	/// </summary>
	public IList<NotImportedEntryError> Errors { get; set; } = [];
}

/// <summary>
/// Describes an import error for a journal entry.
/// </summary>
public class NotImportedEntryError {

	/// <summary>
	/// A message describing the error.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? ErrorMessage { get; set; }

	/// <summary>
	/// The error type.
	/// </summary>
	public string ErrorType { get; set; } = NotImportedEntryErrorTypes.Other;
}

/// <summary>
/// Provides the error types for a journal entry error.
/// </summary>
public static class NotImportedEntryErrorTypes {

	/// <summary>
	/// Another type of error.
	/// </summary>
	public const string Other = "OTHER";

	/// <summary>
	/// The accounting account is unknown.
	/// </summary>
	public const string UnknownAccountingAccount = "UNKNOWN_ACCOUNTING_ACCOUNT";

	/// <summary>
	/// The analytical code is unknown.
	/// </summary>
	public const string UnknownAnalyticalCode = "UNKNOWN_ANALYTICAL_CODE";

	/// <summary>
	/// The currency is unknown.
	/// </summary>
	public const string UnknownCurrency = "UNKNOWN_CURRENCY";

	/// <summary>
	/// The expense account is unknown.
	/// </summary>
	public const string UnknownExpenseAccount = "UNKNOWN_EXPENSE_ACCOUNT";

	/// <summary>
	/// The journal code is unknown.
	/// </summary>
	public const string UnknownJournalCode = "UNKNOWN_JOURNAL_CODE";

	/// <summary>
	/// The third-party is unknown.
	/// </summary>
	public const string UnknownThirdParty = "UNKNOWN_THIRD_PARTY";

	/// <summary>
	/// The VAT account is unknown.
	/// </summary>
	public const string UnknownVatAccount = "UNKNOWN_VAT_ACCOUNT";
}
