using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForwardList
{
	class Element:IEnumerator
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
		public object Current { get => pNext.Data; }
		public bool MoveNext() //=> pNext != null;
		{

			pNext = pNext.pNext;
			//if (pNext != null) return true;
			//else return false;
			return pNext != null;
		}
		public void Reset() { Console.WriteLine("Reset"); }
	}
}
