//#define INHERITANCE_1
//#define INHERITANCE_2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	class Program
	{
		static readonly string delimiter = "\n----------------------------------\n";
		static void Main(string[] args)
		{
#if INHERITANCE_1
			Human human = new Human("Montana", "Antonio", 25);
			human.Print();
			Console.WriteLine(human);
			Console.WriteLine(delimiter);

			Student student = new Student("Pinkman", "Jessie", 25, "Chemistry", "WW_220", 95, 97);
			student.Print();
			Console.WriteLine(student);
			Console.WriteLine(delimiter);

			Teacher teacher = new Teacher("White", "Walter", 50, "Chemistry", 25);
			teacher.Print();
			Console.WriteLine(teacher);
			Console.WriteLine(delimiter);

			Graduate graduate = new Graduate("Schreder", "Hank", 40, "Criminalistic", "OBN", 50, 80, "How to catch Heisenberg");
			graduate.Print();
			Console.WriteLine(graduate); 
#endif

#if INHERITANCE_2
			Human tommy = new Human("Vercetty", "Tommy", 30);
			Console.WriteLine(tommy);

			Human ken = new Human("Rozenberg", "Ken", 35);
			Console.WriteLine(ken);

			Human diaz = new Human("Diaz", "Ricardo", 50);
			Console.WriteLine(diaz);

			Student s_tommy = new Student(tommy, "Theft", "Vice", 98, 99);
			Console.WriteLine(s_tommy);

			Student s_ken = new Student(ken, "Lawer", "Vice", 42, 35);
			Console.WriteLine(s_ken);

			Graduate g_tommy = new Graduate(s_tommy, "How to make money");
			Console.WriteLine(g_tommy);

			Teacher t_diaz = new Teacher(diaz, "Weapons distribution", 20);
			Console.WriteLine(t_diaz); 
#endif

			//Generalization:
			Human[] group = new Human[]
				{
					new Student("Pinkman", "Jessie", 25, "Chemistry", "WW_220", 95, 97),
					new Teacher("White", "Walter", 50, "Chemistry", 25),
					new Graduate("Schreder", "Hank", 40, "Criminalistic", "OBN", 50, 80, "How to catch Heisenberg")
				};
			//Specialization:
			for (int i = 0; i < group.Length; i++)
			{
				Console.WriteLine(group[i]);
			}
		}
	}
}
