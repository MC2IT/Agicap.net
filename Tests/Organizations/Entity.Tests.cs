namespace Mc2it.Agicap.Organizations;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="Entity"/> class.
/// </summary>
[TestClass]
public sealed class EntityTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Organizations/Entity.json"));
		var entity = JsonSerializer.Deserialize<Entity>(json, JsonSerializerOptions.Web)!;

		Assert.AreEqual("FR", entity.Country);
		Assert.AreEqual(666, entity.Id);
		Assert.AreEqual("My Entity", entity.Name);
	}
}
