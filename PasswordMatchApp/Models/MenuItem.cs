namespace PasswordMatchApp.Models;

public class MenuItem
{
    public int Id { get; set; }
    public string Text { get; set; }
    public double Price { get; set; }
    // what to display in menu
    public override string ToString() => Text;
}

