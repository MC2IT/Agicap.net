namespace Mc2it.Agicap.Payments;

using System.Text.Json.Serialization;

/// <summary>
/// Represents the bank account of a beneficiary.
/// </summary>
public class BankAccount: IEquatable<BankAccount> {

	/// <summary>
	/// The name of the bank the account is located.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? BankName { get; set; }

	/// <summary>
	/// The bank identifier code of the bank where the account is located.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? Bic { get; set; }

	/// <summary>
	/// The ISO 3166 alpha-2 code of the country of the bank where the account is located.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? Country { get; set; }

	/// <summary>
	/// The bank account number (IBAN/BBAN/Other).
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? Identifier { get; set; }

	/// <summary>
	/// Value indicating whether this bank account is empty.
	/// </summary>
	public bool IsEmpty =>
		string.IsNullOrWhiteSpace(BankName) &&
		string.IsNullOrWhiteSpace(Bic) &&
		string.IsNullOrWhiteSpace(Country) &&
		string.IsNullOrWhiteSpace(Identifier) &&
		string.IsNullOrWhiteSpace(IntermediaryBankBic) &&
		string.IsNullOrWhiteSpace(LocalClearingCode);

	/// <summary>
	/// The bank identifier code of the intermediary bank processing the payments.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? IntermediaryBankBic { get; set; }

	/// <summary>
	/// The local identifier of the bank.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? LocalClearingCode { get; set; }

	/// <summary>
	/// Determines whether the two specified objects are equal.
	/// </summary>
	/// <param name="object1">The first object.</param>
	/// <param name="object2">The second object.</param>
	/// <returns><see langword="true"/> if <paramref name="object1"/> equals <paramref name="object2"/>, otherwise <see langword="false"/>.</returns>
	public static bool operator ==(BankAccount? object1, BankAccount? object2) =>
		ReferenceEquals(object1, object2) || (object1?.Equals(object2) ?? false);

	/// <summary>
	/// Determines whether the two specified objects are not equal.
	/// </summary>
	/// <param name="object1">The first object.</param>
	/// <param name="object2">The second object.</param>
	/// <returns><see langword="true"/> if <paramref name="object1"/> does not equal <paramref name="object2"/>, otherwise <see langword="false"/>.</returns>
	public static bool operator !=(BankAccount? object1, BankAccount? object2) => !(object1 == object2);

	/// <summary>
	/// Determines whether the specified object is equal to this object.
	/// </summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns><see langword="true"/> if the specified object is equal to this object, otherwise <see langword="false"/>.</returns>
	public override bool Equals(object? other) => Equals(other as BankAccount);

	/// <summary>
	/// Determines whether the specified object is equal to this object.
	/// </summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns><see langword="true"/> if the specified object is equal to this object, otherwise <see langword="false"/>.</returns>
	public bool Equals(BankAccount? other) => other is not null &&
		BankName == other.BankName &&
		Bic == other.Bic &&
		Country == other.Country &&
		Identifier == other.Identifier &&
		IntermediaryBankBic == other.IntermediaryBankBic &&
		LocalClearingCode == other.LocalClearingCode;

	/// <summary>
	/// Gets the hash code for this object.
	/// </summary>
	/// <returns>The hash code for this object.</returns>
	public override int GetHashCode() =>
		HashCode.Combine(BankName, Bic, Country, Identifier, IntermediaryBankBic, LocalClearingCode);
}
