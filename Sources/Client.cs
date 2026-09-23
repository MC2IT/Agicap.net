namespace Mc2it.Agicap;

using Mc2it.Agicap.Authentication;
using System.Collections.Specialized;
using System.Globalization;
using System.Net;
using System.Net.Http.Json;
using System.Web;

/// <summary>
/// Retrieves and manages Agicap data with HTTP requests.
/// </summary>
/// <param name="credential">The client identifier and secret.</param>
public class Client(NetworkCredential credential): IDisposable {

	/// <summary>
	/// The assembly version.
	/// </summary>
	private static readonly Version Version = typeof(Client).Assembly.GetName().Version!;

	/// <summary>
	/// The base URL of the remote API endpoint.
	/// </summary>
	public Uri BaseUrl { get; set; } = new("https://api.agicap.com/public/");

	/// <summary>
	/// Provides access to the chart of accounts.
	/// </summary>
	public ChartOfAccounts.ChartOfAccountsApi ChartOfAccounts => new(this);

	/// <summary>
	/// The client identifier and secret.
	/// </summary>
	public NetworkCredential Credential { get; set; } = credential;

	/// <summary>
	/// The scopes to use by default when invoking the <see cref="AuthenticateAsync"/> method.
	/// </summary>
	public IList<string> DefaultScopes { get; set; } = [Scopes.PublicApi];

	/// <summary>
	/// Value indicating whether this client is authenticated.
	/// </summary>
	public bool IsAuthenticated => !accessToken.HasExpired;

	/// <summary>
	/// Provides access to the organizations.
	/// </summary>
	public Organizations.OrganizationApi Organizations => new(this);

	/// <summary>
	/// Provides access to the payments.
	/// </summary>
	public Payments.PaymentApi Payments => new(this);

	/// <summary>
	/// Provides access to the purchase journal.
	/// </summary>
	public PurchaseJournal.PurchaseJournalApi PurchaseJournal => new(this);

	/// <summary>
	/// Provides access to the treasury bank journal.
	/// </summary>
	public TreasuryBankJournal.TreasuryBankJournalApi TreasuryBankJournal => new(this);

	/// <summary>
	/// The user agent string to use when making requests.
	/// </summary>
	public string UserAgent { get; set; } = $".NET/{Environment.Version} | Mc2it.Agicap/{Version.ToString(3)}";

	/// <summary>
	/// The current access token.
	/// </summary>
	private AccessToken accessToken = new();

	/// <summary>
	/// Value indicating whether this object has been disposed.
	/// </summary>
	private bool disposed;

	/// <summary>
	/// The underlying HTTP client.
	/// </summary>
	private readonly HttpClient httpClient = new() { Timeout = TimeSpan.FromMinutes(1) };

	/// <summary>
	/// Creates a new client.
	/// </summary>
	/// <param name="clientId">The client identifier.</param>
	/// <param name="clientSecret">The client secret.</param>
	public Client(string clientId, string clientSecret): this(new NetworkCredential(clientId, clientSecret)) {}

