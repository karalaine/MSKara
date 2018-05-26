using MSKara.Utils;
using MSKara.View;
using MSKara.ViewModel;
using MSKara2017.ViewModel;
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
        public bool IsLoading { get; private set; }
        public MainViewModel MainViewModel { get; private set; }
        public MainPage()
        {
            InitializeComponent();
            Clear();
            if (Settings.UsedLanguage != null)
            {
                IsLoading = false;
                LoadCategories();
            }
            else
            {
                ShowLanguageDialog();
            }
            MainViewModel = new MainViewModel();
           
        }
        private async void Clear()
        {
            await Windows.Storage.ApplicationData.Current.ClearAsync();
        }
        private async void LoadCategories()
        {
            IsLoading = true;
            await MainViewModel.LoadCategoriesAsync();
            await MainViewModel.LoadNewsAsync();
            IsLoading = false;
        }
        private async void ShowLanguageDialog()
        {
            var langDialog = new LanguageDialog();
            await langDialog.Initialize();
            var result = await langDialog.ShowAsync();
            LoadCategories();
            IsLoading = false;
        }
    }
}

