using MSKara.Utils;
using MSKara.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

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
            this.InitializeComponent();
			if(Settings.UsedLanguage != null)
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
			var result = await langDialog.ShowAsync();
		}
    }
}
