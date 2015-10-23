#include <stdio.h>

int main()
{
	int n, i;

	printf("n = ");
	scanf("%d", &n);

	int firstVector[n];
	int secondVector[n];

	for (i = 0; i < n; i++)
	{
		scanf("%d", &firstVector[i]);
	}

	for (i = 0; i < n; i++)
	{
		scanf("%d", &secondVector[i]);
	}

	int product = 0;

	for (i = 0; i < n; i++)
	{
		product += firstVector[i] * secondVector[i];
	}

	printf("product = %d\n", product);

	return 0;
}