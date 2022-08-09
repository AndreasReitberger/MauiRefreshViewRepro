using AndreasReitberger.Shared.Core;
using MauiApp_RefreshView.ViewModels;

namespace MauiApp_RefreshView;

public partial class MainPage : ContentPage
{

    public MainPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            await ((MainViewModel)BindingContext).OnAppearing();
        }
        catch (Exception) { }
    }
}

