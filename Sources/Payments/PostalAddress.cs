namespace Mc2it.Agicap.Payments;

using System.Text.Json.Serialization;

/// <summary>
/// The postal address of a beneficiary.
/// </summary>
public class PostalAddress {

	/// <summary>
	/// The name of the city.
	/// </summary>
	public string City { get; set; } = "";

	/// <summary>
	/// The ISO 3166 alpha-2 code of the country in which the beneficiary is located.
	/// </summary>
	public string Country { get; set; } = "";

	/// <summary>
	/// Value indicating whether this postal address is empty.
	/// </summary>
	[JsonIgnore]
	public bool IsEmpty =>
		string.IsNullOrWhiteSpace(City) &&
		string.IsNullOrWhiteSpace(Country) &&
		string.IsNullOrWhiteSpace(Number) &&
		string.IsNullOrWhiteSpace(State) &&
		string.IsNullOrWhiteSpace(StreetName) &&
		string.IsNullOrWhiteSpace(ZipCode);

	/// <summary>
	/// The address number.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? Number { get; set; }

	/// <summary>
	/// The state in which the beneficiary is located.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? State { get; set; }

	/// <summary>
	/// The street name.
	/// </summary>
	public string StreetName { get; set; } = "";

	/// <summary>
	/// The postal code of the beneficiary location.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? ZipCode { get; set; }
}
