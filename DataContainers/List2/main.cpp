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
	class ConstIterator:public ConstBaseIterator
	{
	public:
		ConstIterator(Element* Temp) :ConstBaseIterator(Temp) {}
		~ConstIterator() {}

		ConstIterator& operator++();
		ConstIterator operator++(int);
		ConstIterator& operator--();
		ConstIterator operator--(int);
	};

	class ConstReverseIterator:public ConstBaseIterator
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

///---------------------------------------------------------------------------------------------------///

/////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////					ОПРЕДЕЛЕНИЕ КЛАССА (CLASS DEFINITION)						 ////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////


/////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////								  Iterators:									/////////////

template<typename T>bool List<T>::ConstBaseIterator::operator==(const ConstBaseIterator& other)const
{
	return this->Temp == other.Temp;
}
template<typename T>bool List<T>::ConstBaseIterator::operator!=(const ConstBaseIterator& other)const
{
	return this->Temp != other.Temp;
}

template<typename T>T List<T>::ConstBaseIterator::operator*()const
{
	return Temp->Data;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////

template<typename T>typename List<T>::ConstIterator& List<T>::ConstIterator::operator++()		//Prefix increment
{
	this->Temp = this->Temp->pNext;
	return *this;
}
template<typename T>typename List<T>::ConstIterator  List<T>::ConstIterator::operator++(int)	//Postfix increment
{
	ConstIterator old = *this;
	this->Temp = this->Temp->pNext;
	return old;
}
template<typename T>typename List<T>::ConstIterator& List<T>::ConstIterator::operator--()
{
	this->Temp = this->Temp->pPrev;
	return *this;
}
template<typename T>typename List<T>::ConstIterator  List<T>::ConstIterator::operator--(int)
{
	ConstIterator old = this->Temp;
	this->Temp = this->Temp->pPrev;
	return old;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////

template<typename T>typename List<T>::ConstReverseIterator& List<T>::ConstReverseIterator::operator++()
{
	this->Temp = this->Temp->pPrev;
	return *this;
}
template<typename T>typename List<T>::ConstReverseIterator  List<T>::ConstReverseIterator::operator++(int)
{
	ConstReverseIterator old = *this;
	this->Temp = this->Temp->pPrev;
	return old;
}
template<typename T>typename List<T>::ConstReverseIterator& List<T>::ConstReverseIterator::operator--()
{
	this->Temp = this->Temp->pNext;
	return *this;
}
template<typename T>typename List<T>::ConstReverseIterator  List<T>::ConstReverseIterator::operator--(int)
{
	ConstReverseIterator old = *this;
	this->Temp = this->Temp->pNext;
	return old;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////

template<typename T>T& List<T>::Iterator::operator*()
{
	return this->Temp->Data;
}
template<typename T>T& List<T>::ReverseIterator::operator*()
{
	return this->Temp->Data;
}

////////////								  Iterators:									/////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////

///---------------------------------------------------------------------------------------------------///

/////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////								List members:									/////////////

template<typename T>typename List<T>::ConstIterator List<T>::begin()const
{
	return Head;
}
template<typename T>typename List<T>::ConstIterator List<T>::end()const
{
	return nullptr;
}
template<typename T>typename List<T>::Iterator List<T>::begin()
{
	return Head;
}
template<typename T>typename List<T>::Iterator List<T>::end()
{
	return nullptr;
}
template<typename T>typename List<T>::ConstReverseIterator List<T>::rbegin()const
{
	return Tail;
}
template<typename T>typename List<T>::ConstReverseIterator List<T>::rend()const
{
	return nullptr;
}
template<typename T>typename List<T>::ReverseIterator List<T>::rbegin()
{
	return Tail;
}
template<typename T>typename List<T>::ReverseIterator List<T>::rend()
{
	return nullptr;
}

template<typename T>List<T>::List()
{
	//Конструктор по умолчанию создает пустой список
	Head = Tail = nullptr;
	size = 0;
	cout << "LConstrutor:\t" << this << endl;
}
template<typename T>List<T>::List(const std::initializer_list<T>& il) :List()
{
	//begin() - возвращает итератор на начало контейнера.
	//end()   - возвращает итератор на конец  контейнера.
	//Итератор - это указатель, при помощи которого можно получить доступ к элементам структуры данных.
	cout << typeid(il.begin()).name() << endl;
	for (T const* it = il.begin(); it != il.end(); it++)
		push_back(*it);
}
template<typename T>List<T>::List(const List<T>& other) :List()	//Без делегирования может падать
{
	*this = other;
	cout << "LCopyConstructor:" << this << endl;
}
template<typename T>List<T>::List(List<T>&& other) :List()
{
	*this = std::move(other);	//Явный вызов MoveAssignment
}
template<typename T>List<T>::~List()
{
	while (Tail) pop_back();
	cout << "LDestrutor:\t" << this << endl;
}

//					Operators:
template<typename T>List<T>& List<T>::operator=(const List<T>& other)
{
	if (this == &other)return *this;
	while (Head)pop_front();

	//Deep copy - Побитовое копирование:
	for (Element* Temp = other.Head; Temp; Temp = Temp->pNext)
		push_back(Temp->Data);
	cout << "LCopyAssignment:\t" << this << endl;
	return *this;
}
template<typename T>List<T>& List<T>::operator=(List<T>&& other)
{
	if (this == &other)return *this;
	while (Head) pop_front();

	//Shallow copy - Поверхностное копирование:
	this->Head = other.Head;
	this->Tail = other.Tail;
	this->size = other.size;

	//Обязательно нужно обнулить 'other':
	other.Head = other.Tail = nullptr;
	other.size = 0;

	cout << "LMoveAssignment:\t" << this << endl;
}

//					Adding elements:
template<typename T>void List<T>::push_front(T Data)
{
	if (Head == nullptr && Tail == nullptr)Head = Tail = new Element(Data);
	else Head = Head->pPrev = new Element(Data, Head);
	size++;
}
template<typename T>void List<T>::push_back(T Data)
{
	if (Head == nullptr && Tail == nullptr)return push_front(Data);
	Tail = Tail->pNext = new Element(Data, nullptr, Tail);
	size++;
}
template<typename T>void List<T>::insert(T Data, int Index)
{
	if (Index == 0)return push_front(Data);
	if (Index == size - 1)return push_back(Data);
	if (Index >= size)throw std::exception("insert: Out of range exception");
	Element* Temp;
	if (Index < size / 2)
	{
		Temp = Head;
		for (int i = 0; i < Index; i++)Temp = Temp->pNext;
	}
	else
	{
		Temp = Tail;
		for (int i = 0; i < size - Index - 1; i++)Temp = Temp->pPrev;
	}
	Temp->pNext->pPrev = Temp->pPrev->pNext = new Element(Data, Temp->pNext, Temp->pPrev);
	size++;
}

//						Removing elements:
template<typename T>void List<T>::pop_front()
{
	if (Head == Tail)
	{
		delete Head;
		Head = Tail = nullptr;
		size = 0;
		return;
	}
	Head = Head->pNext;
	delete Head->pPrev;
	Head->pPrev = nullptr;
	size--;
}
template<typename T>void List<T>::pop_back()
{
	if (Head == Tail)return pop_front();
	Tail = Tail->pPrev;
	delete Tail->pNext;
	Tail->pNext = nullptr;
	size--;
}

//						Methods:
template<typename T>void List<T>::print()const
{
	cout << "Head:\t" << Head << endl;
	for (Element* Temp = Head; Temp; Temp = Temp->pNext)
		cout << Temp->pPrev << tab << Temp << tab << Temp->Data << tab << Temp->pNext << endl;
	cout << "Tail:\t" << Tail << endl;
	cout << "Количество элементов списка: " << size << endl;
}
template<typename T>void List<T>::reverse_print()const
{
	cout << "Tail:\t" << Tail << endl;
	for (Element* Temp = Tail; Temp; Temp = Temp->pPrev)
		cout << Temp->pPrev << tab << Temp << tab << Temp->Data << tab << Temp->pNext << endl;
	cout << "Head:\t" << Head << endl;
	cout << "Количество элементов списка: " << size << endl;
}

////////////								List members:									/////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////

template<typename T>List<T> operator+(const List<T>& left, const List<T>& right)
{
	List<T> buffer;
	for (typename List<T>::ConstIterator it = left.begin(); it != left.end(); ++it)buffer.push_back(*it);
	for (typename List<T>::ConstIterator it = right.begin(); it != right.end(); ++it)
	{
		buffer.push_back(*it);
		//*it *= 10;
	}
	return buffer;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////				КОНЕЦ ОПРЕДЕЛЕНИЯ КЛАССА (CLASS DEFINITION END)					 ////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////

//#define BASE_CHECK
//#define ITERATORS_CHECK

void main()
{
	setlocale(LC_ALL, "");

#ifdef BASE_CHECK
	int n;
	cout << "Введите размер списка: "; cin >> n;
	List list;
	for (int i = 0; i < n; i++)
	{
		//list.push_front(rand() % 100);
		list.push_back(rand() % 100);
	}
	list.print();
	list.reverse_print();
	/*for (int i = 0; i < n * 2; i++)list.pop_back();
	list.print();
	list.reverse_print();*/

	int index;
	int value;
	cout << "Введите индекс добавляемого элемента: "; cin >> index;
	cout << "Введите значение добавляемого элемента: "; cin >> value;
	try
	{
		list.insert(value, index);
		list.print();
		list.reverse_print();
	}
	catch (const std::exception& e)
	{
		std::cerr << e.what() << endl;
	}
#endif // BASE_CHECK

#ifdef ITERATORS_CHECK
	List list = { 3, 5, 8, 13, 21 };
	//list.print();
	for (int i : list)
	{
		cout << i << tab;
	}
	cout << endl;

	for (List::Iterator it = list.begin(); it != list.end(); ++it)
	{
		cout << *it << tab;
	}
	cout << endl;

	for (List::ReverseIterator it = list.rbegin(); it != list.rend(); ++it)
	{
		cout << *it << tab;
	}
	cout << endl;
#endif // ITERATORS_CHECK

	List<int> list1 = { 3, 5, 8, 13, 21 };
	List<int> list2 = { 34, 55, 89 };
	List<int> list3 = list1 + list2;
	for (int i : list1)cout << i << tab; cout << endl;
	for (int i : list2)cout << i << tab; cout << endl;
	for (int i : list3)cout << i << tab; cout << endl;

	for (List<int>::Iterator it = list1.begin(); it != list1.end(); ++it)
	{
		*it *= 10;
	}
	for (int i : list1)cout << i << tab; cout << endl;

	List<double> d_list = { 2.7, 3.14, 5.1, 8.3 };
	for (double i : d_list)cout << i << tab; cout << endl;
	for (List<double>::ReverseIterator it = d_list.rbegin(); it != d_list.rend(); ++it)
		cout << *it << tab;
	cout << endl;

	List<std::string> s_list = { "Ах", "ты", "ж", "Ёжтыкин", "ты", "20" };
	for (std::string i : s_list)cout << i << tab; cout << endl;
	for (List<std::string>::ReverseIterator it = s_list.rbegin(); it != s_list.rend(); ++it)
		cout << *it << tab;
}