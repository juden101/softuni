#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main() 
{
    char text[] = "Sha idvate li na konfa";
    char copy[strlen(text) + 1];
    strcpy(copy, text);
    
    char *token = strtok(text, " ");
    while (token)
    {
        printf("%s\n", token);
        token = strtok(NULL, " ");
    }
    
    printf("%s\n", copy);
    
    return (EXIT_SUCCESS);
}

