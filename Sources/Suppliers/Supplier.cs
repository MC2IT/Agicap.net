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

	/// <summary>
	/// The date and time at which the supplier was created in Agicap.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWriting)]
	public DateTime? CreatedAt { get; set; }

	/// <summary>
	/// The identifier of the supplier in the ERP software.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? ErpId { get; set; }

	/// <summary>
	/// The supplier identifier.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWriting)]
	public Guid Id { get; set; }

	/// <summary>
	/// The ISO 639-1 code of the supplier preferred language.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? Language { get; set; }

	/// <summary>
	/// The legal address of this supplier.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public LegalAddress? LegalAddress { get; set; }

	/// <summary>
	/// The legal registration identifier (e.g. LEI, SIRET, company number...).
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? LegalCompanyId { get; set; }

	/// <summary>
	/// The legal name of this supplier, when it differs from the display name.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? LegalName { get; set; }

	/// <summary>
	/// The display name.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? Name { get; set; }

	/// <summary>
	/// The primary contact of this supplier.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public Contact? PrimaryContact { get; set; }

	/// <summary>
	/// The lifecycle status of this supplier, as pushed by the ERP software.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? Status { get; set; }

	/// <summary>
	/// The tags associated with this supplier.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public IList<string>? Tags { get; set; }

	/// <summary>
	/// The third-party accounting code of this supplier.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? ThirdPartyCode { get; set; }

	/// <summary>
	/// The date and time at which the supplier was updated in Agicap.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWriting)]
	public DateTime? UpdatedAt { get; set; }

	/// <summary>
	/// The VAT code of this supplier.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? VatCode { get; set; }
}
