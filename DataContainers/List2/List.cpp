#include"List.h"

///---------------------------------------------------------------------------------------------------///

/////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////					����������� ������ (CLASS DEFINITION)						 ////////////
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
	//����������� �� ��������� ������� ������ ������
	Head = Tail = nullptr;
	size = 0;
	cout << "LConstrutor:\t" << this << endl;
}
template<typename T>List<T>::List(const std::initializer_list<T>& il) :List()
{
	//begin() - ���������� �������� �� ������ ����������.
	//end()   - ���������� �������� �� �����  ����������.
	//�������� - ��� ���������, ��� ������ �������� ����� �������� ������ � ��������� ��������� ������.
	cout << typeid(il.begin()).name() << endl;
	for (T const* it = il.begin(); it != il.end(); it++)
		push_back(*it);
}
template<typename T>List<T>::List(const List<T>& other) :List()	//��� ������������� ����� ������
{
	*this = other;
	cout << "LCopyConstructor:" << this << endl;
}
template<typename T>List<T>::List(List<T>&& other) : List()
{
	*this = std::move(other);	//����� ����� MoveAssignment
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

	//Deep copy - ��������� �����������:
	for (Element* Temp = other.Head; Temp; Temp = Temp->pNext)
		push_back(Temp->Data);
	cout << "LCopyAssignment:\t" << this << endl;
	return *this;
}
template<typename T>List<T>& List<T>::operator=(List<T>&& other)
{
	if (this == &other)return *this;
	while (Head) pop_front();

	//Shallow copy - ������������� �����������:
	this->Head = other.Head;
	this->Tail = other.Tail;
	this->size = other.size;

	//����������� ����� �������� 'other':
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
	cout << "���������� ��������� ������: " << size << endl;
}
template<typename T>void List<T>::reverse_print()const
{
	cout << "Tail:\t" << Tail << endl;
	for (Element* Temp = Tail; Temp; Temp = Temp->pPrev)
		cout << Temp->pPrev << tab << Temp << tab << Temp->Data << tab << Temp->pNext << endl;
	cout << "Head:\t" << Head << endl;
	cout << "���������� ��������� ������: " << size << endl;
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
////////////				����� ����������� ������ (CLASS DEFINITION END)					 ////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////
