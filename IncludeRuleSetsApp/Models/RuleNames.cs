using IncludeRuleSetsApp.Validators;

namespace IncludeRuleSetsApp.Models;
/// <summary>
/// Represents a collection of rule names used for validation purposes.
/// </summary>
/// <remarks>
/// This class defines properties corresponding to specific rule sets, such as:
/// <list type="bullet">
/// <item>
/// <description><c>Names</c>: Represents rules related to name validation.</description>
/// </item>
/// <item>
/// <description><c>Identifier</c>: Represents rules related to identifier validation.</description>
/// </item>
/// <item>
/// <description><c>Birth</c>: Represents rules related to birthdate validation.</description>
/// </item>
/// </list>
/// These rule names are utilized in conjunction with validators, such as <see cref="PersonValidator"/>, 
/// to enforce specific validation logic.
/// </remarks>
public class RuleNames
{
    public string Names { get; set; }
    public string Identifier { get; set; }
    public string Birth { get; set; }
    
}
