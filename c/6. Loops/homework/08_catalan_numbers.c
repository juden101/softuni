#include <stdio.h>

unsigned long long factorial(int n);

int main() {
    int n;
    unsigned long long result;
    
    printf("n = ");
    scanf("%d", &n);
    
    result = (factorial(2 * n)) / ((factorial(n + 1)) * factorial(n));
    printf("result = %llu", result);

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