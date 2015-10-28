#include <stdio.h>

int main()
{
	int arr[] = { 5, 8, 3, 1 }, i;
	int length = sizeof(arr) / sizeof(int);

	for (i = 0; i < length; i++)
	{
		printf("%d ", *(arr + i));
	}

	printf("\n");

	return 0;
}