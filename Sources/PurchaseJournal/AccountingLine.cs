namespace Mc2it.Agicap.PurchaseJournal;

using System.Globalization;
using System.Text.Json.Serialization;

/// <summary>
/// Represents an accounting line of a purchase journal.
/// </summary>
public class AccountingLine {

	/// <summary>
	/// The accounting currency
	/// </summary>
	public string AccountingCurrency { get; set; } = RegionInfo.CurrentRegion.ISOCurrencySymbol;

	/// <summary>
	/// The number of the account posted.
	/// </summary>
	public string AccountNumber { get; set; } = "";

	/// <summary>
	/// The type of bookkeeping account.
	/// </summary>
	public AccountingLineAccountType AccountType { get; set; } = AccountingLineAccountType.ExpenseAccount;

	/// <summary>
	/// The analytical codes which are related to the cost bearer.
	/// </summary>
	public IDictionary<string, string> AdditionalAnalyticalCodes { get; set; } = new Dictionary<string, string>();

	/// <summary>
	/// The analytical codes linked to the expense account.
	/// </summary>
	public IDictionary<string, string> AnalyticalCodes { get; set; } = new Dictionary<string, string>();

	/// <summary>
	/// The conversion rate applied to the amounts.
	/// </summary>
	public double ConversionRate { get; set; }

	/// <summary>
	/// The amount applied to the converted credit column.
	/// </summary>
	public decimal ConvertedCreditAmount { get; set; }

	/// <summary>
	/// The amount applied to the converted debit column.
	/// </summary>
	public decimal ConvertedDebitAmount { get; set; }

	/// <summary>
	/// The amount applied to the credit column.
	/// </summary>
	public decimal Credit { get; set; }

	/// <summary>
	/// The currency of the document provided.
	/// </summary>
	public string Currency { get; set; } = RegionInfo.CurrentRegion.ISOCurrencySymbol;

	/// <summary>
	/// The amount applied to the debit column.
	/// </summary>
	public decimal Debit { get; set; }

	/// <summary>
	/// The identifier of the line item for invoice accounting purchase typology.
	/// <see langword="null"/> for lines of type <see cref="AccountingLineAccountType.SupplierAccount"/>.
	/// </summary>
	public Guid? LineItemId { get; set; }

	/// <summary>
	/// The tax key of VAT account if the <see cref="AccountType"/> is <see cref="AccountingLineAccountType.VatAccount"/>.
	/// </summary>
	public string? TaxKey { get; set; }

	/// <summary>
	/// The label for the supplier account.
	/// </summary>
	public string? ThirdPartyAccount { get; set; }

	/// <summary>
	/// The string "G" for "General".
	/// </summary>
	public string Type { get; set; } = "G";

	/// <summary>
	/// The name of the VAT account (or of the reverse charge for reverse-charge entries).
	/// <see langword="null"/> for lines of type <see cref="AccountingLineAccountType.SupplierAccount"/>.
	/// </summary>
	public string? VatAccountName { get; set; }
}

/// <summary>
/// Defines the account type of an accounting line
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<AccountingLineAccountType>))]
public enum AccountingLineAccountType {
	ExpenseAccount,
	SupplierAccount,
	VatAccount
}
