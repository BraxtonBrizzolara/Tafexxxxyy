using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class BlankPage1 : Page
	{
		public BlankPage1()
		{
			InitializeComponent();
		}

		private void maths_Button_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainPage));
		}

		private void Morgage_button_Click(object sender, RoutedEventArgs e)
		{

		}

		private void currency_button_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(BlankPage2));
		}

		private void exit_button_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
