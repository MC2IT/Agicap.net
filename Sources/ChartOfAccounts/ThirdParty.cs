namespace Mc2it.Agicap.ChartOfAccounts;

using System.Text.Json.Serialization;

/// <summary>
/// Represents a third-party.
/// </summary>
public class ThirdParty {

	/// <summary>
	/// The accounting account number.
	/// </summary>
	public string AccountingAccountNumber { get; set; } = "";

	/// <summary>
	/// An optional ERP-specific external identifier.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? ExternalId { get; set; }

	/// <summary>
	/// The code of this third-party.
	/// </summary>
	public string ThirdPartyCode { get; set; } = "";

	/// <summary>
	/// The name of this third-party.
	/// </summary>
	public string ThirdPartyName { get; set; } = "";
}
