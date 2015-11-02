#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "read_line.h"

char* remove_duplicates(char *array, int array_size);

int main()
{
	char *input = read_line();
	int length = strlen(input);

	char *result = remove_duplicates(input, length);

	int i;
	for (i = 0; i < strlen(result); i++)
	{
		printf("%c", result[i]);
	}

	printf("\n");

	free(input);
	free(result);

	return 0;
}

char* remove_duplicates(char *array, int array_size)
{
   	int i, j = 1;
   	char *result = calloc(strlen(array), sizeof(char));

   	result[0] = array[0];

    for (i = 1; i < array_size; i++)
    {
    	if (array[i] != array[i - 1])
    	{
    		result[j] = array[i];
       		j++;
     	}
    }

	result = (char *) realloc(result, strlen(result) + 1);

	return result;
}