#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main() 
{
    char *text = "Sir Stanley Royce";
    size_t length = strlen(text);
    char *destination = calloc(length + 1, sizeof(char));

    if (!destination)
    {
        return 1;
    }
    
    int i = 0, j = length - 1;

    while (i < length)
    {
        destination[j] = text[i];
        j--;
        i++;
    }

    destination[i] = '\0';
    
    printf("%s\n", destination);
    free(destination);
    
    return 0;
}