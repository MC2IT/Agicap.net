namespace Mc2it.Agicap;

/// <summary>
/// An exception to enable returning an HTTP error response.
/// </summary>
/// <param name="message">The message that describes the exception.</param>
/// <param name="reponse">The response from the HTTP server.</param>
/// <param name="problemDetails">Additional details about the error that caused the exception.</param>
public sealed class HttpResponseException(string message, HttpResponseMessage response, ProblemDetails? problemDetails = null):
	HttpRequestException(message, inner: null, response.StatusCode) {

	/// <summary>
	/// Additional details about the error that caused this exception.
	/// </summary>
	public ProblemDetails? ProblemDetails { get; } = problemDetails;

	/// <summary>
	/// The response from the HTTP server.
	/// </summary>
	public HttpResponseMessage Response { get; } = response;
}
