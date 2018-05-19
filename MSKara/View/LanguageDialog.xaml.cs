using MSKara.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MSKara.View
{
	public sealed partial class LanguageDialog : ContentDialog
	{
        public LanguageViewModel LanguageViewModel { get; set; }
		public LanguageDialog()
		{
			this.InitializeComponent();
            LanguageViewModel = new LanguageViewModel();
            LanguageCompoBox.SelectionChanged += LanguageCompoBox_SelectionChanged;
        }

        private void LanguageCompoBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("Hwerer");
        }

        public async Task Initialize()
        {
            await LanguageViewModel.LoadLanguagesAsync();
        }

		private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
            LanguageViewModel.UpdateToSettings();

        }

		private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
            LanguageViewModel.UpdateToSettings();
        }
	}
}
