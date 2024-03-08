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

    private void StatisticPage_Appearing(object? sender, EventArgs e)
    {
        BindingContext = new Statistic(_Path);
    }
}