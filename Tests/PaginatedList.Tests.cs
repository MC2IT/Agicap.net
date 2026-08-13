namespace Mc2it.Agicap;

using Mc2it.Agicap.Organizations;
using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="PaginatedList"/> class.
/// </summary>
[TestClass]
public sealed class PaginatedListTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/PaginatedList.json"));
		var list = JsonSerializer.Deserialize<PaginatedList<Organization>>(json, JsonSerializerOptions.Web)!;
		HasCount(2, list.Items);

		var firstItem = list.Items.First();
		AreEqual(new Guid("3ebb0163-6ac8-449d-a34b-496244f380a1"), firstItem.Id);
		AreEqual("Company #1", firstItem.Name);

		var lastItem = list.Items.Last();
		AreEqual(new Guid("866faf6e-19c3-4131-97da-c50ff9a92961"), lastItem.Id);
		AreEqual("Company #2", lastItem.Name);

		var pagination = list.Pagination;
		AreEqual(2, pagination.CurrentPageItemsCount);
		AreEqual(1, pagination.CurrentPageNumber);
		AreEqual(1, pagination.PagesCount);
		AreEqual(10, pagination.PageSize);
		AreEqual(2, pagination.TotalItemsCount);
	}
}
