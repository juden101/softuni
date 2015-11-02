#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main() 
{
    char *sentence = "C# is awesome";
    char *copy = strdup(sentence);
    copy[1] = ' ';
    
    printf("%s", copy);
    free(copy);
    
    return (EXIT_SUCCESS);
}

