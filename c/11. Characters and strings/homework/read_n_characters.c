#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char* read_n_characters(int size)
{
    char *input = calloc(size, sizeof(char));

    fgets(input, size, stdin);
    fflush(stdin);

    size_t length = strlen(input);
    char *new_line = strchr(input, '\n');

    if (new_line)
    {
    	*(new_line) = '\0';
    }

    return input;
}