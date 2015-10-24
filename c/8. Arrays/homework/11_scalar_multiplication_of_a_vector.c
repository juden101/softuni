#include <stdio.h>

int main()
{
	int n, x, i;

	printf("n = ");
	scanf("%d", &n);

	printf("x = ");
	scanf("%d", &x);

	int vector[n];

	for (i = 0; i < n; i++)
	{
		scanf("%d", &vector[i]);
		vector[i] *= x;
	}

	printf("result = ");

	for (i = 0; i < n; i++)
	{
		printf("%d ", vector[i]);
	}

	printf("\n");

	return 0;
}