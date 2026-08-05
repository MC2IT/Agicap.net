namespace Mc2it.Agicap.Payments;

using System.Text.Json.Serialization;

/// <summary>
/// Represents a beneficiary.
/// </summary>
public class Beneficiary {

	/// <summary>
	/// The bank account of the beneficiary.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public BankAccount? BankAccount { get; set => field = value is null || value.IsEmpty ? null : value; }

	/// <summary>
	/// The legal registration identifier (e.g. LEI, SIRET, company number...).
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? CompanyLegalIdentifier { get; set; }

	/// <summary>
	/// The beneficiary identifier.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Guid Id { get; set; }

	/// <summary>
	/// The name of the beneficiary.
	/// </summary>
	public string Name { get; set; } = "";

	/// <summary>
	/// The postal address of the beneficiary.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public PostalAddress? PostalAddress { get; set => field = value is null || value.IsEmpty ? null : value; }

	/// <summary>
	/// The uncertainty status.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public UncertaintyStatus? UncertaintyStatus { get; set; }

	/// <summary>
	/// The validation status.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public ValidationStatus? ValidationStatus { get; set; }
}
