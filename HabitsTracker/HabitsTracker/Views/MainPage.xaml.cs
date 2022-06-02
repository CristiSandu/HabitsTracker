using HabitsTracker.ViewModels;
using Xamarin.Forms;

namespace HabitsTracker.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Content.BindingContext = new MainPageViewModel();
        }
    }
}
