#include <stdio.h>
#include <math.h>

int main() {
    int n;
    
    scanf("%d", &n);
    printf("%d", n % 9 == 0 || n % 11 == 0 || n % 13 == 0);
    
    return 0;
}