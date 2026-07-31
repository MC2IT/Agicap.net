namespace Mc2it.Agicap.Payments;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="SynchronizationIdentifier"/> class.
/// </summary>
[TestClass]
public sealed class SynchronizationIdentifierTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Payments/SynchronizationIdentifier.json"));
		var synchronizationIdentifier = JsonSerializer.Deserialize<SynchronizationIdentifier>(json, JsonSerializerOptions.Web)!;
		AreEqual(new Guid("cacc91f4-e9af-45b3-8fc5-8b2524c47d70"), synchronizationIdentifier.SyncId);
	}
}
