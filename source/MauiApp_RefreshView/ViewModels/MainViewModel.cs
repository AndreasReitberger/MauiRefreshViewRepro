using AndreasReitberger.Shared.Core;
using MauiApp_RefreshView.Views.Modals;
using System.Diagnostics;

namespace MauiApp_RefreshView.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {

        #region Properties

        int counter = 0;
        public int Counter
        {
            get => counter;
            set
            {
                if (counter == value) return;
                counter = value;
                OnPropertyChanged();
            }
        }

        bool _isRefreshing = false;
        public new bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                if (_isRefreshing == value) return;
                _isRefreshing = value;
                RefreshPageCommand.ChangeCanExecute();
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            RefreshPageCommand = new Command(async () => await RefreshPageAction(), RefreshPageCommand_CanExcecute);
        }
        #endregion

        #region Commands

        public Command RefreshPageCommand { get; set; }
        bool RefreshPageCommand_CanExcecute()
        {
            return !IsRefreshing;
        }
        async Task RefreshPageAction()
        {
            try
            {
                IsRefreshing = true;
                await Task.Delay(2000);
            }
            catch (Exception exc)
            {
                // Log error
                Debug.WriteLine(exc.Message);
            }
            IsRefreshing = false;
        }

        public Command OnClickCommand => new Command(async () => await OnClickAction());

        async Task OnClickAction()
        {
            //Counter++;
            await Shell.Current.GoToAsync(nameof(PrintServerReconnectModalPage), true);
        }

        #endregion

        #region OnAppearing

        public async Task OnAppearing()
        {
            try
            {
                IsBusy = true;
                await RefreshPageAction();     
            }
            catch (Exception exc)
            {
                // Log error
                Debug.WriteLine(exc.Message);
            }
            IsBusy = false;
            IsStartUp = false;
        }

        #endregion
    }
}
