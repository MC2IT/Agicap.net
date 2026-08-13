namespace Mc2it.Agicap.TreasuryBankJournal;

using System.Globalization;

/// <summary>
///	Represents a counterpart in an Agicap treasury bank journal.
/// </summary>
public class Counterpart {

	/// <summary>
	/// An optional ERP-specific external identifier for the bank accounting account.
	/// </summary>
	public string? AccountingAccountExternalId { get; set; }

	/// <summary>
	/// The accounting account number.
	/// </summary>
	public string AccountingAccountNumber { get; set; } = "";

	/// <summary>
	/// The accounting account type.
	/// </summary>
	public CounterpartAccountingAccountType AccountingAccountType { get; set; } = CounterpartAccountingAccountType.OTHER;

	/// <summary>
	/// The accounting currency ISO code.
	/// </summary>
	public string? AccountingCurrency { get; set; }

	/// <summary>
	/// The list of analytical codes of the counterpart.
	/// </summary>
	public IDictionary<string, string> AnalyticalCodes { get; set; } = new Dictionary<string, string>();

	/// <summary>
	/// The credit value in accounting currency.
	/// </summary>
	public decimal? CreditInAccountingCurrency { get; set; }

	/// <summary>
	/// The credit value in original currency.
	/// </summary>
	public decimal? CreditInOriginalCurrency { get; set; }

	/// <summary>
	/// Additional fields coming from the reconciled expected used to initialize the counterpart.
	/// </summary>
	public IList<CustomField>? CustomFields { get; set; }

	/// <summary>
	/// The debit value in accounting currency.
	/// </summary>
	public decimal? DebitInAccountingCurrency { get; set; }

	/// <summary>
	/// The debit value in original currency.
	/// </summary>
	public decimal? DebitInOriginalCurrency { get; set; }

	/// <summary>
	/// Information about the associated document.
	/// </summary>
	public Document? Document { get; set; }

	/// <summary>
	/// The exchange rate applied between the original currency amount and the accounting currency amount.
	/// </summary>
	public double? ExchangeRate { get; set; }

	/// <summary>
	/// The journal code.
	/// </summary>
	public string? JournalCode { get; set; }

	/// <summary>
	/// A reference to a previously exported journal entry linked to this counterpart.
	/// </summary>
	public LinkedEntry? LinkedExportedEntry { get; set; }

	/// <summary>
	/// The counterpart name.
	/// </summary>
	public string Name { get; set; } = "";

	/// <summary>
	/// The original currency ISO code.
	/// </summary>
	public string OriginalCurrency { get; set; } = RegionInfo.CurrentRegion.ISOCurrencySymbol;

	/// <summary>
	/// The tax key for VAT accounting account.
	/// </summary>
	public string? TaxKey { get; set; }

	/// <summary>
	/// The third-party code.
	/// </summary>
	public string? ThirdPartyCode { get; set; }

	/// <summary>
	/// An optional ERP-specific external identifier for the third-party.
	/// </summary>
	public string? ThirdPartyExternalId { get; set; }

	/// <summary>
	/// The third-party name.
	/// </summary>
	public string? ThirdPartyName { get; set; }
}
