namespace Mc2it.Agicap.ChartOfAccounts;

/// <summary>
/// Tests the features of the <see cref="ThirdPartyApi"/> class.
/// </summary>
/// <param name="testContext">The test context.</param>
[TestClass, CICondition(ConditionMode.Exclude)]
public sealed class ThirdPartyApiTests(TestContext testContext) {

	/// <summary>
	/// The client used to query the Agicap API.
	/// </summary>
	private readonly ThirdPartyApi api = Fixtures.CreateClient().ChartOfAccounts.ThirdParties(Fixtures.EntityId);

	[TestMethod, Timeout(30_000, CooperativeCancellation = true)]
	public async Task CreateUpdateDelete() {
		var thirdParties = new List<ThirdParty> {
			new() {
				AccountingAccountNumber = "40100000",
				ThirdPartyCode = "MC2IT-DEVELOPMENT",
				ThirdPartyName = $"MC2IT Development Department {Guid.CreateVersion7()}"
			}
		};

		// It should create or update the specified third-party.
		var importResponse = await api.CreateAsync(thirdParties, cancellationToken: testContext.CancellationToken);
		while (importResponse.ImportStatus == ImportStatus.Started) {
			await Task.Delay(2_500, testContext.CancellationToken);
			importResponse = await api.CreateAsync(thirdParties, importResponse.ImportId, testContext.CancellationToken);
		}

		AreEqual(ImportStatus.Done, importResponse.ImportStatus);
		AreEqual(0, importResponse.ImportSummary?.NotImportedCount);

		// It should delete the specified third-party.
		await api.DeleteAsync(thirdParties, testContext.CancellationToken);
	}
}
