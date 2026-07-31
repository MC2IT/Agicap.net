namespace Mc2it.Agicap.Payments;

using System.Text.Json.Serialization;

/// <summary>
/// Defines the status of a beneficiary synchronization.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<BeneficiarySynchronizationErrorCode>))]
public enum BeneficiarySynchronizationStatus {
	Running,
	Completed,
	CompletedWithErrors
}
