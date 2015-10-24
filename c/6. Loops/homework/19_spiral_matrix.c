#include <stdio.h>
#include <stdlib.h>

#define valid(i, j) 0 <= i && i < m && 0 <= j && j < n && !s[i][j]

int main(int c, char **matrix) {
    int x, i, j, m = 0, n = 0;
    
    printf("x = ");
    scanf("%d", &x);

    if (c >= 2) m = atoi(matrix[1]);
    if (c >= 3) n = atoi(matrix[2]);
    if (m <= 0) m = x;
    if (n <= 0) n = m;
 
    int **s = calloc(1, sizeof(int *) * m + sizeof(int) * m * n);
    s[0] = (int*)(s + m);
    
    for (i = 1; i < m; i++) {
        s[i] = s[i - 1] + n;
    }

    int dx = 1, dy = 0, val = 0, t;
    
    for (i = j = 0; valid(i, j); i += dy, j += dx ) {
        for ( ; valid(i, j); j += dx, i += dy) {
            s[i][j] = ++val;
        }

        j -= dx; i -= dy;
        t = dy; dy = dx; dx = -t;
    }

    for (t = 2; val /= 10; t++);

    for(i = 0; i < m; i++) {
        for(j = 0; j < n || !putchar('\n'); j++) {
            printf("%*d", t, s[i][j]);
        }
    }

    return 0;
}