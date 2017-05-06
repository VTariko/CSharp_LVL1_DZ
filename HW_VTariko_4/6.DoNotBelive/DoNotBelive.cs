using System;
using Helper;

namespace DoNotBelive
{
	//Домашняя работа C#-1, Урок 4
	//Выполнил: Вячеслав Тарико (VTariko)
	//
	//6.	*** Написать игру “Верю.Не верю”. В файле хранятся некоторые данные и правда это или нет.
	//Например: “Шариковую ручку изобрели в древнем Египте”, “Да”.
	//Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задает их игроку.
	//Игрок пытается ответить правда или нет, то что ему загадали и набирает баллы.

	class DoNotBelive
	{
		static void Main(string[] args)
		{
			try
			{
				GameClass g = new GameClass("game.gme");
				g.StartGame();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			
			LogicHelper.Pause();
		}
	}
}
