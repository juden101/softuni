#include <stdio.h>

int main() {
    int a, b, c, r, gcd;
    
    printf("a = ");
    scanf("%d", &a);
    
    printf("b = ");
    scanf("%d", &b);
    
    if (a < b) {
        c = a;
        a = b;
        b = c;
    }

    for (;;) {
        r = a % b;

        if (r == 0) {
            gcd = b;
            break;
        }

        a = b;
        b = r;
    }

    printf("GCD = %d", gcd);

    return 0;
}