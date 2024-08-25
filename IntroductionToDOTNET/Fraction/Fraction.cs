using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
	class Fraction
	{
		public int Integer { get; set; }
		public int Numerator { get; set; }
		int denominator;
		public int Denominator
		{
			get => denominator;
			set
			{
				if (value == 0) value = 1;
				denominator = value;
			}
		}
		public Fraction()
		{
			denominator = 1;
			Console.WriteLine($"DefConstructor:\t{this.GetHashCode()}");
		}
		public Fraction(int integer)
		{
			Integer = integer;
			Denominator = 1;
			Console.WriteLine($"Constructor:\t{this.GetHashCode()}");
		}
		public Fraction(int numerator, int denominator)
		{
			Numerator = numerator;
			Denominator = denominator;
			Console.WriteLine($"Constructor:\t{this.GetHashCode()}");
		}
		public Fraction(int integer, int numerator, int denominator)
		{
			Integer = integer;
			Numerator = numerator;
			Denominator = denominator;
			Console.WriteLine($"Constructor:\t{this.GetHashCode()}");
		}
		public Fraction(Fraction other)
		{
			this.Integer = other.Integer;
			this.Numerator = other.Numerator;
			this.Denominator = other.Denominator;
			Console.WriteLine($"CopyConstructor:{this.GetHashCode()}");
		}
		~Fraction()
		{
			Console.WriteLine($"Destructor:\t{this.GetHashCode()}");
		}

		//					Arithmetical operators:
		public static Fraction operator *(Fraction left, Fraction right)
		{
			/*Fraction left_copy = new Fraction(left);
			Fraction right_copy = new Fraction(right);
			left_copy.ToImproper();
			right_copy.ToImproper();*/
			//Fraction left_copy = left.ToImproper();
			//Fraction right_copy = right.ToImproper();
			//Fraction result = new Fraction
			//	(
			//		left_copy.Numerator * right_copy.Numerator,
			//		left_copy.Denominator * right_copy.Denominator
			//	);
			//return result.ToProper();
			/*return new Fraction
				(
					left_copy.Numerator * right_copy.Numerator,
					left_copy.Denominator * right_copy.Denominator
				);*/
			return new Fraction
			(
				left.ToImproper().Numerator * right.ToImproper().Numerator,
				left.ToImproper().Denominator * right.ToImproper().Denominator
			);
		}
		public static Fraction operator /(Fraction left, Fraction right)
		{
			return left * right.Inverted();
		}

		//					Comparison operators:
		public static bool operator ==(Fraction left, Fraction right)
		{
			return left.ToImproper().Numerator * right.ToImproper().Denominator == right.ToImproper().Numerator * left.ToImproper().Denominator;
		}
		public static bool operator !=(Fraction left, Fraction right)
		{
			return !(left == right);
		}

		//					Methods:
		public Fraction ToProper()
		{
			//int rest = Numerator / Denominator;
			//Integer += rest;
			//Numerator %= Denominator;
			//return this;
			Fraction proper = new Fraction();
			proper.Integer += Numerator / Denominator;
			proper.Numerator = Numerator % Denominator;
			proper.Denominator = Denominator;
			return proper;
		}
		public Fraction ToImproper()
		{
			//Numerator += Integer * Denominator;
			//Integer = 0;
			//return this;
			return new Fraction(Numerator + Integer * Denominator, Denominator);
		}
		public Fraction Inverted()
		{
			//Fraction inverted = new Fraction(this);
			//inverted.ToImproper();
			Fraction inverted = ToImproper();
			//(inverted.Numerator, inverted.Denominator) = (inverted.Denominator, inverted.Numerator);
			//https://stackoverflow.com/questions/804706/swap-two-variables-without-using-a-temporary-variable
			int buffer = inverted.Numerator;
			inverted.Numerator = inverted.Denominator;
			inverted.Denominator = buffer;
			return inverted;
		}
		public void Print()
		{
			if (Integer != 0) Console.Write(Integer);
			if (Numerator != 0)
			{
				if (Integer != 0) Console.Write("(");
				Console.Write($"{Numerator}/{Denominator}");
				if (Integer != 0) Console.Write(")");
			}
			else if (Integer == 0) Console.Write(0);
			Console.WriteLine();
		}
	}
}