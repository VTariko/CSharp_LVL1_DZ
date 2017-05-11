using System;
using System.IO;
using System.Text.RegularExpressions;
using Helper;

namespace FindNumber
{
	//Домашняя работа C#-1
	//Выполнил: Вячеслав Тарико (VTariko)
	//
	//4. ** В файле могут встречаться номера телефонов, записанные в формате xx-xx-xx, xxx-xxx или
	//xxx-xx-xx.Вывести все номера телефонов, которые содержатся в файле.

	class FindNumberWork
	{
		static void Main(string[] args)
		{
			string path = "numbers.txt";
			try
			{
				FindNumber(path);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			LogicHelper.Line();
			LogicHelper.Pause();
		}

		private static void FindNumber(string pathFile)
		{
			if (File.Exists(pathFile))
			{
				string text = File.ReadAllText(pathFile);
				//Составляем шаблон под условия xx-xx-xx, xxx-xxx или xxx-xx-xx
				string pattern = @"(\b\d\d-\d\d-\d\d\b)|(\b\d\d\d-\d\d\d\b)|(\b\d\d\d-\d\d-\d\d\b)";
				Regex regex = new Regex(pattern);
				foreach (Match match in regex.Matches(text))
				{
					Console.WriteLine("{0}", match);
				}
			}
			else
			{
				throw new FileNotFoundException("Указанного файла не существует!");
			}
		}
	}
}
