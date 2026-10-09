namespace Mc2it.Agicap.Organizations;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="Entity"/> class.
/// </summary>
[TestClass]
public class EntityTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Organizations/Entity.json"));
		var entity = JsonSerializer.Deserialize<Entity>(json, JsonSerializerOptions.Web)!;

		entity.Country.ShouldBe("FR");
		entity.Id.ShouldBe(666);
		entity.Name.ShouldBe("My Entity");
	}
}
