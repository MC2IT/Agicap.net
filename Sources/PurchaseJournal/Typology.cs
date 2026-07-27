namespace Mc2it.Agicap.PurchaseJournal;

using System.Text.Json.Serialization;

/// <summary>
/// Defines the source document type of a purchase journal.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<Typology>))]
public enum Typology {
	CardExpenseReceipt,
	CardRefundReceipt,
	CreditNote,
	ExpenseClaim,
	OwedInvoice
}
