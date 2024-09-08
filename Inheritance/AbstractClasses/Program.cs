using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
	class Program
	{
		static void Main(string[] args)
		{
			//Animal animal = new Animal();
			Wolf wolf = new Wolf();
			wolf.Sound();
			Chihuahua nedosobaka = new Chihuahua();
			nedosobaka.Sound();
		}
	}
}
