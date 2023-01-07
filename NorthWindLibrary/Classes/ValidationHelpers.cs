using NorthWindLibrary.Data;
using NorthWindLibrary.Models;

namespace NorthWindLibrary.Classes;
public static class ValidationHelpers
{
    /// <summary>
    /// Validate we are not going to add a duplicate category name
    /// </summary>
    /// <param name="category"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static bool UniqueName(Categories category, string name)
    {
        Context context = new Context();
        var categoryItem = context.Categories.AsEnumerable()
            .SingleOrDefault(cat =>
                string.Equals(cat.CategoryName.ToLower(), name.ToLower(), StringComparison.OrdinalIgnoreCase));



        if (categoryItem == null)
        {
            return true;
        }

        return categoryItem.CategoryId == category.CategoryId;
    }
}