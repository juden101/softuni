#include <stdlib.h>
#include <string.h>
#include "string_reverse.h"

char* string_reverse(char* string, size_t size)
{
    char* reversed_string = malloc((size + 1) * sizeof(char));

    int i, index = 0;

    for (i = size - 1; i >= 0; i--, index++)
    {
        reversed_string[index] = string[i];
    }

    reversed_string[index] = '\0';

    return reversed_string;
}