using HabitsTracker.ViewModels;
using ImageFromXamarinUI;
using System.IO;
using Xamarin.Essentials;
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

        private async void ToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            if (Device.RuntimePlatform == Device.UWP)
                return;

            var imageStream = await MainGridList.CaptureImageAsync();

            var directory = Path.Combine(FileSystem.AppDataDirectory, "ImageEditorSavedImages");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            var fileFullPath = Path.Combine(directory, "MySavedImage.png");
            
            SaveStreamToFile(fileFullPath, imageStream);

            await Share.RequestAsync(new ShareFileRequest
            {
                Title = Title,
                File = new ShareFile(fileFullPath)
            });
        }

        public void SaveStreamToFile(string fileFullPath, Stream stream)
        {
            if (stream.Length == 0) return;

            // Create a FileStream object to write a stream to a file
            using (FileStream fileStream = System.IO.File.Create(fileFullPath, (int)stream.Length))
            {
                // Fill the bytes[] array with the stream data
                byte[] bytesInStream = new byte[stream.Length];
                stream.Read(bytesInStream, 0, (int)bytesInStream.Length);

                // Use FileStream object to write to the specified file
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
            }
        }
    }
}
