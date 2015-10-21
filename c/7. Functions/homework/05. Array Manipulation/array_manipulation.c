#include "array_manipulation.h"
#include <stdio.h>

int arr_min(int *arr, int size) {
    int i, min = arr[0];
    
    for (i = 1; i < size; i++) {
        if (min > arr[i]) {
            min = arr[i];
        }
    }
    
    return min;
}

int arr_max(int *arr, int size) {
    int i, max = arr[0];
    
    for (i = 1; i < size; i++) {
        if (max < arr[i]) {
            max = arr[i];
        }
    }
    
    return max;
}

void arr_clear(int *arr, int size) {
    int i;
    
    for (i = 0; i < size; i++) {
        arr[i] = 0;
    }
}

int arr_average(int *arr, int size) {
    int i, sum = 0;
    
    for (i = 0; i < size; i++) {
        sum += arr[i];
    }
    
    return sum / size;
}

int arr_sum(int *arr, int size) {
    int i, sum = 0;
    
    for (i = 0; i < size; i++) {
        sum += arr[i];
    }
    
    return sum;
}

int arr_contains(int *arr, int element, int size) {
    int i;
    
    for (i = 0; i < size; i++) {
        if (arr[i] == element) {
            return 1;
        }
    }
    
    return 0;
}

int* arr_merge(int *arr1, int *arr2, int size1, int size2) {
    int* result = malloc(4 * (size1 + size2));

    memcpy(result, arr1, 4 * size1);
    memcpy(result + size1, arr2, 4 * size2);
    
    return result;
}