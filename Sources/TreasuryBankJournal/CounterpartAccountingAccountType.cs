namespace Mc2it.Agicap.TreasuryBankJournal;

using System.Text.Json.Serialization;

/// <summary>
///	The accounting account type.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<CounterpartAccountingAccountType>))]
public enum CounterpartAccountingAccountType {
	BANK,
	CLIENT,
	EXPENSE,
	OTHER,
	PRODUCT,
	SUPPLIER,
	VAT
}
