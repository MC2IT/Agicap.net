namespace Mc2it.Agicap.Payments;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="BeneficiarySynchronization"/> class.
/// </summary>
[TestClass]
public sealed class BeneficiarySynchronizationTests {

	[TestMethod]
	public void FromJson() {
		var date = new DateTime(2026, 8, 3, 8, 21, 47, DateTimeKind.Utc).Date;
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Payments/BeneficiarySynchronization.json"));
		var synchronization = JsonSerializer.Deserialize<BeneficiarySynchronization>(json, JsonSerializerOptions.Web)!;

		AreEqual(date, synchronization.CreatedAt.Date);
		HasCount(1, synchronization.Errors);
		AreEqual(date, synchronization.FinishedAt?.Date);
		AreEqual(BeneficiarySynchronizationStatus.CompletedWithErrors, synchronization.Status);
		AreEqual(new Guid("3c648676-e07e-4aca-8e63-ce0802221b57"), synchronization.SyncId);
	}
}
