using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForwardList
{
	class ForwardList:IEnumerable
	{
		Element Head;
		public uint Size { get; private set; }
		public IEnumerator GetEnumerator() => new Enumerator(Head);
		public void Add(int Data) => push_back(Data);
		public ForwardList()
		{
			Head = null;
			Size = 0;
			Console.WriteLine($"LConstructor:\t{GetHashCode()}");
		}
		~ForwardList()
		{
			Console.WriteLine($"LDestructor:\t{GetHashCode()}");
		}
		public void Clear()
		{
			while (Head != null) pop_back();
			Head = null;
		}

		//					Adding elements:
		public void push_front(int Data)
		{
			#region FullVersion
			////1) Создаем новый элемент:
			//Element New = new Element(Data);
			////2) Подключаем новый элемент к списку:
			//New.pNext = Head;
			////3) Смещаем Голову на новый элемент:
			//Head = New; 
			#endregion

			Head = new Element(Data, Head);

			Size++;
		}
		public void push_back(int Data)
		{
			if (Head == null) push_front(Data);
			else
			{
				Element Temp = Head;
				while (Temp.pNext != null)
					Temp = Temp.pNext;
				Temp.pNext = new Element(Data);
				Size++;
			}
		}
		public void insert(int Data, int Index)
		{
			if (Index > Size) return;
			if (Index == 0) push_front(Data);
			else
			{
				//1) Доходим до нужного элемента:
				Element Temp = Head;
				for (int i = 0; i < Index - 1; i++)
					Temp = Temp.pNext;
				//if (Temp.pNext == null) break;
				//else	Temp = Temp.pNext;

				//2) Создаем новый элемент:
				//3) И включаем элемент в список:
				Temp.pNext = new Element(Data, Temp.pNext);
				Size++; 
			}
		}

		//					Removing elements:
		public void pop_front()
		{
			Head = Head.pNext;      //2) Исключаем элемент из списка
			Size--;
		}
		public void pop_back()
		{
			if (Head == null) return;
			else if (Head.pNext == null) pop_front();
			else
			{
				Element Temp = Head;
				while (Temp.pNext.pNext != null)
					Temp = Temp.pNext;
				Temp.pNext = null;
				Size--;
			}
		}

		//					Methods:
		public void Print()
		{
			Element Temp = Head;    //Temp - это итератор.
									//Итератор - это указатель, при помощи которого можно получить доступ к элементам структурыу данных.
			while (Temp != null)
			{
				Console.Write($"{Temp.Data}\t");
				Temp = Temp.pNext;  //переход на следующий элемент
			}
			Console.WriteLine();
		}
	}
}
