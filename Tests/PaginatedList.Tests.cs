namespace Mc2it.Agicap;

using Mc2it.Agicap.Organizations;
using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="Pagination"/> class.
/// </summary>
[TestClass]
public class PaginationTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Pagination.json"));
		var pagination = JsonSerializer.Deserialize<Pagination>(json, JsonSerializerOptions.Web)!;

		pagination.CurrentPageItemsCount.ShouldBe(18);
		pagination.CurrentPageNumber.ShouldBe(2);
		pagination.HasNextPage.ShouldBeFalse();
		pagination.HasPreviousPage.ShouldBeTrue();
		pagination.PagesCount.ShouldBe(2);
		pagination.PageSize.ShouldBe(33);
		pagination.TotalItemsCount.ShouldBe(51);
	}
}

/// <summary>
/// Tests the features of the <see cref="PaginatedList"/> class.
/// </summary>
[TestClass]
public class PaginatedListTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/PaginatedList.json"));
		var list = JsonSerializer.Deserialize<PaginatedList<Organization>>(json, JsonSerializerOptions.Web)!;
		list.Items.Count.ShouldBe(2);

		var firstItem = list.Items.First();
		firstItem.Id.ShouldBe(new Guid("3ebb0163-6ac8-449d-a34b-496244f380a1"));
		firstItem.Name.ShouldBe("Company #1");

		var lastItem = list.Items.Last();
		lastItem.Id.ShouldBe(new Guid("866faf6e-19c3-4131-97da-c50ff9a92961"));
		lastItem.Name.ShouldBe("Company #2");

		var pagination = list.Pagination;
		pagination.CurrentPageItemsCount.ShouldBe(2);
		pagination.CurrentPageNumber.ShouldBe(1);
		pagination.PagesCount.ShouldBe(1);
		pagination.PageSize.ShouldBe(10);
		pagination.TotalItemsCount.ShouldBe(2);
	}
}
