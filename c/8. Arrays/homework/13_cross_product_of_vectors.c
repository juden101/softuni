#include <stdio.h>
#include <math.h>

int main()
{
	int n = 3, i;

	int firstVector[n];
	int secondVector[n];
	int productVector[n];

	for (i = 0; i < n; i++)
	{
		scanf("%d", &firstVector[i]);
	}

	for (i = 0; i < n; i++)
	{
		scanf("%d", &secondVector[i]);
	}

	productVector[0] = (firstVector[1] * secondVector[2]) - (firstVector[2] * secondVector[1]);
	productVector[1] = (firstVector[2] * secondVector[0]) - (firstVector[0] * secondVector[2]);
	productVector[2] = (firstVector[0] * secondVector[1]) - (firstVector[1] * secondVector[0]);

	printf("product = [");
	for (i = 0; i < n; i++)
	{
		printf("%d", productVector[i]);

		if (i < n - 1)
		{
			printf(", ");
		}
	}
	printf("]\n");

	return 0;
}