#include <stdio.h>
#include "05_array_manipulation.h"

int main(void) {
    int arr[] = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, '\0' };
    int arr2[] = { 17, 18, 2, '\0' };
    int arrCount = 10;
    int arr2Count = 3;
    
    printf("min = %d\n", arr_min(arr, arrCount));
    printf("max = %d\n", arr_max(arr, arrCount));
    printf("avg = %d\n", arr_average(arr, arrCount));
    
    // arr_clear(arr, arrCount);
    
    printf("sum = %d\n", arr_sum(arr, arrCount));
    printf("contains(%d) = %d\n", 1, arr_contains(arr, 1, arrCount));
    printf("contains(%d) = %d\n", 15, arr_contains(arr, 15, arrCount));
    
    int *merged = arr_merge(arr, arr2, arrCount, arr2Count);
    
    printf("merged = ");
    int i;
    for (i = 0; i < arrCount + arr2Count; i++) {
        printf("%d, ", merged[i]);
    }
    
    return 0;
}