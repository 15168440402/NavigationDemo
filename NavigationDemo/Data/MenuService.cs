namespace NavigationDemo.Data;

public class MenuService
{
    List<Menu> Menus { get; set; }
    string FilePath { get; set; }

    public MenuService()
    {
        FilePath = $"{Directory.GetCurrentDirectory()}/menus.json";
        if (File.Exists(FilePath))
        {
            Menus = System.Text.Json.JsonSerializer.Deserialize<List<Menu>>(File.ReadAllText(FilePath)) ?? new();
        }
        if (Menus is null || Menus.Count == 0)
        {
            Menus = new()
            {
                new("Home", "/", "mdi-home-variant-outline", 1),
                new("Counter", "/counter", "mdi-plus-circle-outline", 2),
                new("Fetch data", "/fetchdata", "mdi-table-column-plus-before", 3),
                new("Menus", "/menus", "mdi-menu-open", 4),
            };
        }
    }

    public async Task<List<Menu>> GetMenusAsync()
    {
        return await Task.FromResult(Menus.OrderBy(m => m.Sort).ToList());
    }

    public async Task AddMenuAsync(Menu menu)
    {
        Menus.Add(menu);
        await Save();
    }

    public async Task UpdateMenuAsync(Menu menu)
    {
        Menus.Remove(Menus.First(m => m.Id == menu.Id));
        Menus.Add(menu);
        await Save();
    }

    public async Task RemoveMenuAsync(Menu menu)
    {
        var menus = Menus.Where(m => m.Id == menu.Id || menu.ParentId == menu.Id).ToList();
        foreach (var item in menus)
        {
            Menus.Remove(item);
        }
        await Save();
    }

    private async Task Save()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(Menus);
        await File.WriteAllTextAsync(FilePath, json);
    }
}

