using System;
using System.Collections.Generic;
using Helper;

namespace StringCheck
{
	class StringCheck
	{
		//Домашняя работа C#-1
		//Выполнил: Вячеслав Тарико (VTariko)
		//
		//2. Разработать методы для решения следующих задач.Дано сообщение:
		//	а) Вывести только те слова сообщения, которые содержат не более чем n букв;
		//	б) Удалить из сообщения все слова, которые заканчиваются на заданный символ;
		//	в) Найти самое длинное слово сообщения;
		//	г) Найти все самые длинные слова сообщения.
		//	Постарайтесь разработать класс MyString.

		static void Main()
		{
			//Базовая строка-сообщение, созданная рабогенератором
			string inputData = "Lorem ipsum dolor sit amet, consectetuer adipiscingin elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem.";
			//Создаем объект класса MyString, используя базовую строку-сообщение
			MyString myStr = new MyString(inputData);
			Console.WriteLine("Базовая строка-сообщение:\n{0}", myStr.DataStr);
			LogicHelper.Line();

			//Создаем и выводим список тех слов, длина которых больше заданной, например, 6
			int n = 6;
			List<string> moreThenList = myStr.MoreThan(n);
			string moreThen = string.Join(", ", moreThenList);
			Console.WriteLine("Список слов, содержащих {0} и более символов:\n{1}", n, moreThen);
			LogicHelper.Line();

			//Создать строку, удалив из базовой строки-сообщения все слова, оканчивающиеся на заданный символ, например, 'm'
			char c = 'm';
			string deleteString = myStr.DeleteEndWithChar(c);
			Console.WriteLine("Базовая строка без слов, оканчивающихся на {0}:\n{1}", c, deleteString);
			LogicHelper.Line();

			//Находим и выводим первое самое дилнное слово в базовой строке-сообщении
			string longestWord = myStr.LongestWord();
			Console.WriteLine("Самое длинное слово в базовой строке-сообщении:\n{0}", longestWord);
			LogicHelper.Line();

			//Находим и выводим все самые дилнные слова
			List<string> longestWordsList = myStr.LongestWords();
			string longestWords = string.Join(", ", longestWordsList);
			Console.WriteLine("Самые длинные слова в базовой строке-сообщении:\n{0}", longestWords);
			LogicHelper.Line();

			LogicHelper.Pause();
		}
	}
}
