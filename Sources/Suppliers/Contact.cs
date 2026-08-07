namespace Mc2it.Agicap.Suppliers;

using System.Text.Json.Serialization;

/// <summary>
/// A contact at a supplier.
/// </summary>
public class Contact {

	/// <summary>
	/// The mail address.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? Email { get; set; }

	/// <summary>
	/// Value indicating whether this contact is empty.
	/// </summary>
	public bool IsEmpty =>
		string.IsNullOrWhiteSpace(Email) &&
		string.IsNullOrWhiteSpace(Name) &&
		string.IsNullOrWhiteSpace(Phone) &&
		string.IsNullOrWhiteSpace(Role);

	/// <summary>
	/// The full name.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? Name { get; set; }

	/// <summary>
	/// The phone number.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? Phone { get; set; }

	/// <summary>
	/// The role within the supplier organization.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? Role { get; set; }
}
