#include <stdio.h>
#include <stdlib.h>

int main() {
    int n, i;
    
    printf("n = ");
    scanf("%d", &n);
    
    int numbers[n];
    
    for (i = 0; i < n; i++)
    {
        numbers[i] = i + 1;
    }
    
    shuffle(numbers, n);
    printf("result = ");
    
    for (i = 0; i < n; i++)
    {
        printf("%d ", numbers[i]);
    }

    return 0;
}

void shuffle(int *array, size_t n)
{
    if (n > 1) {
        size_t i;
        
	for (i = 0; i < n - 1; i++) {
	  size_t j = i + rand() / (RAND_MAX / (n - i) + 1);
	  int t = array[j];
	  array[j] = array[i];
	  array[i] = t;
	}
    }
}