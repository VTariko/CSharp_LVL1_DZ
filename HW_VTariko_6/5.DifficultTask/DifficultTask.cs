﻿using System;
using System.IO;
using Helper;

namespace DifficultTask
{
	//Домашняя работа C#-1
	//Выполнил: Вячеслав Тарико (VTariko)
	//
	//5. ** Модифицировать задачу “Сложную задачу” ЕГЭ так, чтобы она решала задачу с 10 000 000
	//элементов менее чем за минуту.

	class DifficultTask
	{
		static void Main(string[] args)
		{
			string file = "data.bin";
			Save(file, 100000);
			Load(file);

			LogicHelper.Line();
			LogicHelper.Pause();

		}

		/// <summary>
		/// Создание файла со случайными числами от 0 до randomMax
		/// </summary>
		/// <param name="filePath">Имя файла</param>
		/// <param name="randomMax">Максимально возможное число</param>
		private static void Save(string filePath, int randomMax)
		{
			Random rand = new Random();
			using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
			{
				using (BinaryWriter bw = new BinaryWriter(fs))
				{
					for (int i = 0; i < 10000000; i++)
					{
						bw.Write(rand.Next(randomMax));
					}
				}
			}
		}

		private static void Load(string filePath)
		{
			DateTime dt = DateTime.Now;
			int[] array;
			using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					array = new int[fs.Length/4];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = br.ReadInt32();
					}
				}
			}
			//int max = 0;
			//for (int i = 0; i < array.Length; i++)
			//{
			//	for (int j = 0; j < array.Length; j++)
			//	{
			//		if (i != j && array[i] * array[j] > max)
			//		{
			//			max = array[i] * array[j];
			//		}
			//	}
			//}
			//Console.WriteLine(max);
			//Console.WriteLine((DateTime.Now - dt).TotalSeconds);

			int max1 = array[0];
			int max2 = array[1];

			for (int i = 2; i < array.Length; i++)
			{
				if (array[i] >= max1 && array[i] >= max2)
				{
					if (max1 >= max2)
						max2 = array[i];
					else
						max1 = array[i];
				}
				else if (array[i] > max1)
				{
					max1 = array[i];
				}
				else if (array[i] > max2)
				{
					max2 = array[i];
				}
			}
			Console.WriteLine(max1 * max2);

			Console.WriteLine((DateTime.Now-dt).TotalSeconds);
		}

	}
}