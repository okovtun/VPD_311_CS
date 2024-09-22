//#define BASE_CHECK
#define HOME_WORK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForwardList
{
	class Program
	{
		static void Main(string[] args)
		{
			Random rand = new Random(0);
#if BASE_CHECK
			Console.Write("Введите размер списка: ");
			int n = Convert.ToInt32(Console.ReadLine());
			ForwardList list = new ForwardList();
			for (int i = 0; i < n; i++)
			{
				list.push_back(rand.Next(100));
			}
			list.Print();
			//list.pop_back();
			//list.Clear();
			//list.Print();

			Console.Write("Введите индекс добавляемого элемента: ");
			int index = Convert.ToInt32(Console.ReadLine());
			Console.Write("Введите значение добавляемого элемента: ");
			int value = Convert.ToInt32(Console.ReadLine());
			list.insert(value, index);
			list.Print(); 
#endif

#if HOME_WORK
			ForwardList<int> list = new ForwardList<int>() { 3, 5, 8, 13, 21, 34, 55, 89, 144 };
			list.Print();
			foreach (int i in list)
			{
				Console.Write(i + "\t");
			}
			Console.WriteLine();

			ForwardList<double> d_list = new ForwardList<double>() { 2.7, 3.4, 5.2, 8.3 };
			foreach (double i in d_list) Console.Write($"{i}\t"); Console.WriteLine();

			ForwardList<string> s_list = new ForwardList<string>() { "Ах", "ты", "ж", "Ёжтыкин", "ты ", "20" };
			foreach (string i in s_list) Console.Write($"{i}\t"); Console.WriteLine();
#endif
		}
	}
}
/*
----------------------------------
I....able
I - Interface
able - способен
IFlyable;
IMovable;
ISortable;
----------------------------------
 */
