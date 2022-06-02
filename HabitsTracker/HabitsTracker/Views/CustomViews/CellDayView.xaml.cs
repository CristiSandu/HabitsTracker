using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HabitsTracker.Views.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellDayView : ContentView
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.CreateAttached(nameof(Command), typeof(ICommand), typeof(CellDayView), null);
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(CellDayView), null);
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CellDayView));
        public static readonly BindableProperty ImageNameProperty = BindableProperty.Create(nameof(ImageName), typeof(string), typeof(CellDayView));

        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public string ImageName
        {
            get
            {
                return (string)GetValue(ImageNameProperty);
            }
            set
            {
                SetValue(ImageNameProperty, value);
            }
        }
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public CellDayView()
        {
            InitializeComponent();
            Content.BindingContext = this;
        }
    }
}