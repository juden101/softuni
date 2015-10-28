#include <stdio.h>

void swap(int *first, int *second);

int main()
{
	int a = 5;
	int b = 7;

	printf("before swap:\n");
	printf("a = %d\n", a);
	printf("b = %d\n\n", b);

	swap(&a, &b);

	printf("after swap:\n");
	printf("a = %d\n", a);
	printf("b = %d\n", b);

	return 0;
}

void swap(int *first, int *second)
{
	*(first) ^= *(second);
	*(second) ^= *(first);
	*(first) ^= *(second);
}