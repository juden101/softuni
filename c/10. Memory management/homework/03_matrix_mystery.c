#include <stdio.h>
#include <stdlib.h>

int **matrix_create(int rowsCount, int colsCount)
{
    // 4-byte pointers x rowsCount
    int **rows = malloc(rowsCount * sizeof(int*));
    if (!rows)
    {
        return NULL;
    }

    int i = 0;
    while (i++ < colsCount)
    {
        rows[i] = malloc(colsCount * sizeof(int));
        if (!rows[i])
        {
            return NULL;
        }
    }
    
    return rows;
}

int main()
{
    int a = -1;
    printf("%d", a);
    // Declare
    int size = 3;
    int **matrix = matrix_create(size, size);
    
    // Modify
    matrix[0][0] = 3;
    matrix[0][2] = -2;
    matrix[1][2] = 4;
    matrix[2][1] = 1;
    
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
    
    // Free
    free(matrix);
    
    return (EXIT_SUCCESS);
}

