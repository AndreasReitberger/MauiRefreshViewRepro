using MauiApp_RefreshView.ViewModels.Modals;

namespace MauiApp_RefreshView.Views.Modals;

public partial class PrintServerReconnectModalPage : ContentPage
{
	public PrintServerReconnectModalPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            await ((PrintServerReconnectModalPageViewModel)BindingContext).OnAppearing();
        }
        catch (Exception) { }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        try
        {
            ((PrintServerReconnectModalPageViewModel)BindingContext).OnDisappearing();
        }
        catch (Exception) { }
    }

    // Disable Android Back Button
    protected override bool OnBackButtonPressed() => false;
}