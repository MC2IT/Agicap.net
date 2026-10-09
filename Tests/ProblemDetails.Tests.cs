namespace Mc2it.Agicap;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="ProblemDetails"/> class.
/// </summary>
[TestClass]
public class ProblemDetailsTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/ProblemDetails.json"));
		var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(json, JsonSerializerOptions.Web)!;

		problemDetails.Detail.ShouldBe("The request body is invalid and not meeting business rules.");
		problemDetails.Extensions.Count.ShouldBe(2);
		problemDetails.Status.ShouldBe(422);
		problemDetails.Title.ShouldBe("Business Rule Violation");
		problemDetails.Type.ShouldBe(new Uri("https://problems-registry.smartbear.com/business-rule-violation"));

		var code = problemDetails.Extensions["code"];
		code.ValueKind.ShouldBe(JsonValueKind.String);
		code.GetString().ShouldBe("422-01");

		var errors = problemDetails.Extensions["errors"];
		errors.ValueKind.ShouldBe(JsonValueKind.Object);
		errors.GetProperty("quantity").GetString().ShouldBe("maximum quantity is 999");
	}
}
