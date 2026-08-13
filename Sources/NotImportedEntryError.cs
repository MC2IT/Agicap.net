namespace Mc2it.Agicap;

using System.Text.Json.Serialization;

/// <summary>
/// Describes an import error for a journal entry.
/// </summary>
public class NotImportedEntryError {

	/// <summary>
	/// A message describing the error.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? ErrorMessage { get; set; }

	/// <summary>
	/// The error type.
	/// </summary>
	public string ErrorType { get; set; } = NotImportedEntryErrorTypes.Other;
}
