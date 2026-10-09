namespace Mc2it.Agicap.Authentication;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="BadRequest"/> class.
/// </summary>
[TestClass]
public class BadRequestTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Authentication/BadRequest.json"));
		var badRequest = JsonSerializer.Deserialize<BadRequest>(json, JsonSerializerOptions.Web)!;
		badRequest.Error.ShouldBe("An error occurred.");
	}
}
