#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define INITIAL_SIZE 4

char* read_line();

int main()
{
	char *line = read_line();
	printf("%s\n", line);
}

char* read_line()
{
	char* line;
	size_t size = 0;

	getline(&line, &size, stdin);

	char *token = strtok(line, " ");
	char *array = malloc(INITIAL_SIZE * sizeof(char));

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
				char *new_array = realloc(array, array_length * 2);

				if (!new_array)
				{
					return NULL;
				}

				array = new_array;
				array_length *= 2;
			}

			array[i] = token[j];
			i++;
		}

		array[i] = ' ';
		i++;
		token = strtok(NULL, " ");
	}

	array[i - 2] = '\0';

	return array;
}