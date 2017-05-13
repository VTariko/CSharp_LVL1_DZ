using System;
using System.IO;
using System.Text.RegularExpressions;
using Helper;

namespace FindHtmlImg
{
	//Домашняя работа C#-1
	//Выполнил: Вячеслав Тарико (VTariko)
	//
	//6. ***В заданной папке найти во всех html файлах теги <img src=...> и вывести названия картинок.

	static class FindHtmlImg
	{
		static void Main(string[] args)
		{
			string path = @"D:\Code\HTML_CSS\myShop.git\shop_VTariko";
			FindImgInDir(path);
			LogicHelper.Line();
			LogicHelper.Pause();
		}

		/// <summary>
		/// Поиск в директории тегов img и вывод на экран названий картинок
		/// </summary>
		/// <param name="dir">Путь к папке, в которой начать поиск</param>
		private static void FindImgInDir(string dir)
		{
			//Выбираем все файлы с расширением HTML
			string[] files = Directory.GetFiles(dir, "*.html", SearchOption.AllDirectories);

			//Шаблон для выборки тегов <img src=...>
			string pattern = @"(\<(/?img src=[^\>]+)\>)";
			Regex regex = new Regex(pattern);
			//Шаблон для выборки заголовках внутри тегов img
			string innerPattern = "(title=\"([^\"]*)\")";
			Regex innerRegex = new Regex(innerPattern);
			//Шаблон для выборки конкретно названий
			string titlePattern = "(\"([^\"]*)\")";
			Regex titleRegex = new Regex(titlePattern);

			foreach (string file in files)
			{
				string fileString = File.ReadAllText(file);
				//Для каждого тега <img...> ...
				foreach (Match match in regex.Matches(fileString))
				{
					//...для каждого вложенного атрибута title...
					foreach (Match innerMatch in innerRegex.Matches(match.Value))
					{
						//...находим заголовки, исключаем кавычки и выводим на печать
						foreach (Match titleMatch in titleRegex.Matches(innerMatch.Value))
						{
							Console.WriteLine("{0}", titleMatch.Value.Trim('"'));
						}
					}
				}
			}

		}
	}
}
