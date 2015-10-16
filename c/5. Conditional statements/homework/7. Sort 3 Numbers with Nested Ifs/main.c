#include <stdio.h>
#include <string.h>

int main() {
    float a, b, c;
    char *result;
    
    printf("a = ");
    scanf("%f", &a);
    
    printf("b = ");
    scanf("%f", &b);
    
    printf("c = ");
    scanf("%f", &c);
    
    printf("result = ");
    
    if (a >= b && a >= c && b >= c)
    {
        printf("%.1f %.1f %.1f", a, b, c);
    }
    else if (a >= b && a >= c && c >= b)
    {
        printf("%.1f %.1f %.1f", a, c, b);
    }
    else if (b >= a && b >= c && a >= c)
    {
        printf("%.1f %.1f %.1f", b, a, c);
    }
    else if (b >= a && b >= c && c >= a)
    {
        printf("%.1f %.1f %.1f", c, b, a);
    }
    else if (c >= a && c >= b && a >= b)
    {
        printf("%.1f %.1f %.1f", c, a, b);
    }
    else if (c >= a && c >= b && b >= a)
    {
        printf("%.1f %.1f %.1f", c, b, a);
    }

    return 0;
}