using System;
using System.Net.Configuration;
using System.Text.RegularExpressions;
using Helper;

namespace LoginCheck
{
	class LoginCheck
	{
		//Домашняя работа C#-1
		//Выполнил: Вячеслав Тарико (VTariko)
		//
		//1. Создать программу, которая будет проверять корректность ввода логина. Корректным логином
		//будет строка от 2-х до 10-ти символов, содержащая только буквы или цифры, и при этом цифра
		//не может быть первой.
		//	а) без использования регулярных выражений;
		//	б) **с использованием регулярных выражений.

		static void Main()
		{
			//Строка для будущего логина
			try
			{
				//Первый метод - без регулярных выражений
				string log1 = EnterLogin();
				//Выводим результат:
				Console.WriteLine($"Вы зашли как {log1}");
				LogicHelper.Line();

				//передаем true - для использования регулярных выражений
				string log2 = EnterLogin(true);
				//Выводим результат:
				Console.WriteLine($"Вы зашли как {log2}");
				LogicHelper.Line();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			LogicHelper.Pause();
		}


		public static string EnterLogin(bool isRegex = false)
		{
			Console.WriteLine("Введите свой логин:");
			//Флаг успешного ввода логина
			bool f = false;
			string login = string.Empty;
			while (!f)
			{
				try
				{
					login = Console.ReadLine();
					if (!CheckLogin(login, isRegex))
						throw new Exception("Некорректный логин!");
					f = true;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}

			return login;
		}

		static bool CheckLogin(string login, bool isRegex)
		{
			bool result = false;
			//не используя регулярные выражения
			if (!isRegex)
			{
				//Счетчик символов в логине, являющихся сбуквой или цифрой
				int count = 0;
				//Первичная проверка введенного логина - на блину и первый символ
				if (login.Length >= 2 && login.Length <= 10 && char.IsLetter(login[0]))
				{
					//Проходим по каждому символу в логине
					foreach (char l in login)
					{
						//Если символ является буквой или цифрой - увеличиваем счетчик
						if (char.IsLetterOrDigit(l))
						{
							count++;
						}
					}
					//Сравниваем счесчик валидных символов с длиной строки и возвращаем результат
					result = count == login.Length;
				}
			}
			//Используя регулярные выражения
			else
			{
				//Создаем шаблон
				string pattern = @"^[a-zA-Z]{1}([\w]{1,9}$)";
				Regex regex = new Regex(pattern);
				//Возвращаем результат сравнения введенного логина с допустимым шаблоном
				result = regex.IsMatch(login);
			}

			return result;
		}
	}
}
