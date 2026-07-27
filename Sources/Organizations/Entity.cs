namespace Mc2it.Agicap.Organizations;

/// <summary>
/// Represents an entity within an organization.
/// </summary>
public class Entity {

	/// <summary>
	/// The ISO 3166 alpha-2 code of the country where the entity is located.
	/// </summary>
	public string Country { get; set; } = "";

	/// <summary>
	/// The entity identifier.
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	/// The entity name.
	/// </summary>
	public string Name { get; set; } = "";
}
