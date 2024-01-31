namespace ValidateItemInListApp.Models;
public class Master
{
    public int Id { get; set; }
    public string FamilyName { get; set; }
    public List<string> ValidNames;
    public List<Child> Children;
}