using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace StringCheck
{
	class MyString
	{
		#region Свойства

		/// <summary>
		/// Само сообщение 
		/// </summary>
		public string DataStr { get; }

		#endregion

		#region Конструкторы

		public MyString(string dataStr)
		{
			DataStr = dataStr;
		}

		#endregion

		#region Методы

		/// <summary>
		/// Вывести только те слова сообщения, которые содержат не более чем n букв
		/// </summary>
		/// <param name="n">Минимально допустимое количество символов</param>
		/// <returns></returns>
		public List<string> MoreThan(int n)
		{
			List<string> result = new List<string>();

			string pattern = @"[\w\d]{" + n + @",}";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(DataStr);

			while (match.Success)
			{
				result.Add(match.Groups[0].Value);
				match = match.NextMatch();
			}

			return result;
		}

		/// <summary>
		/// Удалить из сообщения все слова, которые заканчиваются на заданный символ
		/// </summary>
		/// <param name="c">Заданный символ</param>
		/// <returns></returns>
		public string DeleteEndWithChar(char c)
		{
			//Приджется много раз менять строку, поэтому используем StringBuilder
			StringBuilder sb = new StringBuilder(DataStr);
			string pattern = @"[\w\d]*" + c + @"\b";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(sb.ToString());
			while (match.Success)
			{
				sb = sb.Remove(match.Groups[0].Index, match.Groups[0].Length);
				match = regex.Match(sb.ToString());
			}
			return sb.ToString().Trim();
		}

		//public 

		/// <summary>
		/// Найти самое длинное слово сообщения 
		/// </summary>
		/// <returns>Самое длинное слово сообщения (первое, если их несколько)</returns>
		public string LongestWord()
		{
			string pattern = @"[\w\d]{1,}";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(DataStr);

			int max = -1;
			string result = string.Empty;
			while (match.Success)
			{
				string str = match.Groups[0].Value;
				if (str.Length > max)
				{
					max = str.Length;
					result = str;
				}
				match = match.NextMatch();
			}


			return result;
		}

		/// <summary>
		/// Найти все самые длинные слова сообщения
		/// </summary>
		/// <returns></returns>
		public List<string> LongestWords()
		{
			string pattern = @"[\w\d]{1,}";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(DataStr);

			int max = -1;

			while (match.Success)
			{
				int l = match.Groups[0].Value.Length;
				if (l > max)
				{
					max = l;
				}
				match = match.NextMatch();
			}

			List<string> result = MoreThan(max);

			return result;
		}

		#endregion
	}
}
