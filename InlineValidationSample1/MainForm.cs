using InlineValidationSample1.Classes;
using InlineValidationSample1.LanguageExtensions;
using InlineValidationSample1.Models;
// ReSharper disable CoVariantArrayConversion

namespace InlineValidationSample1;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void ValidateButton_Click(object sender, EventArgs e)
    {
        ErrorListBox.Items.Clear();

        var birthDate = DateOnly.Parse(BirthDateGroupBox.RadioButtonChecked().Text);
        var genderRadioButton = GenderGroupBox.RadioButtonChecked();
       
        Person person = new()
        {
            FirstName = FirstNameTextBox.Text, 
            LastName = LastNameTextBox.Text,
            Title = TitleComoBox.Text,
            BirthDate = birthDate,
        };


        if (Enum.TryParse(genderRadioButton.Text.Replace(" ",""), true, out Gender gender))
        {
            person.Gender = gender;
        }

        var validator = Person.Validator.Validate(person);

        if (validator.IsValid == false)
        {
            var errors = validator.Errors.Select(x => x.ErrorMessage).ToArray();
            ErrorListBox.Items.AddRange(errors);
        }
        else
        {
            ErrorListBox.Items.Add("Validation successful");
        }
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        var titles = ValidationHelpers.Titles.ToList();
        titles.Insert(0, "Not set");
        TitleComoBox.DataSource = titles;
        TitleComoBox.SelectedIndex = 2;
    }
}
