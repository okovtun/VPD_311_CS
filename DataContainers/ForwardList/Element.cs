using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForwardList
{
	class Element
	{
		public int Data { get; set; }		//Значение элемента
		public Element pNext { get; set; }  //Следующий элемент
		public Element(int Data, Element pNext = null)
		{
			this.Data = Data;
			this.pNext = pNext;
			Console.WriteLine($"EConstructor:\t{GetHashCode()}");
		}
		~Element()
		{
			Console.WriteLine($"EDestructor:\t{GetHashCode()}");
		}
	}
}
