﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaxpayerValidation.LanguageExtensions;

namespace TaxpayerValidation.Models;

public partial class Taxpayer
{
    public int Id { get; set; }

    [Display(Name = "First name")]
    public string FirstName { get; set; }

    [Display(Name = "Last name")]
    public string LastName { get; set; }

    [Display(Name = "Social Security Number")]
    public string SSN { get; set; }

    [NotMapped]
    public string SsnHidden => SSN.MaskSsn(5);

    [Display(Name = "Pin")]
    public string PIN { get; set; }

    [Display(Name = "Start date")]
    public DateOnly StartDate { get; set; }
}