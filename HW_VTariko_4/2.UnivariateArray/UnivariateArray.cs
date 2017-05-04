using System.IO;

namespace UnivariateArray
{
	class UnivariateArray
	{
		#region Поля

		private int[] _array;

		#endregion

		#region Свойства

		/// <summary>
		/// Максимальный элемент объекта
		/// </summary>
		public int Max
		{
			get
			{
				int max = _array[0];
				for (int i = 0; i < _array.Length; i++)
				{
					if (_array[i] > max) max = _array[i];
				}
				return max;
			}
		}

		/// <summary>
		///  Минимальный элемент объекта
		/// </summary>
		public int Min
		{
			get
			{
				int min = _array[0];
				for (int i = 0; i < _array.Length; i++)
					if (_array[i] < min) min = _array[i];
				return min;
			}
		}

		/// <summary>
		/// Количество положительных элементов объекта
		/// </summary>
		public int CountPositive
		{
			get
			{
				int count = 0;
				for (int i = 0; i < _array.Length; i++)
					if (_array[i] > 0) count++;
				return count;
			}
		}

		/// <summary>
		/// Количество отричательных элементов объекта
		/// </summary>
		public int CountNegative
		{
			get
			{
				int count = 0;
				for (int i = 0; i < _array.Length; i++)
					if (_array[i] < 0) count++;
				return count;
			}
		}

		/// <summary>
		/// Сумма элементов объекта
		/// </summary>
		public long Sum
		{
			get
			{
				int sum = 0;
				for (int i = 0; i < _array.Length; i++)
				{
					sum += _array[i];
				}
				return sum;
			}
		}

		/// <summary>
		/// Количесвто максимальных элементов объекта
		/// </summary>
		public int MaxCount
		{
			get
			{
				int count = 0;
				//Определеяем свойство Max в переменную, чтобы в цикле не каждый раз его определять.
				int max = Max;
				for (int i = 0; i < _array.Length; i++)
				{
					if (_array[i] == max)
						count++;
				}
				return count;
			}
		}

		#endregion

		#region Конструкторы

		/// <summary>
		/// Конструктор по умолчанию - возвращает массив размером 1 и со значением 0
		/// </summary>
		public UnivariateArray() : this(1, 0)
		{
		}
		
		/// <summary>
		/// Создание массива определеннного размера, каждый элемент которого равен заданному значению
		/// </summary>
		/// <param name="size">Размер массива</param>
		/// <param name="val">Значение каждого элемента массива</param>
		public UnivariateArray(int size, int val)
		{
			_array = new int[size];
			for (int i = 0; i < size; i++)
			{
				_array[i] = val;
			}
		}

		/// <summary>
		/// Создание массива определенного размера от начального значения с заданным шагом
		/// </summary>
		/// <param name="size">Размер массива</param>
		/// <param name="start">Начальное значение</param>
		/// <param name="step">Шаг</param>
		public UnivariateArray(int size, int start, int step)
		{
			_array = new int[size];
			_array[0] = start;
			for (int i = 1; i < size; i++)
			{
				_array[i] = _array[i-1] + step;
			}
		}

		/// <summary>
		/// Создание массива из файла по образцу "12, 40, 21, 5, ...."
		/// </summary>
		/// <param name="path">Путь к файлу</param>
		public UnivariateArray(string path)
		{
			using (StreamReader sr = new StreamReader(path))
			{
				string str = sr.ReadLine();
				if (!string.IsNullOrEmpty(str))
				{
					string[] strArray = str.Split(',');
					_array = new int[strArray.Length];
					for (int i = 0; i < strArray.Length; i++)
					{
						int.TryParse(strArray[i], out _array[i]);
					}
				}
				else
				{
					_array = new int[1];
					_array[0] = 0;
				}

			}
		}

		#endregion

		#region Методы

		/// <summary>
		/// Метод, меняющий знаки у всех элементов массива на противоположный
		/// </summary>
		public void Inverse()
		{
			for (int i = 0; i < _array.Length; i++)
			{
				_array[i] = -_array[i];
			}
		}

		/// <summary>
		/// Умножение каждого элемента массива на заданное число
		/// </summary>
		/// <param name="factor">Множитель</param>
		public void Multi(int factor)
		{
			for (int i = 0; i < _array.Length; i++)
			{
				_array[i] *= factor;
			}
		}

		/// <summary>
		/// Созздание объекта из файла - если указанный файл существует, иначе создается массив по умолчанию.
		/// </summary>
		/// <param name="path">Путь к файлу</param>
		/// <returns>Объект класса UnivariateArray</returns>
		public static UnivariateArray CreateFromFile(string path)
		{
			return File.Exists(path) ? new UnivariateArray(path) : new UnivariateArray();
		}

		/// <summary>
		/// Сохранение объекта в файл
		/// </summary>
		/// <param name="path"></param>
		public void SaveToFile(string path)
		{
			using (StreamWriter sw = new StreamWriter(path))
			{
				sw.WriteLine(this);
			}
		}


		public override string ToString()
		{
			return string.Join(", ", _array);
		}

		#endregion

	}
}
