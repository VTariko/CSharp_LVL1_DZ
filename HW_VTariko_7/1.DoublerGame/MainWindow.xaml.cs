using System.Windows;

namespace DoublerGame
{
	//Домашняя работа C#-1
	//Выполнил: Вячеслав Тарико (VTariko)
	//
	//1.	а) Добавить в программу “Удвоитель” подсчет количества отданных команд удвоителю.
	//		б) Добавить меню и команду “Играть”. При нажатии появляется сообщение, какое число должен
	//получить игрок. Игрок должен постараться получить это число за минимальное количество
	//ходов.
	//		в) * Добавить кнопку “Отменить”, которая отменяет последний ход.


	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private Doubler doubler;
		const int MAX_DOUBLER = 250;

		public MainWindow()
		{
			doubler = new Doubler(MAX_DOUBLER);
			InitializeComponent();
			DataContext = doubler;
		}

		private void btnAddOne_Click(object sender, RoutedEventArgs e)
		{
			CheckResult(doubler.AddOne());
			btnCancel.IsEnabled = true;
		}

		private void btnMultiTwo_Click(object sender, RoutedEventArgs e)
		{
			CheckResult(doubler.MultiTwo());
			btnCancel.IsEnabled = true;
		}

		private void btnToOne_Click(object sender, RoutedEventArgs e)
		{
			doubler.ToOne();
			btnCancel.IsEnabled = true;
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			btnCancel.IsEnabled = doubler.Cancel();
		}

		private void CheckResult(bool? result)
		{
			if (result.HasValue)
			{
				MessageBox.Show(string.Format("Вы {0}!\nКоличество попыток: {1}", result.Value ? "выиграли" : "проиграли", doubler.Attempt));
				doubler = new Doubler(MAX_DOUBLER);
				DataContext = doubler;
			}
		}

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void MenuItem_Click_1(object sender, RoutedEventArgs e)
		{
			doubler = new Doubler(MAX_DOUBLER);
			DataContext = doubler;
		}
	}
}
