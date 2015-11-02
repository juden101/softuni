#include <stdio.h>
#include <stdlib.h>

int main() 
{
    int a = 2, b = 2;
    char buffer[5];
    snprintf(buffer, "%d + %d = %d", a, b, a + b);
    printf("%s", buffer);
    
    return (EXIT_SUCCESS);
}

