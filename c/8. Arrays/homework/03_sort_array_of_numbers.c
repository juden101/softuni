#include <stdio.h>

void swap(int*, int*);
void sort(int [], int);
void bubble_sort(int [], int);
void insertion_sort(int [], int);
void selection_sort(int [], int);
void quicksort(int [], int, int, int);

int main()
{
    int n, i;
    
    printf("n = ");
    scanf("%d", &n);
    
    int numbers[n];
    
    for (i = 0; i < n; i++)
    {
        scanf("%d", &numbers[i]);
    }
    
    sort(numbers, n);
    
    for (i = 0; i < n; i++)
    {
        printf("%d ", numbers[i]);
    }

    printf("\n");

    return 0;
}

void swap(int *x, int *y)
{
    *x = *x ^ *y ^ (*y = *x);
}

void sort(int arr[], int size)
{
    if (size <= 3)
    {
        bubble_sort(arr, size);
    }
    else if (size <= 6)
    {
        selection_sort(arr, size);
    }
    else if (size <= 10)
    {
        insertion_sort(arr, size);
    }
    else
    {
        quicksort(arr, size, 0, size - 1);
    }
}

void bubble_sort(int arr[], int size)
{
    int swapped = 1, i;
    
    while (swapped)
    {
        swapped = 0;
        
        for (i = 0; i < size - 1; i++)
        {
            if (arr[i] > arr[i + 1])
            {
                swap(&arr[i], &arr[i + 1]);
                swapped = 1;
            }
        }
    }
}

void insertion_sort(int arr[], int size)
{
    int i, j;
    
    for (i = 1; i < size; i++)
    {
        j = i;
        
        while (j > 0 && arr[j - 1] > arr[j])
        {
            swap(&arr[j], &arr[j - 1]);
            j--;
        }
    }
}

void selection_sort(int arr[], int size)
{
    int i, j, min;
    
    for (j = 0; j < size - 1; j++)
    {
        min = j;
        
        for (i = j + 1; i < size; i++)
        {
            if (arr[i] < arr[min])
            {
                min = i;
            }
        }

        if (min != j)
        {
            swap(&arr[j], &arr[min]);
        }
    }
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