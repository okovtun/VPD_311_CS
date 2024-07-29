//#define FACTORIAL_1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Factorial
{
	class Program
	{
		static readonly string delimiter = "\n-----------------------------\n";
		static void Main(string[] args)
		{
			Console.Write("Введите число: ");
			int n = Convert.ToInt32(Console.ReadLine());
#if FACTORIAL_1
			long f = 1;
			int i = 1;
			try
			{
				for (/*counter*/; i <= n; i++)
				{
					f *= i;
					Console.WriteLine($"{i}! = {f}");
				}
				Console.WriteLine($"Конечный результат: {--i}! = {f};");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				i--;
				Console.WriteLine($"Последний правильный результат: {i}! = {f};");
			} 
			//https://stackoverflow.com/questions/2056445/no-overflow-exception-for-int-in-c
#endif
			BigInteger f = 1;
			int i = 1;
			for (/*counter*/; i <= n; i++)
			{
				f *= i;
				//Console.WriteLine($"{i}! = {f}");
				//Console.WriteLine(delimiter);
			}
			Console.WriteLine($"Конечный результат: {--i}! = {f};");
		}
	}
}
