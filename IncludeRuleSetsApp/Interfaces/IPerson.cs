namespace IncludeRuleSetsApp.Interfaces;

public interface IPerson
{
    int PersonId { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string EmailAddress { get; set; }
    DateOnly BirthDate { get; set; }
}