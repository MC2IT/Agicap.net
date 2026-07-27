namespace Mc2it.Agicap.Authentication;

using System.Text.Json.Serialization;

/// <summary>
///	Represents an OAuth token and its metadata.
/// </summary>
public sealed class AccessToken {

	/// <summary>
	/// The number of seconds when this token will expire.
	/// </summary>
	[JsonInclude, JsonPropertyName("expires_in")]
	internal int ExpiresIn {
		get => (int) (ExpiresOn - DateTime.Now).TotalSeconds;
		set => ExpiresOn = DateTime.Now.AddSeconds(value);
	}

	/// <summary>
	/// The time when this token expires.
	/// </summary>
	[JsonIgnore]
	public DateTime ExpiresOn { get; set; } = DateTime.Now;

	/// <summary>
	/// Value indicating whether this token has expired.
	/// </summary>
	[JsonIgnore]
	public bool HasExpired => ExpiresOn <= DateTime.Now;

	/// <summary>
	/// The OAuth scopes.
	/// </summary>
	[JsonInclude, JsonPropertyName("scope")]
	internal string Scope {
		get => string.Join(' ', Scopes);
		set => Scopes = value.Length > 0 ? [.. value.Split(' ')] : new List<string>();
	}

	/// <summary>
	/// The OAuth scopes.
	/// </summary>
	[JsonIgnore]
	public IList<string> Scopes { get; set; } = [];

	/// <summary>
	/// The token type.
	/// </summary>
	[JsonPropertyName("token_type")]
	public string Type { get; set; } = "Bearer";

	/// <summary>
	/// The token value.
	/// </summary>
	[JsonPropertyName("access_token")]
	public string Value { get; set; } = "";
}
