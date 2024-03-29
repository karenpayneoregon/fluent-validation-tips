﻿using FluentValidation;
using NorthWindLibrary.Classes;
using NorthWindLibrary.Models;

namespace NorthWindLibrary.Validators;

public class CategoryValidator : AbstractValidator<Categories>
{
    public CategoryValidator()
    {
        RuleFor(category => category.CategoryName)
            .Must((cat, x) => 
                ValidationHelpers.UniqueName(cat, cat.CategoryName));
    }
}