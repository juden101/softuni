#include <stdio.h>

unsigned long long factorial(int n);

int main() {
    int n, k;
    unsigned long long result;
    
    printf("n = ");
    scanf("%d", &n);
    
    printf("k = ");
    scanf("%d", &k);
    
    result = factorial(n) / factorial(k);
    printf("%d! / %d! = %llu", n, k, result);

    return 0;
}

unsigned long long factorial(int n) {
    int i;
    unsigned long long result = 1;

    for (i = 1; i <= n; i++) {
        result = result * i;
    }

    return result;
}