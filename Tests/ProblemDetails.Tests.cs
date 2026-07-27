namespace Mc2it.Agicap;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="ProblemDetails"/> class.
/// </summary>
[TestClass]
public sealed class ProblemDetailsTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/ProblemDetails.json"));
		var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(json, JsonSerializerOptions.Web)!;
		AreEqual("The request body is invalid and not meeting business rules.", problemDetails.Detail);
		HasCount(2, problemDetails.Extensions);
		AreEqual(422, problemDetails.Status);
		AreEqual("Business Rule Violation", problemDetails.Title);
		AreEqual(new Uri("https://problems-registry.smartbear.com/business-rule-violation"), problemDetails.Type);

		var code = problemDetails.Extensions["code"];
		AreEqual(JsonValueKind.String, code.ValueKind);
		AreEqual("422-01", code.GetString());

		var errors = problemDetails.Extensions["errors"];
		AreEqual(JsonValueKind.Object, errors.ValueKind);
		AreEqual("maximum quantity is 999", errors.GetProperty("quantity").GetString());
	}
}
