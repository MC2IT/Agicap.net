namespace Mc2it.Agicap.Payments;

using System.Text.Json.Serialization;

/// <summary>
/// Represents a beneficiary from a synchronization request.
/// </summary>
/// <param name="erpId">The identifier of the beneficiary in the ERP software.</param>
public class SynchronizedBeneficiary(string erpId) {

	/// <summary>
	/// The bank account number (IBAN/BBAN/Other).
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? AccountNumber { get; set; }

	/// <summary>
	/// The ISO 3166 alpha-2 code of the country where the bank account is located.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? BankCountry { get; set; }

	/// <summary>
	/// The bank identifier code (BIC) of the bank where the bank account is located.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? BankIdentifier { get; set; }

	/// <summary>
	/// The name of the bank where the bank account is located.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? BankName { get; set; }

	/// <summary>
	/// The legal registration identifier (e.g. LEI, SIRET, company number...).
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? CompanyLegalId { get; set; }

	/// <summary>
	/// The identifier of the beneficiary in the ERP software.
	/// </summary>
	public string ErpId => erpId;

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

	/// <summary>
	/// The name of the beneficiary.
	/// </summary>
	public string Name { get; set; } = "";

	/// <summary>
	/// The postal address of the beneficiary.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public PostalAddress? PostalAddress { get; set => field = value is null || value.IsEmpty ? null : value; }

	/// <summary>
	/// The ERP identifiers of the suppliers to associate with this beneficiary.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public IList<string>? SupplierErpIds { get; set; }

	/// <summary>
	/// Creates a new synchronized beneficiary from the specified <see cref="Beneficiary"/>.
	/// </summary>
	/// <param name="erpId">The identifier of the beneficiary in the ERP software.</param>
	/// <param name="beneficiary">The beneficiary providing the properties of the instance to create.</param>
	public SynchronizedBeneficiary(string erpId, Beneficiary beneficiary): this(erpId) {
		AccountNumber = beneficiary.BankAccount?.Identifier;
		BankCountry = beneficiary.BankAccount?.Country;
		BankIdentifier = beneficiary.BankAccount?.Bic;
		BankName = beneficiary.BankAccount?.BankName;
		CompanyLegalId = beneficiary.CompanyLegalIdentifier;
		IntermediaryBankBic = beneficiary.BankAccount?.IntermediaryBankBic;
		LocalClearingCode = beneficiary.BankAccount?.LocalClearingCode;
		Name = beneficiary.Name;
		PostalAddress = beneficiary.PostalAddress;
	}
}
