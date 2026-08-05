namespace Mc2it.Agicap.ChartOfAccounts;

using System.Text.Json.Serialization;

/// <summary>
/// Defines the status of an import of accounting accounts or third-parties.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<ImportStatus>))]
public enum ImportStatus {
	Started,
	Failed,
	Done
}
