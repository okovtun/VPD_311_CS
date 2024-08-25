using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
	class Point
	{
		double x;
		double y;
		//Properties
		public double X
		{
			get => x;
			set
			{
				if (value > 100) value = 100;
				x = value; //ключевое слово 'value' возвращает значение, которое приходит извне.
			}
		}
		public double Y
		{
			get => y;
			set { y = value; }
		}
		public double GetX()
		{
			return x;
		}
		public double GetY()
		{
			return y;
		}
		public void SetX(double x)
		{
			this.x = x;
		}
		public void SetY(double y)
		{
			this.y = y;
		}

		//Можно использовать автосвойства:
		//public double X { get; set; }
		//public double Y { get; set; }

		public Point(double x = 0, double y = 0)
		{
			X = x;
			Y = y;
			Console.WriteLine($"Constructor:\t {this.GetHashCode()}");
		}
		~Point()
		{
			//Деструктор не обязателен, потому что есть Garbage collector.
			Console.WriteLine($"Destructor:\t {this.GetHashCode()}");
		}
	}
}
/*
--------------------------------
1. Модификаторы доступа:
	private;
	public;
	protected;
	internal - поля доступны в пределах данной сборки (Assembly);
	protected internal - поля доступны дочерним классам в пределах нашей сборки;
2. Get/Set-методы;
3. Свойства (Properties) - это синтаксическая конструкция, которая объединяет в себе Get и Set методы,
						   и позволяет использовать эти Get/Set-методы как обычную переменную в классе.
						   Свойства пишутся для каждой переменной в классе.
						   Переменную обычно нзывают с маленбкой буквы, а ее свойства с точно так-же 
						   как и переменную, но с большой.
	access_modifire type Name
	{
		get;
		set;
	}
--------------------------------
 */
