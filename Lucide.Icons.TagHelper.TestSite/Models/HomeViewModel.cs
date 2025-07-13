namespace LucideIconsDotNet.TestSite.Models;

public class HomeViewModel
{
    public List<IconViewModel> Icons { get; } = new List<IconViewModel>();
}

public class IconViewModel
{
    public required string Name { get; set; }
}