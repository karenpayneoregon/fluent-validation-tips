﻿using System.Text.RegularExpressions;

namespace ValidationLibrary.Validators;

    public partial class SpecialValidation
    {
        /// <summary>
        /// Is a valid SSN
        /// </summary>
        /// <returns>True if valid, false if invalid SSN</returns>
        /// <remarks>
        /// 
        /// Guaranteed to never be an empty string or null, client code handles this. 
        /// 
        /// ^                                       #Start of expression
        /// (?!\b(\d)\1+-(\d)\1+-(\d)\1+\b)         #Don't allow all matching digits for every field
        /// (?!123-45-6789|219-09-9999|078-05-1120) #Don't allow "123-45-6789", "219-09-9999" or "078-05-1120"
        /// (?!666|000|9\d{2})\d{3}                 #Don't allow the SSN to begin with 666, 000 or anything between 900-999
        /// -                                       #A dash (separating Area and Group numbers)
        /// (?!00)\d{2}                             #Don't allow the Group Number to be "00"
        /// -                                       #Another dash (separating Group and Serial numbers)
        /// (?!0{4})\d{4}                           #Don't allow last four digits to be "0000"
        /// $                                       #End of expression
        /// </remarks>
        public bool IsValidSocialSecurityNumber(string value) => SSNValidationRegex().IsMatch(value.Replace("-", ""));
        [GeneratedRegex("^(?!\\b(\\d)\\1+\\b)(?!123456789|219099999|078051120)(?!666|000|9\\d{2})\\d{3}(?!00)\\d{2}(?!0{4})\\d{4}$")]
        private static partial Regex SSNValidationRegex();
    }