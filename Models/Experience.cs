namespace PortfolioApi.Models;

public class Experience
{
    public string Role { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Period { get; set; } = string.Empty;
    public List<string> Responsibilities { get; set; } = new();
}
