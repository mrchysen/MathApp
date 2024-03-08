using MathApp.Models;
using MathApp.Models.Equations;
using Microsoft.Maui.Controls.Platform;

namespace MathApp.Views;

public partial class SolvePage : ContentPage
{
    Statistic _Statistic;
    string _Path = Path.Combine(FileSystem.AppDataDirectory, "stat.txt");

	public SolvePage()
	{
		InitializeComponent();

        UpdateEquation();

        _Statistic = new(_Path);

        Disappearing += SolvePage_Disappearing;
	}

    private void SolvePage_Disappearing(object? sender, EventArgs e)
    {
        File.WriteAllText(_Path, _Statistic.ToString());
    }

    private async void ResetButton_Clicked(object sender, EventArgs e)
    {
        _Statistic.Count++;
        _Statistic.WrongAnswers++;

        UpdateEquation();
    }

    private async void AcceptButton_Clicked(object sender, EventArgs e)
    {
        int answer = ((Addition)BindingContext).Answer;

        if(answer == int.Parse(AnswerEntry.Text))
        {
            _Statistic.RightAnswers++;
        }
        else
        {
            _Statistic.WrongAnswers++;
        }

        _Statistic.Count++;

        UpdateEquation();
    }

    protected void UpdateEquation()
    {
        Random rnd = new();

        AnswerEntry.Text = "";

        BindingContext = new Addition(rnd.Next(20), rnd.Next(20));
    }

}