#include <stdio.h>
#include <float.h>

int main() {
    int n, m, i;
    float min = FLT_MAX, max = FLT_MIN, sum = 0, avg = 0;
    
    printf("n = ");
    scanf("%d", &n);
    
    for (i = 0; i < n; i++) {
        scanf("%d", &m);
        
        sum += m;
        min > m ? min = m : 0;
        max < m ? max = m : 0;
    }
    
    avg = sum / n;
    
    printf("min = %.2f\n", min);
    printf("max = %.2f\n", max);
    printf("sum = %.2f\n", sum);
    printf("avg = %.2f\n", avg);

    return 0;
}