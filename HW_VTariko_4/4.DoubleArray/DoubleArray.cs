using System;
using System.IO;
using System.Text;

namespace DoubleArray
{
	class DoubleArray
	{
		#region Поля

		private int[,] _array;

		#endregion

		#region Свойства

		/// <summary>
		/// Максимальный элемент объекта
		/// </summary>
		public int Max
		{
			get
			{
				int max = _array[0, 0];
				for (int i = 0; i < _array.GetLength(0); i++)
				{
					for (int j = 0; j < _array.GetLength(1); j++)
					{
						if (_array[i, j] > max)
							max = _array[i, j];
					}
				}
				return max;
			}
		}

		/// <summary>
		/// Минимальный элемент объекта
		/// </summary>
		public int Min
		{
			get
			{
				int min = _array[0, 0];
				for (int i = 0; i < _array.GetLength(0); i++)
				{
					for (int j = 0; j < _array.GetLength(1); j++)
					{
						if (_array[i, j] < min)
							min = _array[i, j];
					}
				}
				return min;
			}
		}

		#endregion

		#region Конструкторы

		/// <summary>
		/// Конструктор по умолчанию - возвращает массив размером 2x2 и со значением 0
		/// </summary>
		public DoubleArray() : this(2, 2, 0)
		{
		}

		/// <summary>
		/// Создание массива определеннного размера, каждый элемент которого равен заданному значению
		/// </summary>
		/// <param name="sizeH">Количество столбцов массива</param>
		/// <param name="sizeV">Количество строк массива</param>
		/// <param name="val">Значение каждого элемента массива</param>
		public DoubleArray(int sizeH, int sizeV, int val)
		{
			_array = new int[sizeV, sizeH];
			for (int i = 0; i < _array.GetLength(0); i++)
			{
				for (int j = 0; j < _array.GetLength(1); j++)
				{
					_array[i, j] = val;
				}
			}
		}

		/// <summary>
		/// Метод создает и заполняет массив заданного размера случайными числами в заданном диапазоне
		/// </summary>
		/// <param name="sizeH">Количество столбцов массива</param>
		/// <param name="sizeV">Количество строк массива</param>
		/// <param name="min">Минимальное допустимое значение в массиве</param>
		/// <param name="max">Максимальное допустимое значение в массиве</param>
		public DoubleArray(int sizeH, int sizeV, int min = -10, int max = 10)
		{
			//Создаем массив
			_array = new int[sizeV, sizeH];

			//Меняем местами, если введенный минимум больше введенного максимума
			if (min > max)
			{
				int t = min;
				min = max;
				max = t;
			}

			Random rand = new Random();
			//Каждый элемент массива - случайное число в диапазоне от min до max
			for (int i = 0; i < _array.GetLength(0); i++)
			{
				for (int j = 0; j < _array.GetLength(1); j++)
				{
					_array[i, j] = rand.Next(min, max);
				}
			}
		}

		/// <summary>
		/// Создание массива из файла
		/// </summary>
		/// <param name="path">Путь к файлу</param>
		private DoubleArray(string path)
		{
			//С помощью вспомагательного метода определяем количество строк и столбцов в создаваемом массиве
			int lines;
			int columns;
			CountRowsAndLines(path, out lines, out columns);

			//Инициализируем массив
			_array = new int[lines, columns];

			using (StreamReader sr = new StreamReader(path))
			{
				//Каждая строка файла - новая строка массива, поэтому здесь вместо цикла в цикле используем счетчик по строкам
				int i = 0;
				while (!sr.EndOfStream)
				{
					string str = sr.ReadLine();
					if (!string.IsNullOrEmpty(str))
					{
						string[] strArr = str.Trim().Split('\t');
						for (int j = 0; j < strArr.Length && j < columns; j++)
						{
							int.TryParse(strArr[j], out _array[i, j]);
						}
					}
					//Прошли строку - увеличили счетчик на один.
					i++;
				}
			}
		}

		#endregion

		#region Методы

		/// <summary>
		/// Подсчет суммы всех элементов объекта
		/// </summary>
		/// <returns></returns>
		public int Summ()
		{
			int summ = 0;
			for (int i = 0; i < _array.GetLength(0); i++)
			{
				for (int j = 0; j < _array.GetLength(1); j++)
				{
					summ += _array[i, j];
				}
			}

			return summ;
		}

		/// <summary>
		/// Подсчет суммы всех элементов объекта, больше заданного
		/// </summary>
		/// <param name="val">Значение, больше которого мы ищем элементы</param>
		/// <returns></returns>
		public int Summ(int val)
		{
			int summ = 0;
			for (int i = 0; i < _array.GetLength(0); i++)
			{
				for (int j = 0; j < _array.GetLength(1); j++)
				{
					if (_array[i, j] > val)
						summ += _array[i, j];
				}
			}

			return summ;
		}

		/// <summary>
		/// Поиск номера максимального элемента массива
		/// </summary>
		public void NumberOfMax(out int v, out int h)
		{
			h = 0;
			v = 0;
			for (int i = 0; i < _array.GetLength(0); i++)
			{
				for (int j = 0; j < _array.GetLength(1); j++)
				{
					if (_array[i, j] != Max) continue;
					v = i;
					h = j;
					return;
				}
			}
		}

		/// <summary>
		/// Сохранение объекта в файл
		/// </summary>
		/// <param name="path">Путь к файлу</param>
		public void SaveToFile(string path)
		{
			using (StreamWriter sw = new StreamWriter(path))
			{
				for (int i = 0; i < _array.GetLength(0); i++)
				{
					for (int j = 0; j < _array.GetLength(1); j++)
					{
						sw.Write("{0}\t", _array[i,j]);
					}
					sw.WriteLine();
				}
			}
		}

		/// <summary>
		/// Созздание объекта из файла - если указанный файл существует, иначе создается массив по умолчанию.
		/// </summary>
		/// <param name="path">Путь к файлу</param>
		/// <returns></returns>
		public static DoubleArray LoadFromFile(string path)
		{
			return File.Exists(path) ? new DoubleArray(path) : new DoubleArray();
		}

		/// <summary>
		/// Вспомагательный метод подсчета строк и столбцов массива из файла
		/// </summary>
		/// <param name="path">Путь к файлу</param>
		/// <param name="lines">Возвращаемое количество строк</param>
		/// <param name="columns">Возвращаемое количество столбцов</param>
		private void CountRowsAndLines(string path, out int lines, out int columns)
		{
			//Обнуляем количество строк и столбцов
			lines = 0;
			columns = 0;

			using (StreamReader sr = new StreamReader(path))
			{
				//Флаг, говорящий о том, иницифлизированы солбцы - поскольку массив не "зубчатый", достаточно узнать их коичество лишь один раз.
				bool isRowsDefined = false;
				while (!sr.EndOfStream)
				{
					string str = sr.ReadLine();
					if (!string.IsNullOrEmpty(str))
					{
						string[] strArr = str.Trim().Split('\t');
						lines++;

						if (isRowsDefined) continue;
						//Единожды определяем количество столбцов и устанавливаем флаг в true
						columns = strArr.Length;
						isRowsDefined = true;
					}
				}
			}
		}

		public override string ToString()
		{
			StringBuilder str = new StringBuilder();
			for (int i = 0; i < _array.GetLength(0); i++)
			{
				for (int j = 0; j < _array.GetLength(1); j++)
				{
					str.AppendFormat("{0}\t", _array[i,j]);
				}
				str.Append("\n");
			}

			return str.ToString();
		}

		#endregion
	}
}
