#include <stdio.h>

int main() {
    float a, b, c;
    char result;
    
    printf("a = ");
    scanf("%f", &a);
    
    printf("b = ");
    scanf("%f", &b);
    
    printf("c = ");
    scanf("%f", &c);
    
    if(a > 0)
    {
        if(b > 0)
        {
            if(c > 0)
            {
                result = '+';
            }
            else if(c < 0)
            {
                result = '-';
            }
        }
        else if(b < 0)
        {
            if(c > 0)
            {
                result = '-';
            }
            else if (c < 0)
            {
                result = '+';
            }
        }
    }
    else if(a < 0)
    {
        if (b > 0)
        {
            if (c > 0)
            {
                result = '-';
            }
            else if (c < 0)
            {
                result = '+';
            }
        }
        else if (b < 0)
        {
            if (c > 0)
            {
                result = '+';
            }
            else if (c < 0)
            {
                result = '-';
            }
        }
    }
    
    printf("result = %c", result);

    return 0;
}
