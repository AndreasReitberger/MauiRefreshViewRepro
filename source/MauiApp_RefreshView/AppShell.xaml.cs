using MauiApp_RefreshView.Views.Modals;

namespace MauiApp_RefreshView;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(PrintServerReconnectModalPage), typeof(PrintServerReconnectModalPage));
	}
}
