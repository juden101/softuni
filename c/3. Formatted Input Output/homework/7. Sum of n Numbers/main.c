#include <stdio.h>

int main() {
    int n, i;
    float m, sum = 0;
    
    scanf("%d", &n);
    
    for (i = 0; i < n; i++)
    {
        scanf("%f", &m);
        sum += m;
    }
    
    printf("%.1f", sum);

    return 0;
}