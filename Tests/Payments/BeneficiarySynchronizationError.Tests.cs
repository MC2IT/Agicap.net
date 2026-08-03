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
		var error = JsonSerializer.Deserialize<BeneficiarySynchronizationError>(json, JsonSerializerOptions.Web)!;
		AreEqual(BeneficiarySynchronizationErrorCode.IncompletePostalAddress, error.ErrorCode);
		StartsWith("The synchronization failed", error.ErrorMessage);
		AreEqual(0, error.RowIndex);

		var beneficiary = error.Beneficiary;
		IsNotNull(beneficiary);
		AreEqual("MC2IT-DEVELOPMENT", beneficiary.ErpId);
		AreEqual("MC2IT Service Développement", beneficiary.Name);
		AreEqual("ZZZZ", beneficiary.PostalAddress?.Country);
	}
}
