namespace Mc2it.Agicap.Suppliers;

using System.Text.Json.Serialization;

/// <summary>
/// Represents a supplier.
/// </summary>
public class Supplier {

	/// <summary>
	/// The contacts of this supplier.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public IList<Contact>? Contacts { get; set; }
}
