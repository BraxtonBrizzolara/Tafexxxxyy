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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class mortgagePage : Page
	{
		public mortgagePage()
		{
			this.InitializeComponent();
		}
		const int MONTHS_PER_YEAR = 12;
		const double PERCENT = 100;

		private double Calc_mortgage(double principal, double annualRate, int totalMonths)
		{
			double monthlyRate = (annualRate / PERCENT) / MONTHS_PER_YEAR;


			double repayment =
				principal *
				(monthlyRate * Math.Pow(1 + monthlyRate, totalMonths)) /
				(Math.Pow(1 + monthlyRate, totalMonths) - 1);

			return repayment;

			
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(BlankPage1));
		}

		private async void CalculateButton_Click(object sender, RoutedEventArgs e)
		{
			double principal;
			double annualRate;
			double monthlyRate;
			double repayment;

			int years;
			int months;
			int totalMonths;


			// checks if principal borrowed is a valid number
			try
			{
				principal = double.Parse(PrincipalBorrowedTextBox.Text);
			}
			catch (Exception)
			{
				ContentDialog dialog = new ContentDialog
				{
					XamlRoot = this.Content.XamlRoot,
					Title = "Exception Error",
					Content = "Please enter a valid number for Principal Borrowed.",
					CloseButtonText = "OK"
				};

				_ = await dialog.ShowAsync();
				PrincipalBorrowedTextBox.Focus(FocusState.Programmatic);
				PrincipalBorrowedTextBox.SelectAll();
				return;
			}


			// checks if years is a valid whole number
			try
			{
				years = int.Parse(YearsTextBox.Text);
			}
			catch (Exception)
			{
				ContentDialog dialog = new ContentDialog
				{
					XamlRoot = this.Content.XamlRoot,
					Title = "Exception Error",
					Content = "Please enter a valid number for Years.",
					CloseButtonText = "OK"
				};

				_ = await dialog.ShowAsync();
				YearsTextBox.Focus(FocusState.Programmatic);
				YearsTextBox.SelectAll();
				return;
			}


			// checks if months is a valid whole number
			try
			{
				months = int.Parse(MonthsTextBox.Text);
			}
			catch (Exception)
			{
				ContentDialog dialog = new ContentDialog
				{
					XamlRoot = this.Content.XamlRoot,
					Title = "Exception Error",
					Content = "Please enter a valid number for Months.",
					CloseButtonText = "OK"
				};

				_ = await dialog.ShowAsync();
				MonthsTextBox.Focus(FocusState.Programmatic);
				MonthsTextBox.SelectAll();
				return;
			}


			// checks if annual interest rate is a valid number
			try
			{
				annualRate = double.Parse(AnualInterestRateTextBox.Text);
			}
			catch (Exception)
			{
				ContentDialog dialog = new ContentDialog
				{
					XamlRoot = this.Content.XamlRoot,
					Title = "Exception Error",
					Content = "Please enter a valid Annual Interest Rate.",
					CloseButtonText = "OK"
				};

				_ = await dialog.ShowAsync();
				AnualInterestRateTextBox.Focus(FocusState.Programmatic);
				AnualInterestRateTextBox.SelectAll();
				return;
			}


			// principal must be greater than 0
			if (principal <= 0)
			{
				ContentDialog dialog = new ContentDialog
				{
					XamlRoot = this.Content.XamlRoot,
					Title = "Validation Error",
					Content = "Principal Borrowed must be greater than 0.",
					CloseButtonText = "OK"
				};

				_ = await dialog.ShowAsync();
				PrincipalBorrowedTextBox.Focus(FocusState.Programmatic);
				PrincipalBorrowedTextBox.SelectAll();
				return;
			}


			// years and months cannot both be 0
			if (years <= 0 && months <= 0)
			{
				ContentDialog dialog = new ContentDialog
				{
					XamlRoot = this.Content.XamlRoot,
					Title = "Validation Error",
					Content = "Loan period must be greater than 0 months.",
					CloseButtonText = "OK"
				};

				_ = await dialog.ShowAsync();
				YearsTextBox.Focus(FocusState.Programmatic);
				return;
			}


			// interest rate must be greater than 0
			if (annualRate <= 0)
			{
				ContentDialog dialog = new ContentDialog
				{
					XamlRoot = this.Content.XamlRoot,
					Title = "Validation Error",
					Content = "Annual Interest Rate must be greater than 0.",
					CloseButtonText = "OK"
				};

				_ = await dialog.ShowAsync();
				AnualInterestRateTextBox.Focus(FocusState.Programmatic);
				AnualInterestRateTextBox.SelectAll();
				return;

				
			}
			// final calculations

			totalMonths = (years * MONTHS_PER_YEAR) + months;

			monthlyRate =
				(annualRate / PERCENT) / MONTHS_PER_YEAR;

			repayment =
				Calc_mortgage(principal, annualRate, totalMonths);


			// puts the calculations into the output boxes

			MonthlyInterestRateTextBox.Text =
				(monthlyRate * 100).ToString("0.00") + "%";

			MonthlyRepaymentTextBox.Text =
				repayment.ToString("C");
		}


		}
	}

