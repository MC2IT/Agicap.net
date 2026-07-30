namespace Mc2it.Agicap.Payments;

using System.Text.Json;

/// <summary>
/// Represents an error that occurred during the synchronization of a beneficiary.
/// </summary>
public class BeneficiarySynchronizationError {

	/// <summary>
	/// The deserialized beneficiary.
	/// </summary>
	public SynchronizedBeneficiary? Beneficiary => JsonSerializer.Deserialize<SynchronizedBeneficiary>(RawData, JsonSerializerOptions.Web);

	/// <summary>
	/// An error code identifying the reason the beneficiary failed.
	/// </summary>
	public BeneficiarySynchronizationErrorCode ErrorCode { get; set; }

	/// <summary>
	/// A human-readable description of the error, when available.
	/// </summary>
	public string? ErrorMessage { get; set; }

	/// <summary>
	/// The raw JSON data of the submitted beneficiary.
	/// </summary>
	public string RawData { get; set; } = "null";

	/// <summary>
	/// The zero-based index of the failing beneficiary in the submitted payload.
	/// </summary>
	public int RowIndex { get; set; }
}
