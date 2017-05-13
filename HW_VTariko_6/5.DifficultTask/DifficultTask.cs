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
			long maxMulti = 0;
			//for (int i = 0; i < array.Length; i++)
			//{
			//	for (int j = 0; j < array.Length; j++)
			//	{
			//		if (Math.Abs(i - j) < 8 && (long)array[i] * array[j] > max)
			//		{
			//			max = (long)array[i] * array[j];
			//		}
			//	}
			//}
			//Console.WriteLine(max);
			//Console.WriteLine((DateTime.Now - dt).TotalSeconds);
			//LogicHelper.Line();
			//------------------------------------------//
			//Идея простая: вместо того, чтобы дважды проходить цикл,
			//достаточно находить максимальное число из подмассива позади (с "отставанием" на 8)
			//умножать этот максимум на текущее число и сравнивать с предыдущим максимально найденным произведением.
			//Также, чтобы еще оптимизировать, будем запоминать произведение во временную переменную. чтоыб н еумножать дважды одно и тоже.

			LogicHelper.Line();
			dt = DateTime.Now;
			int max = array[0];
			for (int i = 8; i < array.Length; i++)
			{
				if (array[i - 8] > max)
					max = array[i - 8];
				long temp = (long) max*array[i];
				if (temp > maxMulti)
					maxMulti = temp;
			}
			Console.WriteLine(maxMulti);
			Console.WriteLine((DateTime.Now - dt).TotalSeconds);
		}

	}
}
