#include <stdio.h>

void swap(int*, int*);
void reverse_array(int [], int);

int main()
{
	int n, i = 0;

	printf("n = ");
	scanf("%d", &n);

	int numbers[n];

	for (; i < n; i++)
	{
		scanf("%d", &numbers[i]);
	}

	reverse_array(numbers, n);

	for (i = 0; i < n; i++)
	{
		printf("%d ", numbers[i]);
	}

	return 0;
}

void swap(int *x, int *y)
{
    *x = *x ^ *y ^ (*y = *x);
}

void reverse_array(int arr[], int size)
{
	int i = 0;

	for (; i < size / 2; i++)
	{
		swap(&arr[i], &arr[size - i - 1]);
	}
}