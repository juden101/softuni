#include <stdio.h>

int main() {
    int a, b, c, d, e, isSubset = 0;
    
    printf("Enter numbers: ");
    scanf("%d %d %d %d %d", &a, &b, &c, &d, &e);
    
    if(a + b == 0)
    {
        isSubset = 1;
        printf("%d + %d = 0", a, b);
    }
    if (a + c == 0)
    {
        isSubset = 1;
        printf("%d + %d = 0", a, c);
    }
    if (a + d == 0)
    {
        isSubset = 1;
        printf("%d + %d = 0", a, d);
    }
    if (a + e == 0)
    {
        isSubset = 1;
        printf("%d + %d = 0", a, e);
    }
    if (b + c == 0)
    {
        isSubset = 1;
        printf("%d + %d = 0", b, c);
    }
    if (b + d == 0)
    {
        isSubset = 1;
        printf("%d + %d = 0", b, d);
    }
    if (b + e == 0)
    {
        isSubset = 1;
        printf("%d + %d = 0", b, e);
    }
    if (c + d == 0)
    {
        isSubset = 1;
        printf("%d + %d = 0", c, d);
    }
    if (c + e == 0)
    {
        isSubset = 1;
        printf("%d + %d = 0", c, e);
    }
    if (a + b + c == 0)
    {
        isSubset = 1;
        printf("%d + %d + %d = 0", a, b, c);
    }
    if (a + b + d == 0)
    {
        isSubset = 1;
        printf("%d + %d + %d = 0", a, b, d);
    }
    if (a + b + e == 0)
    {
        isSubset = 1;
        printf("%d + %d + %d = 0", a, b, e);
    }
    if (b + c + d == 0)
    {
        isSubset = 1;
        printf("%d + %d + %d = 0", b, c, d);
    }
    if (b + c + e == 0)
    {
        isSubset = 1;
        printf("%d + %d + %d = 0", b, c, e);
    }
    if (b + d + e == 0)
    {
        isSubset = 1;
        printf("%d + %d + %d = 0", b, d, e);
    }
    if (c + d + e == 0)
    {
        isSubset = 1;
        printf("%d + %d + %d = 0", c, d, e);
    }
    if (a + b + c + d == 0)
    {
        isSubset = 1;
        printf("%d + %d + %d + %d = 0", a, b, c, d);
    }
    if (a + b + c + e == 0)
    {
        isSubset = 1;
        printf("%d + %d + %d + %d = 0", a, b, c, e);
    }
    if (a + b + d + e == 0)
    {
        isSubset = 1;
        printf("%d + %d + %d + %d = 0", a, b, d, e);
    }
    if (a + c + d + e == 0)
    {
        isSubset = 1;
        printf("%d + %d + %d + %d = 0", a, c, d, e);
    }
    if(a + b + c + d + e == 0)
    {
        isSubset = 1;
        printf("%d + %d + %d + %d + %d = 0", a, b, c, d, e);
    }

    if(!isSubset)
    {
        printf("%s", "no zero subset");
    }

    return 0;
}