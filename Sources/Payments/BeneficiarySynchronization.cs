namespace Mc2it.Agicap.Payments;

using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a beneficiary synchronization report.
/// </summary>
public class BeneficiarySynchronization {

	/// <summary>
	/// The date and time the synchronization was started.
	/// </summary>
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// The list of synchronization errors.
	/// </summary>
	public IList<BeneficiarySynchronizationError> Errors { get; set; } = [];

	/// <summary>
	/// The date and time the synchronization finished.
	/// </summary>
	public DateTime? FinishedAt { get; set; }

	/// <summary>
	/// The status of the synchronization.
	/// </summary>
	public BeneficiarySynchronizationStatus Status { get; set; } = BeneficiarySynchronizationStatus.Running;

	/// <summary>
	/// The identifier of the synchronization.
	/// </summary>
	public Guid SyncId { get; set; }
}

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

/// <summary>
/// Defines the status of a beneficiary synchronization.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<BeneficiarySynchronizationStatus>))]
public enum BeneficiarySynchronizationStatus {
	Running,
	Completed,
	CompletedWithErrors
}
