using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HabitsTracker.CustomView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellDayView : Grid
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CellDayView));
        public static readonly BindableProperty ImageNameProperty = BindableProperty.Create(nameof(ImageName), typeof(string), typeof(CellDayView));
        public static readonly BindableProperty ButtonPressCommand = BindableProperty.Create(nameof(ButtonPress), typeof(ICommand), typeof(CellDayView), null);


        public ICommand ButtonPress
        {
            get
            {
                return (ICommand)GetValue(ButtonPressCommand);
            }
            set
            {
                SetValue(ButtonPressCommand, value);
            }
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
            BindingContext = this;
        }
    }
}