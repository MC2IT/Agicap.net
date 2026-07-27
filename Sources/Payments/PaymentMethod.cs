namespace Mc2it.Agicap.Payments;

using System.Text.Json.Serialization;

/// <summary>
/// Defines the type of an accounting account.
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
