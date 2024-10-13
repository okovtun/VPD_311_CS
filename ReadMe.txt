https://github.com/okovtun/VPD_311_CS.git
https://www.youtube.com/playlist?list=PLeqyOOqxeiIPzjdgMyV-nahHoE2Z_eEGM

https://stackoverflow.com/questions/2056445/no-overflow-exception-for-int-in-c

TODO:
1. Добавить в дерево следующие методы:	DONE
	??? minValue(???);
	??? maxValue(???);
	??? count(???);		//возвращает размер дерева
	??? sum(???);		//возвращает сумму элементов дерева
	??? avg(???);		//возвращает среднее-арифметическое элементов дерева 
2. Обеспечить вызов методов дерева без необходимости передачи в них корня;	DONE
3. Добавить следующие методы:
	??? clear(???);		DONE
	??? erase(???);		//удаляет заданный элемент дерева
	----------------------------------------------------------------------
	??? depth(???);		//возвращает глубину дерева
4. Вычислить производительность каждого метода в дереве;
5. Измерить производительность методов в дереве на 1 000 000 элементов и более;
6. Вывести дерево на экран как дерево;
7. Написать метод ??? balance(???), который балансирует Бинарное дерево
	(из вырожденного делает идеально-сбалансированное, или близкое к нему)

https://ru.wikipedia.org/wiki/%D0%A5%D0%B0%D0%BD%D0%BE%D0%B9%D1%81%D0%BA%D0%B0%D1%8F_%D0%B1%D0%B0%D1%88%D0%BD%D1%8F

DONE:
1.
	??? push_back(???);		DONE
	??? pop_front();		DONE
	??? pop_back();			DONE
	??? insert(???);		DONE
	??? erase(???);

2. Решить проблему утечки памяти;	DONE
3.	DONE
	List list = { 3, 5, 8, 13, 21 };DONE
	for(int i:list)					DONE
	{
		cout << i << tab;
	}
	cout << endl;

4.	NRVO - Named Return Value optimisation	DONE
	List list1 = { 3, 5, 8, 13, 21 };
	List list2 = { 34, 55, 89 };
	List list3 = list1 + list2;
	for(int i:list3)
	{
		cout << i << tab;
	}
	cout << endl;

5. В ветке 'TemplatedList' шаблонизировать двусвязный спискок;
6. В ветке 'SeparatedList' вынести список в отдельные файлы;

DONE:
1. Написать метод erase(), который удаляет элемент из списка по указанному индексу;
2. Код метода push_front() оптимизировать до одного выражения. Size в оптимихацию не включается;	DONE
3. Проверочный код должен заработать:
	https://github.com/okovtun/VPD_311_CS/blob/9a932e16bc80eddec40fecb557b885ce0c5014d7/DataContainers/ForwardList/Program.cs#L37C1-L44C7

DONE:
1. Из файла '201 RAW.txt' (https://github.com/okovtun/VPD_311_CS/blob/master/Inheritance/FilesCPPtask/201%20RAW.txt)
   создать файл '201 ready.txt',  в котором столбики MAC и IP-адресом будут поменяны местами;
2. Из файла '201 RAW.txt' (https://github.com/okovtun/VPD_311_CS/blob/master/Inheritance/FilesCPPtask/201%20RAW.txt)
   создать файл формата '201.dhcpd' (https://github.com/okovtun/VPD_311_CS/blob/master/Inheritance/FilesCPPtask/201.dhcpd.txt);

   Обе задачи нужно решить как на C++, так и на C#.

3. Реализовать иерархию геометрических фигур: квадрат, прямоугольник, круг, треугольник.......
   Сгенерировать фигуры в случайном порядке, и для каждой фигуры вывести ее первичные своиства: 
   длина стороны, радиус .....
   и вторичные свойства, такие как: площадь и периметр. Каждую фигуру так же нужно нарисовать.

TODO:
1. Сохранить группу в файл;
2. Загрузить группу из файла;

DONE:
1. Перегрузить операторы +, -;
2. Перегрузить все операторы сравнения;
3. Incremento/Decremento (++/--);
4. Fraction A = new Fraction(2.75);

DONE:
1. Реализовать калькулятор, который может вычислить выражение любой сложности;
	22 + 33 - 8 * 4 + 7 / 8;
2. Добавить в этот калькулятор скобки;
	22 + (33 - 8) * (4 + 7) / 8;

DONE:
1. https://github.com/okovtun/BV_011/blob/master/ControlStructures/Geometria/Task/Geometria1.txt
2. https://github.com/okovtun/BV_011/blob/master/ControlStructures/Geometria/Task/ChessBoard.jpg
3. https://github.com/okovtun/BV_011/blob/master/ControlStructures/Geometria/Task/HardChess.jpg
4. Написать программу, которая перемещает квадратик по экрану, при нажатии клавиш WASD, или соответствующих стрелок;
5. Написать калькулятор, аналогичный тому, который писали на C++;