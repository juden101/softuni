#include <stdio.h>

int main() {
    int i;
    int n;
    
    scanf("%d", &n);
    
    for (i = 2; i < n + 2; i++) {
        if (i % 2 == 0) {
            printf("%d", i);
        }
        else
        {
            printf("%d", -i);
        }
        
        if (i != n + 1) {
            printf(", ");
        }
    }

    return 0;
}