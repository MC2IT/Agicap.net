namespace Mc2it.Agicap.Authentication;

/// <summary>
///	Represents a bad request.
/// </summary>
public sealed class BadRequest {

	/// <summary>
	/// The error message.
	/// </summary>
	public string Error { get; init; } = "";
}
