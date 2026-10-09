namespace Mc2it.Agicap.Payments;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="BeneficiarySynchronization"/> class.
/// </summary>
[TestClass]
public class BeneficiarySynchronizationTests {

	[TestMethod]
	public void FromJson() {
		var date = new DateTime(2026, 8, 3, 8, 21, 47, DateTimeKind.Utc).Date;
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Payments/BeneficiarySynchronization.json"));
		var synchronization = JsonSerializer.Deserialize<BeneficiarySynchronization>(json, JsonSerializerOptions.Web)!;

		synchronization.CreatedAt.Date.ShouldBe(date);
		synchronization.Errors.Count.ShouldBe(1);
		synchronization.FinishedAt?.Date.ShouldBe(date);
		synchronization.Status.ShouldBe(BeneficiarySynchronizationStatus.CompletedWithErrors);
		synchronization.SyncId.ShouldBe(new Guid("3c648676-e07e-4aca-8e63-ce0802221b57"));
	}
}

/// <summary>
/// Tests the features of the <see cref="BeneficiarySynchronizationError"/> class.
/// </summary>
[TestClass]
public class BeneficiarySynchronizationErrorTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Payments/BeneficiarySynchronizationError.json"));
		var error = JsonSerializer.Deserialize<BeneficiarySynchronizationError>(json, JsonSerializerOptions.Web)!;
		error.ErrorCode.ShouldBe(BeneficiarySynchronizationErrorCode.IncompletePostalAddress);
		error.ErrorMessage.ShouldStartWith("The synchronization failed");
		error.RowIndex.ShouldBe(0);

		var beneficiary = error.Beneficiary;
		beneficiary.ShouldNotBeNull();
		beneficiary.ErpId.ShouldBe("MC2IT-DEVELOPMENT");
		beneficiary.Name.ShouldBe("MC2IT Development Department");
		beneficiary.PostalAddress?.Country.ShouldBe("ZZZZ");
	}
}
