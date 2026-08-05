namespace Mc2it.Agicap.ChartOfAccounts;

/// <summary>
/// Provides metrics about the import of accounting accounts or third-parties.
/// </summary>
public class ImportResponse {

	/// <summary>
	/// The failure description when the import failed.
	/// </summary>
	public string? FailureReason { get; set; }

	/// <summary>
	/// The date at which the import was requested.
	/// </summary>
	public DateTime ImportDate { get; set; }

	/// <summary>
	/// The identifier of the import, provided by the caller.
	/// </summary>
	public Guid ImportId { get; set; }

	/// <summary>
	/// The status of the import.
	/// </summary>
	public ImportStatus ImportStatus = ImportStatus.Started;

	/// <summary>
	/// The summary of what was imported when the import is finished.
	/// </summary>
	public ImportSummary? ImportSummary { get; set; }
}
