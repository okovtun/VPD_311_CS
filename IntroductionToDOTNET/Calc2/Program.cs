using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc2
{
	class Program
	{
		static string expression;
		static void Main(string[] args)
		{
			Console.Write("Введите арифметическое выражение: ");
			//expression = Console.ReadLine();
			expression = "(22+33)*(77*(55-50))/11";
			Console.WriteLine(expression);
			Explore(expression);
			Console.WriteLine(Calculate(expression));

		}
		static void Explore(string expression)
		{
			for (int i = 0; i < expression.Length; i++)
			{
				if (expression[i] == '(')
				{
					for (int j = i + 1; j < expression.Length; j++)
					{
						if (expression[j] == ')')
						{
							expression = expression.Replace
								(
								expression.Substring(i, j-i+1),	//подменяем часть выражения со скобками, но
								Calculate(expression.Substring(i + 1, j - i - 1)).ToString()//в Calculate() передаем выражение без скобок
								);
							Program.expression = expression;
							break;
						}
						if (expression[j] == '(')
						{
							Explore(expression.Substring(j));
							//Program.expression = expression;
						}
					}
				}
			}
		}
		static double Calculate(string expression)
		{
			Console.WriteLine(expression);
			//char[] delimiters = new char[] { '+', '-', '*', '/' };
			string[] s_numbers = expression.Split('+', '-', '*', '/');
			for (int i = 0; i < s_numbers.Length; i++) Console.Write(s_numbers[i] + "\t"); Console.WriteLine();
			double[] numbers = new double[s_numbers.Length];
			for (int i = 0; i < numbers.Length; i++)
			{
				numbers[i] = Convert.ToDouble(s_numbers[i]);
				Console.Write(numbers[i] + "\t");
			}
			Console.WriteLine();

			string[] operators = expression.Split('0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ', '.');
			for (int i = 0; i < operators.Length; i++) Console.Write(operators[i] + "\t"); Console.WriteLine();
			operators = operators.Where(val => val != "").ToArray();    //Linq
			for (int i = 0; i < operators.Length; i++) Console.Write(operators[i] + "\t"); Console.WriteLine();
			////////////////////////////////////////////////////////////////////////////////////////////
			for (int i = 0; i < operators.Length; i++)
			{
				while (operators[i] == "*" || operators[i] == "/")
				{
					if (operators[i] == "*") numbers[i] *= numbers[i + 1];
					if (operators[i] == "/") numbers[i] /= numbers[i + 1];
					ShiftLeft(numbers, i + 1);
					ShiftLeft(operators, i);
				}
			}
			Print(numbers);
			Print(operators);
			//////////////////////////////////////////////////////////////////////////////////////
			for (int i = 0; i < operators.Length; i++)
			{
				while (operators[i] == "+" || operators[i] == "-")
				{
					if (operators[i] == "+") numbers[i] += numbers[i + 1];
					if (operators[i] == "-") numbers[i] -= numbers[i + 1];
					ShiftLeft(numbers, i + 1);
					ShiftLeft(operators, i);
				}
			}
			Print(numbers);
			Print(operators);
			return numbers[0];
		}
		static void Print(double[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
				Console.Write(arr[i] + "\t");
			Console.WriteLine();
		}
		static void Print(string[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
				Console.Write(arr[i] + "\t");
			Console.WriteLine();
		}
		static double[] ShiftLeft(double[] arr, int index = 0)
		{
			for (int i = index; i < arr.Length - 1; i++)
				arr[i] = arr[i + 1];
			arr[arr.Length - 1] = 0;
			return arr;
		}
		static string[] ShiftLeft(string[] arr, int index = 0)
		{
			for (int i = index; i < arr.Length - 1; i++)
				arr[i] = arr[i + 1];
			arr[arr.Length - 1] = null;
			return arr;
		}

	}
}