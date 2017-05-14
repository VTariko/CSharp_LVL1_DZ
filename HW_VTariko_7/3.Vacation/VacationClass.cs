using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Vacation
{
	/// <summary>
	/// Класс, формирующий заявление на отпуск
	/// </summary>
	class VacationClass
	{
		#region Поля

		private string _company;
		private string _boss;
		private string _vacationerGen;
		private string _vacationer;
		private string _post;
		private string _dateFrom;
		private string _dateTo;
		private string _dateNow;

		#endregion

		#region Свойства

		/// <summary>
		/// Наименование организации
		/// </summary>
		public string Company {
			get { return _company; }
			set
			{
				if (_company != value)
					_company = value;
			}
		}


		/// <summary>
		/// ФИО Директора
		/// </summary>
		public string Boss {
			get { return _boss; }
			set
			{
				if (_boss != value)
					_boss = value;
			}
		}

		/// <summary>
		/// ФИО Отпускника в родительном падеже
		/// </summary>
		public string VacationerGen {
			get { return _vacationerGen; }
			set
			{
				if (_vacationerGen != value)
					_vacationerGen = value;
			}
		}

		/// <summary>
		/// ФИО Отпускника
		/// </summary>
		public string Vacationer {
			get { return _vacationer; }
			set
			{
				if (_vacationer != value)
					_vacationer = value;
			}
		}

		/// <summary>
		/// Должность отпускника
		/// </summary>
		public string Post {
			get { return _post; }
			set
			{
				if (_post != value)
					_post = value;
			}
		}

		/// <summary>
		/// Дата начала отпуска
		/// </summary>
		public string DateFrom {
			get { return _dateFrom; }
			set
			{
				if (_dateFrom != value)
					_dateFrom = value;
			}
		}

		/// <summary>
		/// Дата окончания отпуска
		/// </summary>
		public string DateTo {
			get { return _dateTo; }
			set
			{
				if (_dateTo != value)
					_dateTo = value;
			}
		}

		/// <summary>
		/// Дата подачи заявления
		/// </summary>
		public string DateNow
		{
			get { return _dateNow; }
			set
			{
				if (_dateNow != value)
					_dateNow = value;
			}
		}

		#endregion

		#region Конструкторы



		#endregion

		#region Методы

		/// <summary>
		/// Оформление заявления на отпуск
		/// </summary>
		public string CreateApplicationForLeave()
		{
			if (!string.IsNullOrEmpty(_company) && !string.IsNullOrEmpty(_boss) && !string.IsNullOrEmpty(_vacationerGen) &&
			    !string.IsNullOrEmpty(_vacationer) && !string.IsNullOrEmpty(_post) && !string.IsNullOrEmpty(_dateFrom) &&
				!string.IsNullOrEmpty(_dateTo) && !string.IsNullOrEmpty(_dateNow))
			{
				Dictionary<string, string> vacationDictionary = new Dictionary<string, string>
				{
					{"name1", Company},
					{"name2", Boss},
					{"name3", Post},
					{"name4", VacationerGen},
					{"name5", Vacationer},
					{"data1", DateFrom},
					{"data2", DateTo},
					{"data3", DateNow}
				};

				string file = File.ReadAllText("shablon.txt");
				foreach (KeyValuePair<string, string> valuePair in vacationDictionary)
				{
					Regex regex = new Regex("<" + valuePair.Key+">");
					file = regex.Replace(file, valuePair.Value);
				}
				return file;
			}
			throw new Exception("Данные заполнены некорректно!");
		}

		#endregion
	}
}
