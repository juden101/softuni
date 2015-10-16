#include <stdio.h>

int main() {
    float a, b, c, d, e, result;
    
    printf("a = ");
    scanf("%f", &a);
    
    printf("b = ");
    scanf("%f", &b);
    
    printf("c = ");
    scanf("%f", &c);
    
    printf("d = ");
    scanf("%f", &d);
    
    printf("e = ");
    scanf("%f", &e);
    
    if (a >= b && a >= c && a >= d && a >= e)
    {
        result = a;
    }
    else if (b >= a && b >= c && b >= d && b >= e)
    {
        result = b;
    }
    else if (c >= a && c >= b && c >= d && c >= e)
    {
        result = c;
    }
    else if (d >= a && d >= b && d >= c && d >= e)
    {
        result = d;
    }
    else if (e >= a && e >= b && e >= c && e >= d)
    {
        result = e;
    }
    
    printf("result = %.1f", result);

    return 0;
}