#include <stdio.h>

int main() {
    int n, trailingZeroes = 0, five = 5;
    
    printf("n = ");
    scanf("%d", &n);

    while (five < n)
    {
        trailingZeroes += n / five;
        five *= 5;
    }

    printf("trailing zeroes = %d", trailingZeroes);

    return 0;
}
