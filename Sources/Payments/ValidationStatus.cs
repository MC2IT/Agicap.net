namespace Mc2it.Agicap.Payments;

using System.Text.Json.Serialization;

/// <summary>
/// Defines the validation status of a beneficiary.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<ValidationStatus>))]
public enum ValidationStatus {
	PendingValidation,
	Validated
}
