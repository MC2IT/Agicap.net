namespace Mc2it.Agicap.ChartOfAccounts;

using System.Text.Json.Serialization;

/// <summary>
/// Defines the type of an accounting account.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<AccountingAccountType>))]
public enum AccountingAccountType {
	Bank,
	Client,
	Expense,
	Other,
	Product,
	Supplier,
	Vat
}
