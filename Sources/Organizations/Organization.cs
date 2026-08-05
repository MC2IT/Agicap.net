namespace Mc2it.Agicap.Organizations;

/// <summary>
/// Represents an organization.
/// </summary>
public class Organization {

	/// <summary>
	/// The organization identifier.
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// The organization name.
	/// </summary>
	public string Name { get; set; } = "";
}
