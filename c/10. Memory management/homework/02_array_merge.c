#include <stdio.h>
#include <stdlib.h>

int *array_merge(int[], int[], size_t, size_t, size_t*);

int main() 
{
    int arrA[] = { -1, 5, 10 };
    size_t sizeA = sizeof(arrA) / sizeof(arrA[0]);
    int arrB[] = { 7, 2, 15 };
    size_t sizeB = sizeof(arrB) / sizeof(arrB[0]);
    
    size_t resSize;
    int *result = array_merge(arrA, arrB, sizeA, sizeB, &resSize);

    if (!result)
    {
        printf("Could not merge array");
        return 1;
    }
    
    int i;
    for (i = 0; i < resSize; i++)
    {
        printf("%d ", result[i]);
    }
    
    free(result);
    
    return 0;
}

int *array_merge(int arrA[], int arrB[], size_t sizeA, size_t sizeB, size_t *resSize)
{
    size_t newSize = sizeA + sizeB;
    int *result = malloc(newSize * 4);
    if (!result) {
        return NULL;
    }
    
    int i;
    for (i = 0; i < sizeA; i++)
    {
        result[i] = arrA[i];
    }
    
    int j;
    for (j = 0; j < sizeB; j++, i++)
    {
        result[i] = arrB[j];
    }
    
    *resSize = newSize;
    return result;
}