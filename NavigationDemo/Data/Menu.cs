using System.Text.Json.Serialization;

namespace NavigationDemo.Data;

public class Menu
{
    public Guid Id { get; private set; }

    public Guid? ParentId { get; set; }

    private string? _href;

    public string? Href
    {
        get => _href == "" ? null : _href;
        set => _href = value;
    }

    private string? _icon;

    public string? Icon
    {
        get => _icon == "" ? null : _icon;
        set => _icon = value;
    }

    public string Title { get; set; }

    public int Sort { get; set; }

    [JsonIgnore]
    public List<Menu> Childrens { get; set; }

    public bool Actived { get; set; }

    public Menu()
    {
        Id = Guid.Empty;
        ParentId = null;
        Href = "";
        Icon = "";
        Title = "";
        Sort = 1;
        Childrens = new();
    }

    public Menu(string title, string? href, string? icon,  int sort, Guid? parentId = null, List<Menu>? children = null)
    {
        Id = Guid.NewGuid();
        ParentId = parentId;
        Href = href;
        Icon = icon;
        Title = title;
        Sort = sort;
        Childrens = children ?? new();
    }

    [JsonConstructor]
    public Menu(Guid id, Guid? parentId, string? href, string? icon,  string title, int sort, bool actived, List<Menu> childrens)
    {
        Id = id;
        ParentId = parentId;
        Href = href;
        Icon = icon;
        Title = title;
        Sort = sort;
        Actived = actived;
        Childrens = childrens ?? new();
    }
}

