#include <string.h>
#include "str_lib.h"

char *str_to_lower(char *input)
{
    int i;

    for (i = 0; input[i]; i++)
    {
        input[i] = tolower(input[i]);
    }

    return input;
}