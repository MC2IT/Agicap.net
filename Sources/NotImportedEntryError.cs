namespace Mc2it.Agicap;

/// <summary>
/// Describes an import error for a purchase journal entry.
/// </summary>
public class NotImportedEntryError {

	/// <summary>
	/// A message describing the error.
	/// </summary>
	[ValidateNotNull()]
	[string] $ErrorMessage = ""

	/// <summary>
	/// The error type.
	/// </summary>
	[string] $ErrorType = "OTHER"
}
