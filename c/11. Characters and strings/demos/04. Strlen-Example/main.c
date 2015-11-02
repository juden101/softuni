#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main() 
{
    char *address = "Tintayava 15-17";
    size_t length = strlen(address);
    printf("%lu", length);
    
    return (EXIT_SUCCESS);
}

