#include <stdio.h>

int main() {
    float a, b, c, result;
    
    printf("a = ");
    scanf("%f", &a);
    
    printf("b = ");
    scanf("%f", &b);
    
    printf("c = ");
    scanf("%f", &c);
    
    if (a > b && a > c)
    {
        result = a;
    }
    else if (b > a && b > c)
    {
        result = b;
    }
    else if(c > a && c > b)
    {
        result = c;
    }
    
    printf("result = %.1f", result);

    return 0;
}