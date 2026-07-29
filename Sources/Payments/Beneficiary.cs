namespace Mc2it.Agicap.Payments;

using System.Text.Json.Serialization;

/// <summary>
/// Represents a beneficiary.
/// </summary>
public class Beneficiary: IEquatable<Beneficiary> {

	/// <summary>
	/// The bank account of the beneficiary.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public BankAccount? BankAccount { get; set; }

	/// <summary>
	/// The legal entity identifier (LEI).
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? CompanyLegalIdentifier { get; set; }

	/// <summary>
	/// The beneficiary identifier.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Guid Id { get; set; } = Guid.Empty;

	/// <summary>
	/// The name of the beneficiary.
	/// </summary>
	public string Name { get; set; } = "";

	/// <summary>
	/// The postal address of the beneficiary.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public PostalAddress? PostalAddress { get; set; }

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

	/// <summary>
	/// Determines whether the two specified objects are equal.
	/// </summary>
	/// <param name="object1">The first object.</param>
	/// <param name="object2">The second object.</param>
	/// <returns><see langword="true"/> if <paramref name="object1"/> equals <paramref name="object2"/>, otherwise <see langword="false"/>.</returns>
	public static bool operator ==(Beneficiary? object1, Beneficiary? object2) =>
		ReferenceEquals(object1, object2) || (object1?.Equals(object2) ?? false);

	/// <summary>
	/// Determines whether the two specified objects are not equal.
	/// </summary>
	/// <param name="object1">The first object.</param>
	/// <param name="object2">The second object.</param>
	/// <returns><see langword="true"/> if <paramref name="object1"/> does not equal <paramref name="object2"/>, otherwise <see langword="false"/>.</returns>
	public static bool operator !=(Beneficiary? object1, Beneficiary? object2) => !(object1 == object2);

	/// <summary>
	/// Determines whether the specified object is equal to this object.
	/// </summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns><see langword="true"/> if the specified object is equal to this object, otherwise <see langword="false"/>.</returns>
	public override bool Equals(object? other) => Equals(other as Beneficiary);

	/// <summary>
	/// Determines whether the specified object is equal to this object.
	/// </summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns><see langword="true"/> if the specified object is equal to this object, otherwise <see langword="false"/>.</returns>
	public bool Equals(Beneficiary? other) => other is not null &&
		BankAccount == other.BankAccount &&
		Id == other.Id &&
		Name == other.Name &&
		PostalAddress == other.PostalAddress &&
		UncertaintyStatus == other.UncertaintyStatus &&
		ValidationStatus == other.ValidationStatus;

	/// <summary>
	/// Gets the hash code for this object.
	/// </summary>
	/// <returns>The hash code for this object.</returns>
	public override int GetHashCode() =>
		HashCode.Combine(BankAccount, Id, Name, PostalAddress, UncertaintyStatus, ValidationStatus);
}
