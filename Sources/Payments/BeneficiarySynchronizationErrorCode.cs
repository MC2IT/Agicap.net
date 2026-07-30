namespace Mc2it.Agicap.Payments;

using System.Text.Json.Serialization;

/// <summary>
/// Represents an error that occurred during the synchronization of a beneficiary.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<BeneficiarySynchronizationErrorCode>))]
public enum BeneficiarySynchronizationErrorCode {
	AccountNumberAlreadyUsed,
	IncompletePostalAddress,
	InvalidBankIdentifier,
	InvalidBic,
	InvalidCountry,
	InvalidIban,
	InvalidLocalClearingCode,
	InvalidName,
	MissingBankCountry,
	NameAlreadyUsed,
	NameAndAccountNumberAlreadyUsed,
	SupplierNotFound,
	UnsupportedCountry
}
