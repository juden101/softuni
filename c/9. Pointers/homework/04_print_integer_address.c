#include <stdio.h>

void print(int);

int main()
{
	print(5);

	return 0;
}

void print(int n)
{
	printf("%p\n", &n);
}