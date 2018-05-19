using MSKara.Utils;
using MSKara.View;
using MSKara.ViewModel;
using System;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MSKara
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool IsBusy = true;
        public MainPage()
        {
            InitializeComponent();
            if (Settings.UsedLanguage != null)
            {
                IsBusy = false;
            }
            else
            {
                ShowLanguageDialog();
            }
        }

        private async void ShowLanguageDialog()
        {
            var langDialog = new LanguageDialog();
            await langDialog.Initialize();
            var result = await langDialog.ShowAsync();
            IsBusy = false;
        }
    }
}

