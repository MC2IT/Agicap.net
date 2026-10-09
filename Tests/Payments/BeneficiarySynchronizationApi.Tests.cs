namespace Mc2it.Agicap.Payments;

/// <summary>
/// Tests the features of the <see cref="BeneficiarySynchronizationApi"/> class.
/// </summary>
/// <param name="testContext">The test context.</param>
[TestClass, CICondition(ConditionMode.Exclude)]
public class BeneficiarySynchronizationApiTests(TestContext testContext) {

	/// <summary>
	/// The client used to query the Agicap API.
	/// </summary>
	private readonly BeneficiarySynchronizationApi api = Fixtures.CreateClient().Payments.Beneficiaries(Fixtures.EntityId).Synchronization;

	[TestMethod]
	public async Task Create() {
		var beneficiary = new SynchronizedBeneficiary {
			ErpId = "MC2IT-DEVELOPMENT",
			Name = "MC2IT Development Department",
			PostalAddress = new() { City = "Fabrègues", Country = "FR", StreetName = "Rue Gine" }
		};

		(await api.CreateAsync([beneficiary], testContext.CancellationToken)).ShouldNotBe(Guid.Empty);
	}

	[TestMethod]
	public async Task Read() {
		var syncId = new Guid("3c648676-e07e-4aca-8e63-ce0802221b57");

		var synchronization = await api.ReadAsync(syncId, cancellationToken: testContext.CancellationToken);
		synchronization.CreatedAt.Date.ShouldBe(new DateTime(2026, 8, 3, 0, 0, 0, DateTimeKind.Utc));
		synchronization.Errors.Count.ShouldBe(1);
		synchronization.Status.ShouldBe(BeneficiarySynchronizationStatus.CompletedWithErrors);
		synchronization.SyncId.ShouldBe(syncId);

		var error = synchronization.Errors.First();
		error.ErrorCode.ShouldBe(BeneficiarySynchronizationErrorCode.IncompletePostalAddress);
		error.ErrorMessage.ShouldStartWith("The synchronization failed");
		error.RowIndex.ShouldBe(0);
	}
}
