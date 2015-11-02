#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main() 
{
    char equation[] = "23+32=6";
    char *savePtr;
    char *token = strtok_r(equation, "+=", &savePtr);
    while (token)
    {
        printf("%s\n", token);
        token = strtok_r(NULL, "+=", &savePtr);
    }
    
    return (EXIT_SUCCESS);
}

