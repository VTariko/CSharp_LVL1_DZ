using System;
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
			//long max = 0;
			//for (int i = 0; i < array.Length; i++)
			//{
			//	for (int j = 0; j < array.Length; j++)
			//	{
			//		if (i != j && (long)array[i] * array[j] > max)
			//		{
			//			max = (long)array[i] * array[j];
			//		}
			//	}
			//}
			//Console.WriteLine(max);
			//Console.WriteLine((DateTime.Now - dt).TotalSeconds);


			//Идея простая: вместо того, чтобы каждый раз умножать и сравнивать с перемножением,
			//просто отсортируем массив и возьмем первый элемент (самый большой) и умножим его на восьмой элемент.
			Array.Sort(array, (int1, int2) => int2.CompareTo(int1));

			int max1 = array[0];
			int max2 = array[7];

			long maxQ = (long)max1*max2;
			Console.WriteLine(maxQ);

			Console.WriteLine((DateTime.Now-dt).TotalSeconds);
		}

	}
}
