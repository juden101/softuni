#include <stdio.h>

int main()
{
	int n;

	printf("n = ");
	scanf("%d", &n);

	int matrix[n][n];
	int i, j;

	for (i = 0; i < n; i++)
	{
		for (j = 0; j < n; j++)
		{
			scanf("%d", &matrix[i][j]);
		}
	}

	int count = 1;

	for (i = 0; i < n; i++)
	{
		for (j = 0; j < count; j++)
		{
			printf("%d ", matrix[i][j]);
		}

		count++;
		printf("\n");
	}

	return 0;
}