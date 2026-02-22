namespace MauiApp3;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCalculateClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(HeightEntry.Text) || string.IsNullOrWhiteSpace(WeightEntry.Text))
        {
            DisplayAlert("Missing Input", "Please enter both your height and weight.", "OK");
            return;
        }

        if (!double.TryParse(HeightEntry.Text, out double height) || height <= 0)
        {
            DisplayAlert("Invalid Input", "Please enter a valid height in cm.", "OK");
            return;
        }

        if (!double.TryParse(WeightEntry.Text, out double weight) || weight <= 0)
        {
            DisplayAlert("Invalid Input", "Please enter a valid weight in kg.", "OK");
            return;
        }
        
        double heightInMeters = height / 100;
        double bmi = weight / (heightInMeters * heightInMeters);
        
        BmiValueLabel.Text = bmi.ToString("F1");
        
        string category;
        Color categoryColor;

        if (bmi < 18.5)
        {
            category = "Underweight";
            categoryColor = Color.FromArgb("#2E86C1");
        }
        else if (bmi < 25)
        {
            category = "Normal Weight";
            categoryColor = Color.FromArgb("#1E8449");
        }
        else if (bmi < 30)
        {
            category = "Overweight";
            categoryColor = Color.FromArgb("#D35400");
        }
        else
        {
            category = "Obese";
            categoryColor = Color.FromArgb("#C0392B");
        }

        CategoryLabel.Text = category;
        CategoryFrame.BackgroundColor = categoryColor;
        BmiValueLabel.TextColor = categoryColor;
        
        ResultCard.IsVisible = true;
    }
}
