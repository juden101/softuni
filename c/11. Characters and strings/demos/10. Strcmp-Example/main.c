#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main() 
{
    size_t size = 10;
    char line[size];
    fgets(line, size, stdin);
    while (strcmp(line, "end\n") != 0)
    {
        printf("%s", line);
        fgets(line, size, stdin);
    }
    
    return (EXIT_SUCCESS);
}

