#include <stdio.h>

unsigned long long factorial(int n);

int main() {
    int n, k;
    long result;
    
    printf("n = ");
    scanf("%d", &n);
    
    printf("k = ");
    scanf("%d", &k);
    
    result = factorial(n) / (factorial(k) * (factorial(n - k)));
    printf("%d! / (%d! * (%d - %d)!) = %llu", n, k, n, k, result);

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