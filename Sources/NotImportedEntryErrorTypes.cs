namespace Mc2it.Agicap;

/// <summary>
/// Describes an import error for a purchase journal entry.
/// </summary>
public static class NotImportedEntryErrorTypes {

	/// <summary>
	/// Another type of error.
	/// </summary>
	public const string Other = "OTHER";

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
	/// The third-party is unknown.
	/// </summary>
	public const string UnknownThirdParty = "UNKNOWN_THIRD_PARTY";

	/// <summary>
	/// The VAT account is unknown.
	/// </summary>
	public const string UnknownVatAccount = "UNKNOWN_VAT_ACCOUNT";
}
