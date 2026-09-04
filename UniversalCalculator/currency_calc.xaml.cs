using System;
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
	public sealed partial class BlankPage2 : Page
	{
		const double USD_TO_EURO = 0.85189982;
		const double USD_TO_POUND = 0.72872436;
		const double USD_TO_RUPEE = 74.257327;
		const double Euro_TO_USD = 1.1739732;
		const double Euro_TO_POUND = 0.8556672;
		const double Euro_TO_RUPEE = 87.00755;
		const double POUND_TO_USD = 1.371907;
		const double POUND_TO_EURO = 1.1686692;
		const double POUND_TO_RUPEE = 101.68635;
		const double RUPEE_TO_USD = 0.011492628;
		const double RUPEE_TO_EURO = 0.013492774;
		const double RUPEE_TO_POUND = 0.0098339397;

		public BlankPage2()
		{
			InitializeComponent();
		}

		private double Calc_currency(float currency, string from, string into)
		{
			if (from == into)
			{
				return currency;
			}

			if (from == "USD")
			{
				if (into == "Euro")
				{
					return currency * USD_TO_EURO;
				}
				else
				{
					if (into == "British Pound")
					{
						return currency * USD_TO_POUND;
					}
					else
					{
						if (into == "Indian Rupee")
						{
							return currency * USD_TO_RUPEE;
						}
					}
				}

			}
			else
			{
				if (from == "Euro")
				{
					if (into == "USD")
					{
						return currency * Euro_TO_USD;
					}
					else
					{
						if (into == "British Pound")
						{
							return currency * Euro_TO_POUND;
						}
						else
						{
							if (into == "Indian Rupee")
							{
								return currency * Euro_TO_RUPEE;
							}
						}
					}
				}
				else
				{
					if (from == "British Pound")
					{
						if (into == "USD")
						{
							return currency * POUND_TO_USD;
						}
						else
						{
							if (into == "Euro")
							{
								return currency * POUND_TO_EURO;
							}
							else
							{
								if (into == "Indian Rupee")
								{
									return currency * POUND_TO_RUPEE;
								}
							}
						}
					}
					else
					{
						if (from == "Indian Rupee")
						{
							if (into == "USD")
							{
								return currency * RUPEE_TO_USD;
							}
							else
							{
								if (into == "Euro")
								{
									return currency * RUPEE_TO_EURO;
								}
								else
								{
									if (into == "British Pound")
									{
										return currency * RUPEE_TO_POUND;
									}
								}
							}
						}
						else
						{
							
						}
					}
					
				}
			}
			return -1;
		}

		private async void calculate_Click(object sender, RoutedEventArgs e)
		{
			float base_currency;
			string from_val;
			string into_val;
			try
			{
				base_currency = float.Parse(input.Text);
			}
			catch (Exception)
			{
				ContentDialog dialog = new ContentDialog
				{
					XamlRoot = this.Content.XamlRoot,
					Title = "Exception Error",
					Content = "Error! Please enter the currency as a number. ",
					CloseButtonText = "OK"
				};
				_ = await dialog.ShowAsync();
				input.Focus(FocusState.Programmatic);
				input.SelectAll();
				return;
			}
			try
			{
				from_val = from.SelectedValue.ToString();
			}
			catch (Exception)
			{
				ContentDialog dialog = new ContentDialog
				{
					XamlRoot = this.Content.XamlRoot,
					Title = "Exception Error",
					Content = "Error! Please select the currency to calculate from. ",
					CloseButtonText = "OK"
				};
				_ = await dialog.ShowAsync();
				from.Focus(FocusState.Programmatic);
				
				return;
			}
			try
			{
				into_val = into.SelectedValue.ToString();
			}
			catch (Exception)
			{
				ContentDialog dialog = new ContentDialog
				{
					XamlRoot = this.Content.XamlRoot,
					Title = "Exception Error",
					Content = "Error! Please select the currency to calculate to. ",
					CloseButtonText = "OK"
				};
				_ = await dialog.ShowAsync();
				into.Focus(FocusState.Programmatic);
				
				return;
			}

			
			output.Text = base_currency + " " + from_val + " is " + Calc_currency(base_currency, from_val, into_val) + " " + into_val;
			return;
			


		}

		private void exit_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(BlankPage1));
		}
	}
}
