#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define INITIAL_BUFFER_LENGTH 8

char *string_join(char *strings[], size_t count, char *delimiter)
{
    char *result = calloc(INITIAL_BUFFER_LENGTH, 1);
    if (!result)
    {
        return NULL;
    }
    
    size_t delimLength = strlen(delimiter);
    size_t currentBufferSize = INITIAL_BUFFER_LENGTH;
    size_t i, index = 0;
    for (i = 0; i < count; i++)
    {
        size_t currentLength = strlen(strings[i]); 
        size_t totalLength = currentLength + delimLength;
        if (index + totalLength >= currentBufferSize)
        {
            size_t newBufferSize = currentBufferSize + (totalLength * 2);
            char *newResult = realloc(result, newBufferSize);
            if (!newResult)
            {
                return NULL;
            }
            
            result = newResult;
            currentBufferSize = newBufferSize;
        }
        
        strncat(result, strings[i], currentLength);
        strncat(result, delimiter, delimLength);
        index += totalLength;
//        printf("%s\n", result);
    }
    
    result[index] = '\0';
    char *finalResult = realloc(result, index + 1);
    if (!finalResult)
    {
        return NULL;
    }
    
    return finalResult;
}

int main() 
{
    char *strings[5] = {
        "Plovdiv", "Sofia", "Pernik", "Dolni Vodne", "Kurtovo Konare"
    };
    
    size_t count = sizeof(strings) / sizeof(char *);
    
    char *result = string_join(strings, count, "|");
    if (!result)
    {
        printf("Could not join strings");
        return 1;
    }
    
    printf("%s\n", result);
    free(result);
    
    return (EXIT_SUCCESS);
}

