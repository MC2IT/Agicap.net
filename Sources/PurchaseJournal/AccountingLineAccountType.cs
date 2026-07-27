namespace Mc2it.Agicap.PurchaseJournal;

using System.Text.Json.Serialization;

/// <summary>
/// Defines the account type of an accounting line
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<AccountingLineAccountType>))]
public enum AccountingLineAccountType {
	ExpenseAccount,
	SupplierAccount,
	VatAccount
}
