using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
	class Program
	{
		static void Main(string[] args)
		{
			string expression;	//арифметическое выражение
			string[] numbers;
			do
			{
				Console.Write("Введите простое арифметическое выражение: ");
				expression = Console.ReadLine();
				//Console.WriteLine(expression);
				expression = expression.Replace(',', '.');  //Метод Replace() заменяет один символ другим, и возвращает измененную строку,
															//исходная строка при этом остается неизменной.
				numbers = expression.Split('+', '-', '*', '/');    //Метод string[] Split(...) разделяет строку по указанным разделителям.
																   //Этот метод не изменяет исходную строку, а возвращает измененную строку в виде массива строк. 
				if (numbers.Length != 2) Console.WriteLine("Вы допустили ошибку, попробуйте еще раз.");
			} while (numbers.Length != 2);
			double a = Convert.ToDouble(numbers[0]);
			double b = Convert.ToDouble(numbers[1]);
			Console.WriteLine(a + "\t" + b);
			switch (expression[expression.IndexOfAny(new char[] { '+', '-', '*', '/' })])
			{
				case '+': Console.WriteLine($"{a} + {b} = {a + b}"); break;
				case '-': Console.WriteLine($"{a} - {b} = {a - b}"); break;
				case '*': Console.WriteLine($"{a} * {b} = {a * b}"); break;
				case '/': Console.WriteLine($"{a} / {b} = {a / b}"); break;
			}
		}
	}
}
