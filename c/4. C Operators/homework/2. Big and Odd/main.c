#include <stdio.h>
#include <math.h>

int main() {
    int n;
    
    scanf("%d", &n);
    printf("%d", n > 20 && n % 2 != 0);
    
    return 0;
}