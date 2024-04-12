using HabitsTracker.ViewModels;

namespace HabitsTracker.Views;

public partial class HomePage : ContentPage
{
    public HomePage(HomePageViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}
