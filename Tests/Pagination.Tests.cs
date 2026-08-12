namespace Mc2it.Agicap;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="Pagination"/> class.
/// </summary>
[TestClass]
public sealed class PaginationTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Pagination.json"));
		var pagination = JsonSerializer.Deserialize<Pagination>(json, JsonSerializerOptions.Web)!;

		AreEqual(18, pagination.CurrentPageItemsCount);
		AreEqual(2, pagination.CurrentPageNumber);
		IsFalse(pagination.HasNextPage);
		IsTrue(pagination.HasPreviousPage);
		AreEqual(2, pagination.PagesCount);
		AreEqual(33, pagination.PageSize);
		AreEqual(51, pagination.TotalItemsCount);
	}
}
