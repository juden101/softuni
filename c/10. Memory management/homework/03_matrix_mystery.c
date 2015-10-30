#include <stdio.h>
#include <stdlib.h>

int **matrix_create(int rowsCount, int colsCount)
{
    int **rows = calloc(rowsCount , sizeof(int)), i = 0;

    while (i < colsCount)
    {
        rows[i] = calloc(colsCount , sizeof(int));
        i++;
    }

    return rows;
}

int main()
{
    long long a = -1;
    printf("%lld", a);
    
    int size = 3, **matrix = matrix_create(size, size);

    *(*(matrix)) = 3;
    *(*(matrix) + 2) = -2;
    *(*(matrix + 1) + 2) = 4;
    *(*(matrix + 2) + 1) = 1;

    int row;

    for (row = 0; row < size; row++)
    {
        int col;

        for (col = 0; col < size; col++)
        {
            printf("%d ", matrix[row][col]);
        }

        printf("\n");
    }

    for (row = 0; row < size; row++)
    {
        free(matrix[row]);
    }

    free(matrix);

    return 0;
}