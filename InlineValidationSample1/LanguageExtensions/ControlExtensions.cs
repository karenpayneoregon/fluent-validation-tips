namespace InlineValidationSample1.LanguageExtensions;

public static class ControlExtensions
{
    /// <summary>
    /// Base method for obtaining controls on a form or within a container like a panel or group box
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="control"></param>
    /// <returns></returns>
    public static IEnumerable<T> Descendants<T>(this Control control) where T : class
    {
        foreach (Control child in control.Controls)
        {
            if (child is T thisControl)
            {
                yield return (T)thisControl;
            }

            if (child.HasChildren)
            {
                foreach (T descendant in child.Descendants<T>())
                {
                    yield return descendant;
                }
            }
        }
    }

  
    /// <summary>
    /// Get selected/checked RadioButton for a control such as a panel, group box or form
    /// </summary>
    /// <param name="control">control, form, panel or group box</param>
    /// <param name="checked">True false, defaults to true</param>
    /// <returns>One checked Radio button or an empty value</returns>
    public static RadioButton RadioButtonChecked(this Control control, bool @checked = true) 
        => control.Descendants<RadioButton>().ToList()
            .FirstOrDefault((radioButton) => radioButton.Checked == @checked)!;
}