namespace Mc2it.Agicap;

using System.Text.Json.Serialization;

/// <summary>
/// Defines the payment method of a purchase journal entry.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<PaymentMethod>))]
public enum PaymentMethod {
	BillOfExchange,
	Cash,
	Check,
	Compensation,
	CreditCard,
	DebitCard,
	DirectDebit,
	Girocard,
	Giropay,
	None,
	Other,
	Paypal,
	RIBA,
	WireTransfer
}
