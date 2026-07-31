namespace Mc2it.Agicap.Payments;

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
	public BeneficiarySynchronizationStatus Status { get; set; }

	/// <summary>
	/// The identifier of the synchronization.
	/// </summary>
	public Guid SyncId { get; set; }
}
