//#define CONSOLE_PARAMETERS
//#define INPUT_DATA
//#define DATA_TYPES
//#define LITERALS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToDOTNET
{
	class Program
	{
		static readonly string  delimiter = "\n----------------------------------------\n";
		static void Main(string[] args)
		{
			Console.Title = "Introduction to .NET";
#if CONSOLE_PARAMETERS
			Console.Beep(137, 1000);
			Console.BackgroundColor = ConsoleColor.DarkBlue;
			//Console.CursorLeft = 22;
			//Console.CursorTop = 11;
			Console.SetCursorPosition(22, 7);
			Console.Write("Hello .NET\n");    //Выводит строку на экран
			Console.WriteLine("Introduction");//Выводит строку на экран, и переводит курсор в начало следующей строки.
			Console.BackgroundColor = ConsoleColor.DarkGreen;
			Console.ResetColor(); 
#endif

#if INPUT_DATA
			Console.Write("Введите Ваше имя: ");
			string first_name = Console.ReadLine();
			Console.Write("Введите Вашу фамилию: ");
			string last_name = Console.ReadLine();
			Console.Write("Введите Ваш возраст:");
			int age = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Ваше имя: " + first_name + ", Ваша фамилия: " + last_name + ", Ваш возраст: " + age);   //Конкатенация строк
			Console.WriteLine(String.Format("Ваше имя: {0}, Ваша фамилия: {1}, Ваш возраст: {2}", first_name, last_name, age));//Форматирование строк
			Console.WriteLine($"Ваше имя: {first_name}, Ваша фамилия: {last_name}, Ваш возраст: {age}");    //Интерполяция строк  
#endif

#if DATA_TYPES
			//Console.WriteLine("CHAR");
			//Console.WriteLine(sizeof(char));
			//Console.WriteLine((int)char.MinValue);
			//Console.WriteLine((int)char.MaxValue);
			//Console.WriteLine();    //cout << endl;

			//Console.WriteLine("SHORT");
			Console.WriteLine($"Переменная типа 'short' занимает {sizeof(short)} Байт памяти, и принимает значения в диапазоне");
			Console.WriteLine($"ushort: {ushort.MinValue} ... {ushort.MaxValue}");
			Console.WriteLine($" short: {short.MinValue} ... {short.MaxValue}");
			Console.WriteLine(delimiter);

			//Console.WriteLine(sizeof(short));
			//Console.WriteLine($"{short.MinValue} ... {short.MaxValue}");
			//Console.WriteLine("USHORT");
			//Console.WriteLine(sizeof(ushort));
			//Console.WriteLine($"{ushort.MinValue} ... {ushort.MaxValue}");

			Console.WriteLine($"Переменная типа 'int' занимает {sizeof(int)} Байт памяти, и принимает значения в диапазоне");
			Console.WriteLine($"uint: {uint.MinValue} ... {uint.MaxValue}");
			Console.WriteLine($" int: {int.MinValue} ... {int.MaxValue}");
			Console.WriteLine(delimiter);

			Console.WriteLine($"Переменная типа 'long' занимает {sizeof(long)} Байт памяти, и принимает значения в диапазоне");
			Console.WriteLine($"ulong: {ulong.MinValue} ... {ulong.MaxValue}");
			Console.WriteLine($" long: {long.MinValue} ... {long.MaxValue}");
			Console.WriteLine(delimiter);

			/*
			float	-  4 Byte
			double	-  8 Byte
			decimal - 16 Byte	//Money
			 */

			Console.WriteLine($"Переменная типа 'float' занимает {sizeof(float)} Байт памяти, и принимает значения в диапазоне");
			Console.WriteLine($"float: {float.MinValue} ... {float.MaxValue}");
			Console.WriteLine("Класс-обвертка 'Single'");
			Console.WriteLine(delimiter);

			Console.WriteLine($"Переменная типа 'double' занимает {sizeof(double)} Байт памяти, и принимает значения в диапазоне");
			Console.WriteLine($"double: {double.MinValue} ... {double.MaxValue}");
			//IEEE-754
			Console.WriteLine(delimiter);

			Console.WriteLine($"Переменная типа 'decimal' занимает {sizeof(decimal)} Байт памяти, и принимает значения в диапазоне");
			Console.WriteLine($"decimal: {decimal.MinValue} ... {decimal.MaxValue}");
			Console.WriteLine(delimiter);

#endif

#if LITERALS
			Console.WriteLine(((object)5.0M).GetType());
			Console.WriteLine("+".GetType());
#endif
			int a = 2000000000;
			int b = 5;
			//a = (short)b;	//CS0266
			////b = a;
			////uint c = (uint)b;
			////Console.WriteLine(c);
			Console.WriteLine(a*b);
			Console.WriteLine((a*b).GetType());
			//https://stackoverflow.com/questions/2056445/no-overflow-exception-for-int-in-c
		}
	}
}
