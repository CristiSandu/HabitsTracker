using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HabitsTracker
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand SelectADay { get; set; } 
        public MainPageViewModel()
        {
            SelectADay = new Command(async () =>
            {
                await App.Current.MainPage.DisplayAlert("Test", "Test2", "ok");
            });
        }
    }

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
