using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Helper;

namespace DoNotBelive
{
	class GameClass
	{
		#region Константы

		/// <summary>
		/// Константа количества вопросов
		/// </summary>
		private const int SIZE = 5;

		#endregion

		#region Свойства

		/// <summary>
		/// Список вопросов и ответов для игры
		/// </summary>
		public Question[] Questions { get; private set; }

		/// <summary>
		/// Счетчик правильных ответов
		/// </summary>
		public int Score { get; private set; }

		#endregion

		#region Конструкторы

		/// <summary>
		/// Создание игры из файла
		/// </summary>
		/// <param name="path"></param>
		public GameClass(string path)
		{
			if (File.Exists(path))
			{
				//Используем вспомогательный внутренний метод для получения всех вопросов из файла
				List<Question> allQuestions = ReadQuestions(path);

				//Случайная переменная для выбора конкретного вопроса из общего списка
				Random random = new Random();
				//Создаем массив выбюранных вопросов, чтоыб они случайно не повторились.
				int[] arrQuest = new int[Questions.Length];
				//Заполняем его значениями "-1", чтобы нулевой вопрос тоже мог попасть в массив
				for (int j = 0; j < arrQuest.Length; j++)
				{
					arrQuest[j] = -1;
				}

				//Цикл составления списка уникальных вопросов:
				for (int i = 0; i < Questions.Length && i < allQuestions.Count; i++)
				{
					int q;
					do
					{
						q = random.Next(allQuestions.Count);
					} while (Array.IndexOf(arrQuest, q) > -1);
					//Если проверка прошла - массив вопросов пополняется номером выбранного вопроса
					arrQuest[i] = q;
					//Добавляем в массив вопросов новый вопрос.
					Questions[i] = allQuestions[q];
				}
				Score = 0;
			}
			else
			{
				throw new Exception("Ошибка создания игры!");
			}
		}

		#endregion

		#region Методы

		/// <summary>
		/// Старт игры - задает вопросы, анализирует ответы, выдает результат в конце.
		/// </summary>
		public void StartGame()
		{
			foreach (Question q in Questions)
			{
				//Задаем вопрос
				Console.Write("{0}? (1 - \"Да\", 2 - \"Нет\"):\t", q.Query);

				//Переменная дял хранения результата ответа
				int a;
				//Повторяем цикл, пока не ведут корректные данные
				do
				{
					string str = Console.ReadLine();
					if (!int.TryParse(str, out a))
					{
						Console.WriteLine("Некорректный формат данных! Попробуйте еще раз.");
					}
					else
					{
						if (a != 1 && a != 2)
							Console.WriteLine("Введенное число вне допустимого диапазона");
						else
							break;
					}
				} while (true);
				bool res = a == 1;
				if (res.Equals(q.Answer))
				{
					Score++;
					Console.WriteLine("Верно!");
				}
				else
				{
					Console.WriteLine("Не верно!");
				}
			}
			LogicHelper.Line();
			Console.WriteLine($"Ваш результат: {Score}");
		}

		/// <summary>
		/// Внутренний метод выборки всех вопросов из заданного файла
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		private List<Question> ReadQuestions(string path)
		{
			Questions = new Question[SIZE];
			List<Question> allQuestions = new List<Question>();
			using (StreamReader sr = new StreamReader(path))
			{
				while (!sr.EndOfStream)
				{
					string readLine = sr.ReadLine();
					if (readLine != null)
					{
						//Делим строку по кавычкам - вопрос оказывается элементом с индексом 1, ответ - с индексом 3
						string[] str = readLine.Trim().Split('"');
						//Получаем список всех вопросов из файла, чтобы потом выбрать из них несколько штук случайным образом
						allQuestions.Add(new Question(str[1], str[3]));
					}
				}
			}
			return allQuestions;
		}

		#endregion
	}
}
