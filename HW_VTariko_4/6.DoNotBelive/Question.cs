using System;

namespace DoNotBelive
{
	/// <summary>
	/// Класс вопроса с ответом
	/// </summary>
	class Question
	{
		#region Свойства

		/// <summary>
		/// Вопрос
		/// </summary>
		public string Query { get; }

		/// <summary>
		/// Ответ
		/// </summary>
		public bool Answer { get; }

		#endregion

		#region Конструкторы

		public Question(string query, string ans)
		{
			Query = query;
			Answer = string.Equals(ans, "Да", StringComparison.OrdinalIgnoreCase);
		}

		#endregion
	}
}
