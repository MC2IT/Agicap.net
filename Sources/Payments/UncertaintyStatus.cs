namespace Mc2it.Agicap.Payments;

using System.Text.Json.Serialization;

/// <summary>
/// Defines the uncertainty status of a beneficiary.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<UncertaintyStatus>))]
public enum UncertaintyStatus {
	Irrelevant,
	NotUncertain,
	Uncertain
}
