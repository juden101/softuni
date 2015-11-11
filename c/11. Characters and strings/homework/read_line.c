#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "read_line.h"

#define INITIAL_SIZE 4

char* read_line()
{
    char* line = NULL;
    size_t size = 0;

    getline(&line, &size, stdin);

    char *token = strtok(line, " ");
    char *array = calloc(INITIAL_SIZE, sizeof(char));

    if (!array)
    {
        return NULL;
    }

    int i = 0, array_length = INITIAL_SIZE;

    while (token)
    {
        int j, token_length = strlen(token);
        
        for (j = 0; j < token_length; j++)
        {
            if (i == array_length)
            {
                array_length = array_length + (array_length * 2);
                char *new_array = realloc(array, array_length);

                if (!new_array)
                {
                    return NULL;
                }

                array = new_array;
            }

            array[i] = token[j];
            i++;
        }

        array[i] = ' ';
        i++;
        token = strtok(NULL, " ");
    }

    array[i - 2] = '\0';

    free(line);

    return array;
}