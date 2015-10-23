#include <stdio.h>

void swap(int*, int*);
void quicksort(int [], int, int, int);

int main()
{
    int n, m, i = 0;
    
    printf("n = ");
    scanf("%d", &n);
    
    printf("m = ");
    scanf("%d", &m);
    
    int firstArr[n];
    int secondArr[m];
    int third_arr[n + m];
    int size = 0;
    
    for (; i < n; i++)
    {
        scanf("%d", &firstArr[i]);
    }
    
    for (i = 0; i < m; i++)
    {
        scanf("%d", &secondArr[i]);
    }
    
    for (i = 0; i < n; i++)
    {
        if (!contains_element(third_arr, size, firstArr[i]))
        {
            third_arr[size++] = firstArr[i];
        }
    }
    
    for (i = 0; i < m; i++)
    {
        if (!contains_element(third_arr, size, secondArr[i]))
        {
            third_arr[size++] = secondArr[i];
        }
    }
    
    quicksort(third_arr, size, 0, size - 1);
    
    for (i = 0; i < size; i++)
    {
        printf("%d ", third_arr[i]);
    }

    return 0;
}

void swap(int *x, int *y)
{
    *x = *x ^ *y ^ (*y = *x);
}

int contains_element(int arr[], int size, int element)
{
    if (size <= 0)
    {
        return 0;
    }
    
    int i = 0;
    
    for (; i < size; i++)
    {
        if (arr[i] == element) 
        {
            return 1;
        }
    }
    
    return 0;
}

void quicksort(int arr[], int size, int first, int last)
{
    int pivot, j, temp, i;

    if(first < last)
    {
        pivot = first;
        i = first;
        j = last;

        while (i < j)
        {
            while(arr[i] <= arr[pivot] && i < last)
            {
                i++;
            }

            while(arr[j] > arr[pivot])
            {
                j--;
            }

            if(i < j)
            {
               swap(&arr[i], &arr[j]);
            }
        }

       swap(&arr[pivot], &arr[j]);
       quicksort(arr, size, first, j - 1);
       quicksort(arr, size, j + 1, last);
    }
}