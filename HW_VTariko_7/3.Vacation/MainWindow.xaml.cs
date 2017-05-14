using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vacation
{
	//Домашняя работа C#-1
	//Выполнил: Вячеслав Тарико (VTariko)
	//
	//3. * Реализовать программу из предыдущего урока с шаблоном документа на отпуск в Windows
	//Forms.Сделать несколько текстовых полей(TextBox), куда человек вводит данные, а по нажатии
	//кнопки “Сделать” видит готовое заявление на отпуск.

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		VacationClass vacation;

		public MainWindow()
		{
			vacation = new VacationClass();
			InitializeComponent();
			DataContext = vacation;
		}

		private void btnReady_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string str = vacation.CreateApplicationForLeave();
				//string str = "awfawfa fa faf arfq";
				VacationReadyWindow vrWindow = new VacationReadyWindow {txtVacation = {Text = str}};
				vrWindow.Show();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}
			
		}
	}
}
