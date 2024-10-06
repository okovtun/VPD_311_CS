#pragma once
#include<iostream>
#include<string>
using std::cin;
using std::cout;
using std::endl;

#define tab "\t"
#define delimiter "\n----------------------------\n"

//Class<T>

/////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////					ОБЪЯВЛЕНИЕ КЛАССА (CLASS DECLARATION)						 ////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////

template<typename T>class List
{
	class Element
	{
		T Data;
		Element* pNext;
		Element* pPrev;
	public:
		Element(T Data, Element* pNext = nullptr, Element* pPrev = nullptr)
			:Data(Data), pNext(pNext), pPrev(pPrev) {}
		~Element() {}
		friend class List;
	}*Head, *Tail;	//Объявляем два указателя на объекты класса 'Element' непосредственно после описания класса;
	size_t size;	//Количество элементов списка

	class ConstBaseIterator
	{
	protected:
		Element* Temp;
	public:
		ConstBaseIterator(Element* Temp) :Temp(Temp) {}
		~ConstBaseIterator() {}

		bool operator==(const ConstBaseIterator& other)const;
		bool operator!=(const ConstBaseIterator& other)const;

		T operator*()const;
	};
public:
	class ConstIterator :public ConstBaseIterator
	{
	public:
		ConstIterator(Element* Temp) :ConstBaseIterator(Temp) {}
		~ConstIterator() {}

		ConstIterator& operator++();
		ConstIterator operator++(int);
		ConstIterator& operator--();
		ConstIterator operator--(int);
	};

	class ConstReverseIterator :public ConstBaseIterator
	{
	public:
		ConstReverseIterator(Element* Temp) :ConstBaseIterator(Temp) {}
		~ConstReverseIterator() {}

		ConstReverseIterator& operator++();
		ConstReverseIterator operator++(int);
		ConstReverseIterator& operator--();
		ConstReverseIterator operator--(int);
	};
	class Iterator :public ConstIterator
	{
	public:
		Iterator(Element* Temp) :ConstIterator(Temp) {}
		~Iterator() {}

		T& operator*();
	};
	class ReverseIterator :public ConstReverseIterator
	{
	public:
		ReverseIterator(Element* Temp) :ConstReverseIterator(Temp) {}
		~ReverseIterator() {}

		T& operator*();
	};

	ConstIterator begin()const;
	ConstIterator end()const;
	Iterator begin();
	Iterator end();

	ConstReverseIterator rbegin()const;
	ConstReverseIterator rend()const;
	ReverseIterator rbegin();
	ReverseIterator rend();

	List();
	List(const std::initializer_list<T>& il);
	List(const List<T>& other);
	List(List<T>&& other);
	~List();

	//					Operators:
	List<T>& operator=(const List<T>& other);
	List<T>& operator=(List<T>&& other);

	//					Adding elements:
	void push_front(T Data);
	void push_back(T Data);
	void insert(T Data, int Index);

	//						Removing elements:
	void pop_front();
	void pop_back();

	//						Methods:
	void print()const;
	void reverse_print()const;
};

/////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////				КОНЕЦ ОБЪЯВЛЕНИЯ КЛАССА (CLASS DECLARATION END)					 ////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////
