#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "read_n_characters.h"

int main()
{
    int size = 21;
    
    char* result = read_n_characters(size);

    int i;

    for (i = strlen(result); i < size; i++)
    {
        result[i] = '*';
    }

    result[size - 1] = '\0';

    printf("result = %s\n", result);
    free(result);

	return 0;
}