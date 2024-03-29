﻿using FluentValidation.Results;
using NorthWindLibrary.Models;
using NorthWindLibrary.Validators;
using ValidationUnitTestProject.Base;

namespace ValidationUnitTestProject;

/// <summary>
/// 
/// </summary>
[TestClass]
public partial class NorthWindTest : TestBase
{
    /// <summary>
    /// Validate that a new <see cref="Categories.CategoryName"/> is a unique name.
    /// </summary>
    [TestMethod]
    [TestTraits(Trait.Validation)]
    public void CategoryNameExistsTest()
    {
        Categories category = new() { CategoryName = "Produce" };

        CategoryValidator validator = new();
        ValidationResult result = validator.Validate(category);

        Assert.IsFalse(result.IsValid);
    }

    /// <summary>
    /// Validate that a new <see cref="Categories.CategoryName"/> is a unique name.
    /// </summary>
    [TestMethod]
    [TestTraits(Trait.Validation)]
    public void CategoryNameDoesNExistsTest()
    {
        Categories category = new() { CategoryName = "Coffee" };

        CategoryValidator validator = new();
        ValidationResult result = validator.Validate(category);

        Assert.IsTrue(result.IsValid);
    }
}