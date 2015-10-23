#include <stdio.h>

int main()
{
	int n, m, i, j;

	printf("n = ");
	scanf("%d", &n);

	printf("m = ");
	scanf("%d", &m);

	int firstMatrix[n][m];
	int secondMatrix[m][n];
	int thirdMatrix[n][m];

	for (i = 0; i < n; i++)
	{
		for (j = 0; j < m; j++)
		{
			scanf("%d", &firstMatrix[i][j]);
		}
	}

	for (i = 0; i < m; i++)
	{
		for (j = 0; j < n; j++)
		{
			scanf("%d", &secondMatrix[i][j]);
		}
	}

    for (i = 0;i < n; i++)
    {
        for (j = 0; j < m; j++)
        {
            thirdMatrix[i][j] = 0;

            int k;
            for (k = 0; k < m; k++)
            {
                thirdMatrix[i][j] = thirdMatrix[i][j] + firstMatrix[i][k] * secondMatrix[k][j];
            }
        }
    }

    printf("\nresult: \n");

    for(i = 0; i < n; i++)
    {
        for(j = 0; j < m - 1; j++)
        {
        	printf("%d ", thirdMatrix[i][j]);
        }

        printf("\n");
    }

	return 0;
}