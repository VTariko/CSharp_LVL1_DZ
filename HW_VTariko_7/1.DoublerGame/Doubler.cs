using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DoublerGame.Annotations;

namespace DoublerGame
{
	/// <summary>
	/// Класс игры дублер - хранит в себе текущее значение, финишное
	/// </summary>
	class Doubler : INotifyPropertyChanged
	{
		#region Поля

		private int _current;

		private Stack<int> _currentStack;

		#endregion

		#region Свойства

		/// <summary>
		/// Возвращает текущее значение
		/// </summary>
		public int Current
		{
			get { return _current; }
			set
			{
				if (value != _current)
				{
					_current = value;
					OnPropertyChanged();
					OnPropertyChanged(nameof(Percent));
				}
			}
		}

		/// <summary>
		/// Возвращает конечное значение
		/// </summary>
		public int Finish { get; }

		/// <summary>
		/// Процент приближения текущего значения к заданному
		/// </summary>
		public double Percent => ((double) Current/Finish)*100;

		/// <summary>
		/// Возвращает количество совершенных итераций
		/// </summary>
		public int Attempt { get; private set; }

		#endregion

		#region Конструктор

		/// <summary>
		/// Создание конечного числа
		/// </summary>
		/// <param name="max"></param>
		public Doubler(int max)
		{
			Current = 1;
			Attempt = 0;
			_currentStack = new Stack<int>();
			Random rand = new Random();
			Finish = rand.Next(1, max) + 1;
		}

		#endregion

		#region Методы

		/// <summary>
		/// Прибавить к текущему числу единицу
		/// </summary>
		public bool? AddOne()
		{
			SaveCurrentAndAddAttempt();
			Current++;
			return CheckProgress();
		}

		/// <summary>
		/// Умножить текущее число на два
		/// </summary>
		public bool? MultiTwo()
		{
			SaveCurrentAndAddAttempt();
			Current *= 2;
			return CheckProgress();
		}

		/// <summary>
		/// Сброс текущего числа до единицы
		/// </summary>
		public void ToOne()
		{
			SaveCurrentAndAddAttempt();
			Current = 1;
		}

		public bool Cancel()
		{
			Current = _currentStack.Pop();
			Attempt--;
			return _currentStack.Count > 0;
		}

		public bool? CheckProgress()
		{
			if (Current==Finish)
			{
				return true;
			}
			if (Current>Finish)
			{
				return false;
			}
			return null;
		}

		private void SaveCurrentAndAddAttempt()
		{
			_currentStack.Push(_current);
			Attempt++;
		}

		#endregion


		protected void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, e);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
