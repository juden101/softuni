#include <stdio.h>

int main()
{
	int n, m, i, j;

	printf("n = ");
	scanf("%d", &n);

	printf("m = ");
	scanf("%d", &m);

	int firstMatrix[n][m];
	int secondMatrix[n][m];
	int thirdMatrix[n][m];

	for (i = 0; i < n; i++)
	{
		for (j = 0; j < m; j++)
		{
			scanf("%d", &firstMatrix[i][j]);
		}
	}

	for (i = 0; i < n; i++)
	{
		for (j = 0; j < m; j++)
		{
			scanf("%d", &secondMatrix[i][j]);
		}
	}

	printf("\nresult: \n");

	for (i = 0; i < n; i++)
	{
		for (j = 0; j < m; j++)
		{
			thirdMatrix[i][j] = firstMatrix[i][j] + secondMatrix[i][j];
			printf("%d ", thirdMatrix[i][j]);
		}

		printf("\n");
    }

	return 0;
}