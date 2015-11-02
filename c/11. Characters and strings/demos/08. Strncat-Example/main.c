#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main() 
{
    int bufferSize = 10;
    char name[bufferSize];
    
    strncpy(name, "Pesho", bufferSize);
    size_t length = strlen(name);
    strncat(name, " Kitaeca", bufferSize - length - 1);
    printf("%s", name);
    
    return (EXIT_SUCCESS);
}

