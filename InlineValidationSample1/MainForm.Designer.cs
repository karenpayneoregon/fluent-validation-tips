namespace InlineValidationSample1;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        ValidateButton = new Button();
        TitleComoBox = new ComboBox();
        label1 = new Label();
        FirstNameTextBox = new TextBox();
        label2 = new Label();
        LastNameTextBox = new TextBox();
        label3 = new Label();
        GenderGroupBox = new GroupBox();
        radioButton3 = new RadioButton();
        radioButton2 = new RadioButton();
        radioButton1 = new RadioButton();
        BirthDateGroupBox = new GroupBox();
        radioButton5 = new RadioButton();
        radioButton4 = new RadioButton();
        ErrorListBox = new ListBox();
        GenderGroupBox.SuspendLayout();
        BirthDateGroupBox.SuspendLayout();
        SuspendLayout();
        // 
        // ValidateButton
        // 
        ValidateButton.BackColor = Color.White;
        ValidateButton.Image = Properties.Resources.Check;
        ValidateButton.ImageAlign = ContentAlignment.MiddleLeft;
        ValidateButton.Location = new Point(322, 179);
        ValidateButton.Name = "ValidateButton";
        ValidateButton.Size = new Size(135, 29);
        ValidateButton.TabIndex = 5;
        ValidateButton.Text = "Validate";
        ValidateButton.UseVisualStyleBackColor = false;
        ValidateButton.Click += ValidateButton_Click;
        // 
        // TitleComoBox
        // 
        TitleComoBox.DropDownStyle = ComboBoxStyle.DropDownList;
        TitleComoBox.FormattingEnabled = true;
        TitleComoBox.Location = new Point(33, 46);
        TitleComoBox.Name = "TitleComoBox";
        TitleComoBox.Size = new Size(151, 28);
        TitleComoBox.TabIndex = 0;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(33, 23);
        label1.Name = "label1";
        label1.Size = new Size(38, 20);
        label1.TabIndex = 2;
        label1.Text = "Title";
        // 
        // FirstNameTextBox
        // 
        FirstNameTextBox.Location = new Point(33, 115);
        FirstNameTextBox.Name = "FirstNameTextBox";
        FirstNameTextBox.PlaceholderText = "Required";
        FirstNameTextBox.Size = new Size(221, 27);
        FirstNameTextBox.TabIndex = 1;
        FirstNameTextBox.Text = "Karen";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(33, 92);
        label2.Name = "label2";
        label2.Size = new Size(77, 20);
        label2.TabIndex = 4;
        label2.Text = "First name";
        // 
        // LastNameTextBox
        // 
        LastNameTextBox.Location = new Point(33, 179);
        LastNameTextBox.Name = "LastNameTextBox";
        LastNameTextBox.PlaceholderText = "Required";
        LastNameTextBox.Size = new Size(221, 27);
        LastNameTextBox.TabIndex = 2;
        LastNameTextBox.Text = "Payne";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(33, 156);
        label3.Name = "label3";
        label3.Size = new Size(76, 20);
        label3.TabIndex = 6;
        label3.Text = "Last name";
        // 
        // GenderGroupBox
        // 
        GenderGroupBox.Controls.Add(radioButton3);
        GenderGroupBox.Controls.Add(radioButton2);
        GenderGroupBox.Controls.Add(radioButton1);
        GenderGroupBox.Location = new Point(322, 36);
        GenderGroupBox.Name = "GenderGroupBox";
        GenderGroupBox.Size = new Size(200, 125);
        GenderGroupBox.TabIndex = 3;
        GenderGroupBox.TabStop = false;
        GenderGroupBox.Text = "Gender";
        // 
        // radioButton3
        // 
        radioButton3.AutoSize = true;
        radioButton3.Location = new Point(24, 79);
        radioButton3.Name = "radioButton3";
        radioButton3.Size = new Size(78, 24);
        radioButton3.TabIndex = 2;
        radioButton3.Text = "Female";
        radioButton3.UseVisualStyleBackColor = true;
        // 
        // radioButton2
        // 
        radioButton2.AutoSize = true;
        radioButton2.Location = new Point(24, 52);
        radioButton2.Name = "radioButton2";
        radioButton2.Size = new Size(63, 24);
        radioButton2.TabIndex = 1;
        radioButton2.Text = "Male";
        radioButton2.UseVisualStyleBackColor = true;
        // 
        // radioButton1
        // 
        radioButton1.AutoSize = true;
        radioButton1.Checked = true;
        radioButton1.Location = new Point(24, 26);
        radioButton1.Name = "radioButton1";
        radioButton1.Size = new Size(80, 24);
        radioButton1.TabIndex = 0;
        radioButton1.TabStop = true;
        radioButton1.Text = "Not Set";
        radioButton1.UseVisualStyleBackColor = true;
        // 
        // BirthDateGroupBox
        // 
        BirthDateGroupBox.Controls.Add(radioButton5);
        BirthDateGroupBox.Controls.Add(radioButton4);
        BirthDateGroupBox.Location = new Point(538, 46);
        BirthDateGroupBox.Name = "BirthDateGroupBox";
        BirthDateGroupBox.Size = new Size(250, 115);
        BirthDateGroupBox.TabIndex = 4;
        BirthDateGroupBox.TabStop = false;
        BirthDateGroupBox.Text = "Birth date";
        // 
        // radioButton5
        // 
        radioButton5.AutoSize = true;
        radioButton5.Location = new Point(6, 46);
        radioButton5.Name = "radioButton5";
        radioButton5.Size = new Size(106, 24);
        radioButton5.TabIndex = 1;
        radioButton5.Text = "02/23/1999";
        radioButton5.UseVisualStyleBackColor = true;
        // 
        // radioButton4
        // 
        radioButton4.AutoSize = true;
        radioButton4.Checked = true;
        radioButton4.Location = new Point(6, 16);
        radioButton4.Name = "radioButton4";
        radioButton4.Size = new Size(106, 24);
        radioButton4.TabIndex = 0;
        radioButton4.TabStop = true;
        radioButton4.Text = "01/12/1899";
        radioButton4.UseVisualStyleBackColor = true;
        // 
        // ErrorListBox
        // 
        ErrorListBox.FormattingEnabled = true;
        ErrorListBox.Items.AddRange(new object[] { "For showing validation results" });
        ErrorListBox.Location = new Point(33, 257);
        ErrorListBox.Name = "ErrorListBox";
        ErrorListBox.Size = new Size(755, 124);
        ErrorListBox.TabIndex = 9;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 402);
        Controls.Add(ErrorListBox);
        Controls.Add(BirthDateGroupBox);
        Controls.Add(GenderGroupBox);
        Controls.Add(label3);
        Controls.Add(LastNameTextBox);
        Controls.Add(label2);
        Controls.Add(FirstNameTextBox);
        Controls.Add(label1);
        Controls.Add(TitleComoBox);
        Controls.Add(ValidateButton);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Inline validator";
        Load += MainForm_Load;
        GenderGroupBox.ResumeLayout(false);
        GenderGroupBox.PerformLayout();
        BirthDateGroupBox.ResumeLayout(false);
        BirthDateGroupBox.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button ValidateButton;
    private ComboBox TitleComoBox;
    private Label label1;
    private TextBox FirstNameTextBox;
    private Label label2;
    private TextBox LastNameTextBox;
    private Label label3;
    private GroupBox GenderGroupBox;
    private RadioButton radioButton3;
    private RadioButton radioButton2;
    private RadioButton radioButton1;
    private GroupBox BirthDateGroupBox;
    private RadioButton radioButton5;
    private RadioButton radioButton4;
    private ListBox ErrorListBox;
}
