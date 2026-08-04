namespace Mc2it.Agicap.Payments;

/// <summary>
/// Tests the features of the <see cref="BeneficiarySynchronizationApi"/> class.
/// </summary>
/// <param name="testContext">The test context.</param>
[TestClass, CICondition(ConditionMode.Exclude)]
public sealed class BeneficiarySynchronizationApiTests(TestContext testContext) {

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

		AreNotEqual(Guid.Empty, await api.CreateAsync([beneficiary], testContext.CancellationToken));
	}

	[TestMethod]
	public async Task Read() {
		var syncId = new Guid("3c648676-e07e-4aca-8e63-ce0802221b57");

		var synchronization = await api.ReadAsync(syncId, cancellationToken: testContext.CancellationToken);
		AreEqual(new DateTime(2026, 8, 3, 0, 0, 0, DateTimeKind.Utc), synchronization.CreatedAt.Date);
		HasCount(1, synchronization.Errors);
		AreEqual(BeneficiarySynchronizationStatus.CompletedWithErrors, synchronization.Status);
		AreEqual(syncId, synchronization.SyncId);

		var error = synchronization.Errors.First();
		AreEqual(BeneficiarySynchronizationErrorCode.IncompletePostalAddress, error.ErrorCode);
		StartsWith("The synchronization failed", error.ErrorMessage);
		AreEqual(0, error.RowIndex);
	}
}