	/// <summary>
	/// Generates a new access token.
	/// </summary>
	/// <param name="scopes">The delegated permissions to consent to.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The generated access token.</param>
	public AccessToken Authenticate(string[]? scopes = null, CancellationToken cancellationToken = default) =>
		AuthenticateAsync(scopes, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Generates a new access token.
	/// </summary>
	/// <param name="scopes">The delegated permissions to consent to.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The generated access token.</param>
	public async Task<AccessToken> AuthenticateAsync(string[]? scopes = null, CancellationToken cancellationToken = default) {
		using var request = NewHttpRequest(HttpMethod.Post, "auth/v1/token", content: new FormUrlEncodedContent(new Dictionary<string, string> {
			["client_id"] = Credential.UserName,
			["client_secret"] = Credential.Password,
			["grant_type"] = "client_credentials",
			["scope"] = string.Join(' ', scopes is not null && scopes.Length > 0 ? scopes : DefaultScopes)
		}));

		using var response = await httpClient.SendAsync(request, cancellationToken);
		await EnsureSuccessStatusCode(response, cancellationToken);
		return accessToken = (await response.Content.ReadFromJsonAsync<AccessToken>(cancellationToken))!;
	}

	/// <summary>
	/// Sends a <c>DELETE</c> request to the specified URI.
	/// </summary>
	/// <typeparam name="T">The target type to deserialize to.</typeparam>
	/// <param name="requestUri">The URI the request is sent to.</param>
	/// <param name="query">Any query information to include in the specified request URI.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The response from the HTTP server.</returns>
	internal async Task<HttpResponseMessage> DeleteAsync(string requestUri, IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default) {
		if (!IsAuthenticated) await AuthenticateAsync(cancellationToken: cancellationToken);
		using var request = NewHttpRequest(HttpMethod.Delete, requestUri, query);
		var response = await httpClient.SendAsync(request, cancellationToken);
		return await EnsureSuccessStatusCode(response, cancellationToken);
	}

	/// <summary>
	/// Releases any resources associated with this object.
	/// </summary>
	public void Dispose() {
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	/// <summary>
	/// Sends a <c>GET</c> request to the specified URI and returns the value that results from deserializing the response body as JSON.
	/// </summary>
	/// <typeparam name="T">The target type to deserialize to.</typeparam>
	/// <param name="requestUri">The URI the request is sent to.</param>
	/// <param name="query">Any query information to include in the specified request URI.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The deserialized response body.</returns>
	internal async Task<T> GetAsync<T>(string requestUri, IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default) {
		if (!IsAuthenticated) await AuthenticateAsync(cancellationToken: cancellationToken);
		using var request = NewHttpRequest(HttpMethod.Get, requestUri, query);
		using var response = await httpClient.SendAsync(request, cancellationToken);
		await EnsureSuccessStatusCode(response, cancellationToken);
		return (await response.Content.ReadFromJsonAsync<T>(cancellationToken))!;
	}

	/// <summary>
	/// Sends a <c>PATCH</c> request to the specified URI containing the <paramref name="value"/> serialized as JSON in the request body.
	/// </summary>
	/// <typeparam name="T">The type of the value to serialize.</typeparam>
	/// <param name="requestUri">The URI the request is sent to.</param>
	/// <param name="value">The request body.</param>
	/// <param name="query">Any query information to include in the specified request URI.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The response from the HTTP server.</returns>
	internal async Task<HttpResponseMessage> PatchAsync<T>(string requestUri, T value, IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default) {
		if (!IsAuthenticated) await AuthenticateAsync(cancellationToken: cancellationToken);
		using var request = NewHttpRequest(HttpMethod.Patch, requestUri, query, JsonContent.Create(value));
		var response = await httpClient.SendAsync(request, cancellationToken);
		return await EnsureSuccessStatusCode(response, cancellationToken);
	}

	/// <summary>
	/// Sends a <c>POST</c> request to the specified URI containing the <paramref name="value"/> serialized as JSON in the request body.
	/// </summary>
	/// <typeparam name="T">The type of the value to serialize.</typeparam>
	/// <param name="requestUri">The URI the request is sent to.</param>
	/// <param name="value">The request body.</param>
	/// <param name="query">Any query information to include in the specified request URI.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The response from the HTTP server.</returns>
	internal async Task<HttpResponseMessage> PostAsync<T>(string requestUri, T value, IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default) {
		if (!IsAuthenticated) await AuthenticateAsync(cancellationToken: cancellationToken);
		using var request = NewHttpRequest(HttpMethod.Post, requestUri, query, JsonContent.Create(value));
		var response = await httpClient.SendAsync(request, cancellationToken);
		return await EnsureSuccessStatusCode(response, cancellationToken);
	}

	/// <summary>
	/// Sends a <c>PUT</c> request to the specified URI containing the <paramref name="value"/> serialized as JSON in the request body.
	/// </summary>
	/// <typeparam name="T">The type of the value to serialize.</typeparam>
	/// <param name="requestUri">The URI the request is sent to.</param>
	/// <param name="value">The request body.</param>
	/// <param name="query">Any query information to include in the specified request URI.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The response from the HTTP server.</returns>
	internal async Task<HttpResponseMessage> PutAsync<T>(string requestUri, T value, IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default) {
		if (!IsAuthenticated) await AuthenticateAsync(cancellationToken: cancellationToken);
		using var request = NewHttpRequest(HttpMethod.Put, requestUri, query, JsonContent.Create(value));
		var response = await httpClient.SendAsync(request, cancellationToken);
		return await EnsureSuccessStatusCode(response, cancellationToken);
	}

	/// <summary>
	/// Releases any resources associated with this object.
	/// </summary>
	/// <param name="disposing">Value indicating whether this object is currently being disposed.</param>
	protected virtual void Dispose(bool disposing) {
		if (disposed) return;
		if (disposing) httpClient.Dispose();
		disposed = true;
	}

	/// <summary>
	/// Throws an exception if the <see cref="HttpResponseMessage.IsSuccessStatusCode"/> property for the HTTP response is <see langword="false"/>.
	/// </summary>
	/// <param name="response">The response from the HTTP server.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The HTTP response message if the call is successful.</returns>
	/// <exception cref="HttpResponseException">The HTTP response is unsuccessful.</exception>
	private static async Task<HttpResponseMessage> EnsureSuccessStatusCode(HttpResponseMessage response, CancellationToken cancellationToken = default) {
		if (response.IsSuccessStatusCode) return response;

		ProblemDetails? problemDetails;
		try { problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken); }
		catch { problemDetails = null; }

		var reasonPhrase = string.IsNullOrWhiteSpace(problemDetails?.Title) ? response.ReasonPhrase : problemDetails.Title;
		throw new HttpResponseException($"{(int) response.StatusCode} {reasonPhrase}".TrimEnd(), response, problemDetails);
	}

	/// <summary>
	/// Creates a new HTTP request.
	/// </summary>
	/// <param name="method">The HTTP method.</param>
	/// <param name="requestUri">The URI the request is sent to.</param>
	/// <param name="query">Any query information to include in the specified request URI.</param>
	/// <param name="content">The request body.</param>
	/// <returns>The newly created HTTP request.</returns>
	private HttpRequestMessage NewHttpRequest(HttpMethod method, string requestUri, IDictionary<string, object?>? query = null, HttpContent? content = null) {
		var request = new HttpRequestMessage(method, new Uri(BaseUrl, $"{requestUri}?{NewQueryString(query)}"));
		if (content is not null) request.Content = content;
		if (IsAuthenticated) request.Headers.Authorization = new("Bearer", accessToken.Value);
		request.Headers.Add("User-Agent", UserAgent);
		return request;
	}

	/// <summary>
	/// Creates a new collection encapsulating a query string.
	/// </summary>
	/// <param name="parameters">The query parameters whose elements are copied to the collection.</param>
	/// <returns>The newly created query string collection.</returns>
	private static NameValueCollection NewQueryString(IDictionary<string, object?>? parameters = null) {
		var queryString = HttpUtility.ParseQueryString("");
		if (parameters is not null)
			foreach (var parameter in parameters)
				queryString.Add(parameter.Key, parameter.Value is null ? null : Convert.ToString(parameter.Value, CultureInfo.InvariantCulture));

		return queryString;
	}
}
