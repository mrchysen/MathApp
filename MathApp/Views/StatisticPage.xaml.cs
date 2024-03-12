using MathApp.Models;

namespace MathApp.Views;

public partial class StatisticPage : ContentPage
{
	string _Path = Path.Combine(FileSystem.AppDataDirectory, "stat.txt");

	public StatisticPage()
	{
		InitializeComponent();

        Appearing += StatisticPage_Appearing;
	}

    private async void StatisticPage_Appearing(object? sender, EventArgs e)
    {
        BindingContext = new Statistic(_Path);
    }

    private async void ResetToolbarItem_Clicked(object sender, EventArgs e)
    {
        bool result = await DisplayAlert("Сбросить статистику", "Вы уверены, что хотите сбросить статистику?", "Да", "Нет");
    
        if(result)
        {
            BindingContext = new Statistic();
            ((Statistic)BindingContext).Save(_Path);
        }
    }
}