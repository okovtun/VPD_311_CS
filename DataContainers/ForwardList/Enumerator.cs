using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ForwardList
{
	//Generics
	class Enumerator<T> : IEnumerator
	{
		Element<T> Head { get; set; }
		public Element<T> Temp { get; set; }
		public Enumerator(Element<T> Head = null)
		{
			this.Head = Head;
			//this.Temp = null;
			Console.WriteLine($"EnumConstructor:\t{GetHashCode()}");
		}
		~Enumerator()
		{
			Console.WriteLine($"EnumDestructor:\t{GetHashCode()}");
		}
		public object Current { get => Temp.Data; }
		public bool MoveNext()
		{
			//if (Temp == null) Temp = Head;
			//else Temp = Temp.pNext;
			Temp = Temp == null ? Head : Temp.pNext;
			return Temp != null;
		}
		public void Reset()
		{
			//https://learn.microsoft.com/ru-ru/dotnet/api/system.collections.ienumerator.reset?view=net-8.0
			//https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1.enumerator.movenext?view=net-8.0
			//https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1.enumerator.current?view=net-8.0#system-collections-generic-linkedlist-1-enumerator-current
			Temp = null;
			Console.WriteLine($"RESET: {Temp.Data}");
		}
	}
}
