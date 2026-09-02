namespace Mc2it.Agicap.Payments;

using System.Text.Json.Serialization;

/// <summary>
/// Represents the bank account of a beneficiary.
/// </summary>
public class BankAccount {

	/// <summary>
	/// The name of the bank where the bank account is located.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? BankName { get; set; }

	/// <summary>
	/// The bank identifier code (BIC) of the bank where the bank account is located.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? Bic { get; set; }

	/// <summary>
	/// The ISO 3166 alpha-2 code of the country where the bank account is located.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? Country { get; set; }

	/// <summary>
	/// The bank account number (IBAN/BBAN/Other).
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? Identifier { get; set; }

	/// <summary>
	/// Value indicating whether this bank account is empty.
	/// </summary>
	[JsonIgnore]
	public bool IsEmpty =>
		string.IsNullOrWhiteSpace(BankName) &&
		string.IsNullOrWhiteSpace(Bic) &&
		string.IsNullOrWhiteSpace(Country) &&
		string.IsNullOrWhiteSpace(Identifier) &&
		string.IsNullOrWhiteSpace(IntermediaryBankBic) &&
		string.IsNullOrWhiteSpace(LocalClearingCode);

	/// <summary>
	/// The bank identifier code (BIC) of the intermediary bank processing the payments.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? IntermediaryBankBic { get; set; }

	/// <summary>
	/// The local identifier of the bank.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? LocalClearingCode { get; set; }
}
