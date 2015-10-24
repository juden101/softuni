#include <stdio.h>

int main() {
    int n, x, i;
    float resultX, factorialN, s;
    
    printf("n = ");
    scanf("%d", &n);
    
    printf("x = ");
    scanf("%d", &x);
    
    resultX = 1;
    factorialN = 1;
    s = 0;

    for (i = 1; i <= n; i++)
    {
        factorialN *= i;
        resultX *= x;
        s += (factorialN / resultX);
    }

    printf("result = %.5f", 1 + s);

    return 0;
}