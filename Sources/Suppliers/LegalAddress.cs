namespace Mc2it.Agicap.Suppliers;

using System.Text.Json.Serialization;

/// <summary>
/// The legal address of a supplier.
/// </summary>
public class LegalAddress {

	/// <summary>
	/// The name of the city.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? City { get; set; }

	/// <summary>
	/// The ISO 3166 alpha-2 code of the country in which the supplier is located.
	/// </summary>
	public string Country { get; set; } = "";

	/// <summary>
	/// Value indicating whether this legal address is empty.
	/// </summary>
	[JsonIgnore]
	public bool IsEmpty =>
		string.IsNullOrWhiteSpace(City) &&
		string.IsNullOrWhiteSpace(Country) &&
		string.IsNullOrWhiteSpace(Number) &&
		string.IsNullOrWhiteSpace(PostalCode) &&
		string.IsNullOrWhiteSpace(State) &&
		string.IsNullOrWhiteSpace(StreetName);

	/// <summary>
	/// The address number.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? Number { get; set; }

	/// <summary>
	/// The postal code of the supplier location.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? PostalCode { get; set; }

	/// <summary>
	/// The state in which the supplier is located.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? State { get; set; }

	/// <summary>
	/// The street name.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? StreetName { get; set; }
}
