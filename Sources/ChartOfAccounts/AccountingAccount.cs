namespace Mc2it.Agicap.ChartOfAccounts;

using System.Text.Json.Serialization;

/// <summary>
/// Represents an accounting account.
/// </summary>
public class AccountingAccount {

	/// <summary>
	/// The accounting account name.
	/// </summary>
	public string AccountingAccountName { get; set; } = "";

	/// <summary>
	/// The accounting account number.
	/// </summary>
	public string AccountingAccountNumber { get; set; } = "";

	/// <summary>
	/// The accounting account type.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public AccountingAccountType? AccountingAccountType { get; set; }

	/// <summary>
	/// An optional ERP-specific external identifier.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? ExternalId { get; set; }

	/// <summary>
	/// The tax key.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? TaxKey { get; set; }

	/// <summary>
	/// The VAT rate.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public double? VatRate { get; set; }
}
