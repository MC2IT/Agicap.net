namespace Mc2it.Agicap;

using Mc2it.Agicap.Organizations;
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

		Assert.AreEqual(18, pagination.CurrentPageItemsCount);
		Assert.AreEqual(2, pagination.CurrentPageNumber);
		Assert.IsFalse(pagination.HasNextPage);
		Assert.IsTrue(pagination.HasPreviousPage);
		Assert.AreEqual(2, pagination.PagesCount);
		Assert.AreEqual(33, pagination.PageSize);
		Assert.AreEqual(51, pagination.TotalItemsCount);
	}
}

/// <summary>
/// Tests the features of the <see cref="PaginatedList"/> class.
/// </summary>
[TestClass]
public sealed class PaginatedListTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/PaginatedList.json"));
		var list = JsonSerializer.Deserialize<PaginatedList<Organization>>(json, JsonSerializerOptions.Web)!;
		Assert.HasCount(2, list.Items);

		var firstItem = list.Items.First();
		Assert.AreEqual(new Guid("3ebb0163-6ac8-449d-a34b-496244f380a1"), firstItem.Id);
		Assert.AreEqual("Company #1", firstItem.Name);

		var lastItem = list.Items.Last();
		Assert.AreEqual(new Guid("866faf6e-19c3-4131-97da-c50ff9a92961"), lastItem.Id);
		Assert.AreEqual("Company #2", lastItem.Name);

		var pagination = list.Pagination;
		Assert.AreEqual(2, pagination.CurrentPageItemsCount);
		Assert.AreEqual(1, pagination.CurrentPageNumber);
		Assert.AreEqual(1, pagination.PagesCount);
		Assert.AreEqual(10, pagination.PageSize);
		Assert.AreEqual(2, pagination.TotalItemsCount);
	}
}
