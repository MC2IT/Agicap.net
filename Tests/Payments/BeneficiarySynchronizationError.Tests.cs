namespace Mc2it.Agicap.Payments;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="BeneficiarySynchronizationError"/> class.
/// </summary>
[TestClass]
public sealed class BeneficiarySynchronizationErrorTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Payments/BeneficiarySynchronizationError.json"));
		var synchronizationError = JsonSerializer.Deserialize<BeneficiarySynchronizationError>(json, JsonSerializerOptions.Web)!;
		AreEqual(BeneficiarySynchronizationErrorCode.IncompletePostalAddress, synchronizationError.ErrorCode);
		StartsWith("The synchronization failed", synchronizationError.ErrorMessage);
		AreEqual(0, synchronizationError.RowIndex);

		var beneficiary = synchronizationError.Beneficiary;
		IsNotNull(beneficiary);
		AreEqual("MC2IT-DEVELOPMENT", beneficiary.ErpId);
		AreEqual("MC2IT Service Développement", beneficiary.Name);
		AreEqual("ZZZZ", beneficiary.PostalAddress?.Country);
	}
}
