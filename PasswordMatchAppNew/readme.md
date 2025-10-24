## Overview

Demonstrates `password matching` functionality using NuGet package `FluentValidation` for input validation. Validators can be used in other project types besides console applications.

This project is a simplier and better version than `PasswordMatchApp` project to learn from.

## Features

- User registration with password confirmation
- Password strength validation
- Email validation (see comments)
- Phone number validation



## Validation Rules

The application uses FluentValidation to enforce validation rules for user input. The following validators are included:

- **UserNameValidator**: Validates the user's name.
- **PasswordValidator**: Validates the user's password.
- **EmailAddressValidator**: Validates the user's email address.
- **PhoneNumberValidator**: Validates the user's phone number.


## ValidationLibrary

Contains the validators.