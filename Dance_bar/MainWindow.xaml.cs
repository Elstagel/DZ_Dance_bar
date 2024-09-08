using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dance_bar
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		public void AddPb()
		{
			Pb.Add(new ProgressBar
			{
				Margin = new Thickness(5),
				Minimum = 0,
				Maximum = 100,
				Value = 40,
				Height = 20,
			} );
		}



		List<ProgressBar> Pb = [];
		Random r = new Random();

		private void ButtonAddBar_Click(object sender, RoutedEventArgs e)
		{


			if (Pb.Count <= 10)
			{
				int a = 1;
				try
				{
					a = (int.Parse(TextBoxWriteBar.Text));

				}
				catch (Exception)
				{

					MessageBox.Show("Вы ничего не ввели");
				}

				if (a < 11)
				{
				Pb.Clear();
				MyStackPanelBar.Children.Clear();
				for (int i = 0; i < a && i < 10; i++)
				{
					AddPb();
				}
				foreach (var P in Pb)
				{
					MyStackPanelBar.Children.Add(P);
				}
				}
				else
					MessageBox.Show("Вы Ввели слишком много");
			}


		}

		private void ButtonRepeatButton_Click(object sender, RoutedEventArgs e)
		{
			foreach (var p in Pb)
			{
				p.Value = r.Next(0,100);

			}
			
        }

		private void TextBoxWriteBar_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || (e.Key == Key.Back))
			{ e.Handled = false;
			}
			else if ((e.Key >= Key.D0 && e.Key <= Key.D9))
			{ e.Handled = false;
			}
			else
			{ e.Handled = true;
				MessageBox.Show("Вводить нужно только цифры");
			}

		}
	}
}