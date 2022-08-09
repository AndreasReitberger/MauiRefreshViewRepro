using AndreasReitberger.Shared.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp_RefreshView.ViewModels.Modals
{
    internal class PrintServerReconnectModalPageViewModel : ViewModelBase
    {
        #region Properties
        bool _isRefreshing = false;
        public new bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                if (_isRefreshing == value) return;
                _isRefreshing = value;
                RefreshCommand.ChangeCanExecute();
                OnPropertyChanged();
            }
        }

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

        #endregion

        #region Constructor, LoadSettings

        public PrintServerReconnectModalPageViewModel()
        {
            RefreshCommand = new Command(async () => await RefreshAction(), RefreshCommand_CanExcecute);
        }
        #endregion

        #region Commands

        public Command RefreshCommand { get; set; }
        bool RefreshCommand_CanExcecute()
        {
            return !IsRefreshing;
        }
        async Task RefreshAction()
        {
            try
            {
                IsRefreshing = true;
                await Task.Delay(10000);
            }
            catch (Exception exc)
            {
                // Log error
                Debug.WriteLine(exc.Message);
            }
            IsRefreshing = false;
        }

        public Command OnClickCommand => new Command(() => OnClickAction());

        void OnClickAction()
        {
            Counter++;
        }

        #endregion

        #region Methods

        public async Task OnAppearing()
        {

            try
            {
                IsBusy = true;
                await RefreshAction();
                
            }
            catch (Exception exc)
            {
                //Log error
                Debug.WriteLine(exc.Message);
            }
            IsBusy = false;
        }

        public void OnDisappearing()
        {
            try
            {

            }
            catch (Exception exc)
            {
                //Log error
                Debug.WriteLine(exc.Message);
            }
        }

        #endregion
    }
}
