#include<iostream>
using namespace std;

int Factorial(int n)
{
	if (n == 0)return 1;
	return n * Factorial(n - 1);
}

void main()
{
	setlocale(LC_ALL, "");
	cout << "Hello";
	/*try
	{
		main();
	}
	catch (...)
	{
		std::cerr << "Something went wrong..." << endl;
	}
	cout << "OK" << endl;*/

	int n;
	cout << "¬ведите число: "; cin >> n;
	cout << Factorial(n) << endl;
}