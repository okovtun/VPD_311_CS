using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
	class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine("Get/Set:");
			Point A = new Point(2, 3);
			//A.SetX(2);
			//A.SetY(3);
			Console.WriteLine($"X = {A.GetX()},	Y = {A.GetY()}");

			Console.WriteLine("Properties:");
			Point B = new Point();
			B.X = 7;
			B.Y = 8;
			Console.WriteLine($"X = {B.X}, Y = {B.Y}");
		}
	}
}
