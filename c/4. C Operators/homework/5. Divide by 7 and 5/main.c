#include <stdio.h>

int main() {
    int n;
    
    scanf("%d", &n);
    printf("%d", n % 5 == 0 && n % 7 == 0 && n != 0);

    return 0;
}