namespace Mc2it.Agicap.ChartOfAccounts;

/// <summary>
/// Provides the summary of an import of accounting accounts or third-parties.
/// </summary>
public class ImportSummary {

	/// <summary>
	/// The number of entities imported.
	/// </summary>
	public int ImportedCount { get; set; }

	/// <summary>
	/// The number of entities not imported.
	/// </summary>
	public int NotImportedCount { get; set; }
}
